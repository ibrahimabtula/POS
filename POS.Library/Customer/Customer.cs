using CSLA;
using CSLA.Data;
using Dapper;
using System;
using System.Data;
using System.Data.SqlServerCe;

namespace POS.Library
{
    [Serializable]
    public class Customer : BusinessBase
    {
        #region Class Level Private Variables

        private long _id = 0; //PK
        private string _fName = string.Empty;
        private string _lName = string.Empty;
        private string _note = string.Empty;

        #endregion //Class Level Private Variables

        #region Constructors

        public Customer()
        {
            MarkAsChild();
        }

        #endregion //Constructors

        #region Business Properties and Methods

        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _fName; }
            set
            {
                _fName= value;
                MarkDirty();
            }
        }

        public string LastName
        {
            get { return _lName; }
            set
            {
                _lName= value;
                MarkDirty();
            }
        }

        public string FullName
        {
            get { return _fName + " " + _lName; }
        }

        public string Note
        {
            get { return _note; }
            set
            {
                _note = value;
                MarkDirty();
            }
        }

        public bool IsSaveable
        {
            //Since you cannot bind a control to multiple properties you need to create a property that combines the ones you need
            //In this case, bind the UI Save button Enabled property to IsSaveable. (Why save an object that has not changed?)
            get { return IsValid && IsDirty; }
        }

        public new void MarkOld()
        {
            base.MarkOld();
        }

        #endregion //Business Properties and Methods

        #region System.Object Overrides

        public override string ToString()
        {
            return "Customer" + "/" + _id.ToString();
        }

        public bool Equals(Customer Customer)
        {
            return _id.Equals(Customer.ID);
        }

        public override int GetHashCode()
        {
            return ("Customer" + "/" + _id.ToString()).GetHashCode();
        }

        #endregion //System.Object Overrides

        #region Static Methods

        public static Customer NewCustomer(int id)
        {
            return (Customer)DataPortal.Create(new Criteria(id));
        }

        public static Customer GetCustomer(Criteria crit)
        {
            return (Customer)DataPortal.Fetch(crit);
        }

        internal static Customer GetCustomer(Criteria crit, SqlCeTransaction tr)
        {
            var child = NewCustomer(0);
            child.DBFetch(crit, tr);
            return child;
        }

        #endregion //Static Methods

        #region Criteria (identifies the Individual Object/ Primary Key)
        [System.Serializable]
        public class Criteria
        {

            public int ID = 0;//**PK

            public Criteria()
            {

            }
            public Criteria(int id)
            {
                this.ID = id;
            }
        }

        #endregion //Criteria

        #region Data Access
        //Called by DataPortal so that we can set defaults as needed
        protected override void DataPortal_Create(object criteria)
        {
            //Create new object with default stored in the database
            Criteria crit = (Criteria)criteria;
            _id = crit.ID;
            //CheckRules("");
        }

        //Called by DataPortal to load data from the database
        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;

            using (var cn = ConnectionBuilder.GetOpenedConnection())
            {
                using (var tr = cn.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        DBFetch(crit, tr);
                        tr.Commit();
                    }
                    catch (Exception e)
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
        }

        internal void DBFetch(Criteria crit, IDbTransaction tr)
        {
            if (!IsDirty) return;


                const string query = @"
SELECT
    ID
    ,FirstName
    ,LastName
    ,Note
FROM Customer
WHERE ID = @ID";
                Customer c = tr.Connection.QueryFirst<Customer>(query, this, tr);
                _id = c._id;
                _fName = c._fName;
                _lName = c._lName;
                _note = c._note; 
        }

        protected override void DataPortal_Update()
        {
            if (!IsDirty) return;
            using (var cn = SQLiteConnectionBuilder.GetOpenedConnection())
            {
                using (var tr = cn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        Update(tr);
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (tr.Connection != null) { tr.Rollback(); }
                        throw ex;
                    }
                }
            }
        }

        internal void Update(IDbTransaction tr)
        {
            if (!IsDirty) return;

            string query = string.Empty;         

            if (this.IsDeleted)
            {
                //is deleted object, check if new
                if (!this.IsNew)
                {    
                    query = "DELETE FROM Customer WHERE ID = @ID";
                    tr.Connection.Execute(query, new { ID = _id}, tr);     
                }
                // reset the object status to be new
                MarkNew();
            }
            else
            {
                // is not deleted object, check if this is an update or insert
                if (this.IsNew)
                {
                    query = @"
INSERT INTO [Customer]
([FirstName],[LastName],Note) 
VALUES(@FirstName, @LastName, @Note)";
                }
                else
                {
                    //perform an update, object is not new so object has already been persisted
                    query = @"
UPDATE [Customer]
SET 
    FirstName = @FirstName,
    LastName = @LastName,
    Note = @Note
WHERE ID = @ID";
                    //parameter.Add("@ID", _id);
                }

                if (IsNew)
                {
                    int rows = tr.Connection.Execute(query, this, tr);
                    tr.Connection.SetIdentity<int>(id => _id = id);
                }
                else
                {
                    tr.Connection.Execute(query, this, tr);
                }

                // update child object, passing the transaction
                // mark the object as old (persisted)
                MarkOld();
            }
        }

        /*public void Fetch(SafeDataReader dr, Criteria crit)
        {
            _id = dr.GetInt64("ID");
            _fName = dr.GetString("FirstName");
            _lName = dr.GetString("LastName");

            MarkOld();
        }*/

        #endregion
    }
}
