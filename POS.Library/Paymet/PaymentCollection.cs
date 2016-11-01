using CSLA;
using CSLA.Data;
using Dapper;
using System;
using System.Data;
using System.Data.SqlServerCe;

namespace POS.Library
{
    public class PaymentCollection : BusinessCollectionBase
    {
        #region Business Properties and Methods

        public Payment this[int index]
        {
            get { return (Payment)List[index]; }
        }

        public void Add(Payment item)
        {
            if (!Contains(item))
                List.Add(item);
            else
                throw new Exception("Payment '" + item.ToString() + "' already exist.");
        }

        public void Remove(Payment item)
        {
            List.Remove(item);
        }

        public void Remove(int id)
        {
            foreach (Payment child in List)
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

        public void AddRange(System.Collections.Generic.IEnumerable<Payment> aList)
        {
            foreach (Payment child in aList)
            {
                this.Add(child);
            }
        }

        public void AddRange(PaymentCollection aList)
        {
            foreach (Payment child in aList)
            {
                this.Add(child);
            }
        }

        #endregion //Business Properties and Methods

        #region Constructor
        private PaymentCollection()
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
            Payment child = Payment.NewPayment(0);
            child.PaymentDate = DateTime.Now;
            this.Add(child);
            return child;
        }

        #endregion//Overrides

        #region Criteria (identifies the Individual Object/ Primary Key)
        [Serializable]
        public class Criteria
        {
            public int ID = 0;
            public DateTime DateFrom = DateTime.MinValue;
            public DateTime DateTo = DateTime.MinValue;

            public Criteria()
            {
            }
        }
        #endregion //Criteria

        #region Static Methods

        public static PaymentCollection NewPaymentCollection()
        {
            return (PaymentCollection)DataPortal.Create(new Criteria());
        }

        public static PaymentCollection GetPaymentCollection()
        {
            return (PaymentCollection)DataPortal.Fetch(new Criteria());
        }

        public static PaymentCollection GetPaymentCollection(Criteria crit)
        {
            return (PaymentCollection)DataPortal.Fetch(crit);
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

            using (var cn = SQLiteConnectionBuilder.GetOpenedConnection())
            {
                try
                {
                    using (var tr = cn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        string query = @"
SELECT  
    [ID]
    ,[Sum]
    ,[CustomerID]
    ,PaymentDate
FROM [Payment] 
WHERE 1 = 1";
                        var parameters = new DynamicParameters();
                        if (crit.DateFrom != DateTime.MinValue)
                        {
                            query += " AND PaymentDate >= @DateFrom";
                            parameters.Add("@DateFrom", crit.DateFrom);
                        }

                        if (crit.DateTo != DateTime.MinValue)
                        {
                            query += " AND PaymentDate <= @DateTo";
                            parameters.Add("@DateTo", crit.DateTo);
                        }

                        AddRange(cn.Query<Payment>(query, parameters, tr).Do(c => c.MarkOld()));
                        tr.Commit();
                    }
                }
                catch (Exception e)
                {
                    throw;
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
                        foreach (Payment deletedChild in deletedList)
                        {
                            deletedChild.Update(tr);
                        }

                        // Then clear the list of deleted objects because they are truly gone now
                        deletedList.Clear();

                        // loop through each non-deleted child object and call its Update() method
                        foreach (Payment child in List)
                            child.Update(tr);

                        tr.Commit();
                    }
                }
                catch(Exception e)
                {

                }
            }
        }

        #endregion //Data Access

    }
}
