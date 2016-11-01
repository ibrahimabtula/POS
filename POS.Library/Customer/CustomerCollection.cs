using CSLA;
using CSLA.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;

namespace POS.Library
{
    public class CustomerCollection : BusinessCollectionBase
    {
        #region Business Properties and Methods

        public Customer this[int index]
        {
            get { return (Customer)List[index]; }
        }

        public void Add(Customer item)
        {
            if (!Contains(item))
                List.Add(item);
            else
                throw new Exception("Customer '" + item.ToString() + "' already exist.");
        }

        public void Remove(Customer item)
        {
            List.Remove(item);
        }

        public void Remove(int id)
        {
            foreach (Customer child in List)
            {
                if (child.ID.Equals(id))
                {
                    Remove(child);
                    break;
                }
            }
        }

        public bool IsSaveable
        {
            //Since you cannot bind a control to multiple properties you need to create a property that combines the ones you need
            //In this case, bind the UI Save button Enabled property to IsSaveable. (Why save an object that has not changed?)
            get { return IsValid && IsDirty; }
        }

        public void AddRange(System.Collections.Generic.IEnumerable<Customer> aList)
        {
            foreach (Customer child in aList)
            {
                this.Add(child);
            }
        }

        public void AddRange(CustomerCollection aList)
        {
            foreach (Customer child in aList)
            {
                this.Add(child);
            }
        }

        #endregion //Business Properties and Methods

        #region Constructor
        private CustomerCollection()
        {

            AllowSort = true;
            AllowFind = true;
            AllowEdit = true;
            AllowNew = true;
            AllowRemove = true;
        }
        #endregion //Constructor

        #region Overrides
        protected override object OnAddNew()
        {
            Customer child = Customer.NewCustomer(0);
            this.Add(child);
            return child;
        }

        #endregion//Overrides

        #region Criteria (identifies the Individual Object/ Primary Key)
        [Serializable]
        public class Criteria
        {
            public int ID = 0;

            public Criteria()
            {
            }
        }
        #endregion //Criteria

        #region Static Methods

        public static CustomerCollection NewCustomerCollection()
        {
            return (CustomerCollection)DataPortal.Create(new Criteria());
        }

        public static CustomerCollection GetCustomerCollection()
        {
            return (CustomerCollection)DataPortal.Fetch(new Criteria());
        }

        public static CustomerCollection GetCustomerCollection(Criteria crit)
        {
            return (CustomerCollection)DataPortal.Fetch(crit);
        }

        #endregion //Static Methods

        #region Data Access
        //Called by DataPortal so that we can set defaults as needed
        protected override void DataPortal_Create(object criteria)
        {
            //Create new object with default stored in the database
            Criteria crit = (Criteria)criteria;
        }

        //Called by DataPortal to load data from the database
        protected override void DataPortal_Fetch(object criteria)
        {
            //retrieve data from database
            Criteria crit = (Criteria)criteria;

            using (IDbConnection connection = SQLiteConnectionBuilder.GetOpenedConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    const string query = @"
SELECT  
    [ID]
    ,[FirstName]
    ,[LastName]
    ,Note
FROM[Customer] ";
                    AddRange(connection.Query<Customer>(query, null,transaction).Do(c=>c.MarkOld()));
                    transaction.Commit();
                }
            }
        }

        protected override void DataPortal_Update()
        {
            using (var cn = SQLiteConnectionBuilder.GetOpenedConnection())
            {
                try
                {
                    using (var tr = cn.BeginTransaction(IsolationLevel.Serializable))
                    {
                        // Loop through each deleted child object and call its Update() method
                        foreach (Customer deletedChild in deletedList)
                            deletedChild.Update(tr);

                        // Then clear the list of deleted objects because they are truly gone now
                        deletedList.Clear();

                        // loop through each non-deleted child object and call its Update() method
                        foreach (Customer child in List)
                            child.Update(tr);

                        tr.Commit();
                    }
                }
                catch(Exception e)
                {
                    throw;
                }
                finally
                {
                    cn.Close();
                }
            }

            OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.Reset,0));
        }

        #endregion //Data Access

    }
}
