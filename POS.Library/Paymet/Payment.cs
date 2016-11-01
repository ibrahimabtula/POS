using CSLA;
using CSLA.Data;
using Dapper;
using System;
using System.Data;
using System.Data.SqlServerCe;

namespace POS.Library
{
    [Serializable]
    public class Payment : CSLA.BusinessBase
    {
        #region Class Level Private Variables

        private int _id = 0; //PK
        private decimal _sum = decimal.Zero;
        private int _customerId = 0;
        private DateTime _paymetDate = DateTime.MinValue;

        #endregion //Class Level Private Variables

        #region Constructors

        public Payment()
        {
            MarkAsChild();
        }

        #endregion //Constructors

        #region Business Properties and Methods

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public decimal Sum
        {
            get { return _sum; }
            set
            {
                _sum= value;
                MarkDirty();
            }
        }

        public int CustomerID
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                MarkDirty();
            }
        }

        public DateTime PaymentDate
        {
            get { return _paymetDate; }
            set { _paymetDate = value; }
        }

        public bool IsSaveable
        {
            //Since you cannot bind a control to multiple properties you need to create a property that combines the ones you need
            //In this case, bind the UI Save button Enabled property to IsSaveable. (Why save an object that has not changed?)
            get { return IsValid && IsDirty; }
        }

        #endregion //Business Properties and Methods

        #region System.Object Overrides

        public override string ToString()
        {
            return "Payment" + "/" + _id.ToString();
        }

        public bool Equals(Payment Payment)
        {
            return _id.Equals(Payment.ID);
        }

        public override int GetHashCode()
        {
            return ("Payment" + "/" + _id.ToString()).GetHashCode();
        }

        public new void MarkOld()
        {
            base.MarkOld();
        }

        #endregion //System.Object Overrides

        #region Static Methods

        public static Payment NewPayment(int id)
        {
            return (Payment)DataPortal.Create(new Criteria(id));
        }

        public static Payment GetPayment(Criteria crit)
        {
            return (Payment)DataPortal.Fetch(crit);
        }

        internal static Payment GetPayment(Criteria crit, SqlCeTransaction tr)
        {
            var child = NewPayment(0);
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
                using (var tr = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        DBFetch(crit, tr);
                        tr.Commit();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }
        }

        internal void DBFetch(Criteria crit, IDbTransaction tr)
        {
            if (!IsDirty) return;
            using (var cm = new SqlCeCommand())
            {
                  string query = @"
SELECT
    ID
    ,CustomerID
    ,Sum
    ,PaymentDate
FROM Payment
WHERE ID = @ID";

                var result = tr.Connection.QueryFirst<Payment>(query, this, tr);
                _id = result._id;
                _sum = result._sum;
                _customerId = result._customerId;
                _paymetDate = result._paymetDate;
            }
        }

        protected override void DataPortal_Update()
        {
            if (!IsDirty) return;
            using (var cn = SQLiteConnectionBuilder.GetOpenedConnection())
            {
                using (var tr = cn.BeginTransaction())
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
            var parameter = new DynamicParameters();

            if (this.IsDeleted)
            {
                //is deleted object, check if new
                if (!this.IsNew)
                {
                    query = "DELETE FROM Payment WHERE ID = @ID";
                    tr.Connection.Execute(query, new { ID = _id }, tr);
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
INSERT INTO [Payment]
([CustomerID],[Sum], PaymentDate) 
VALUES(@CustomerID,@Sum, @PaymentDate)";
                }
                else
                {
                    //perform an update, object is not new so object has already been persisted
                    query = @"
UPDATE Payment
SET 
    Sum = @Sum
    ,CustomerID = @CustomerID
    ,PaymentDate = @PaymentDate
WHERE ID = @ID";

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
            _id = dr.GetInt32("ID");
            _sum = dr.GetDecimal("Sum");
            _customerId = dr.GetInt32("CustomerID");
            _paymetDate = dr.GetDateTime("PaymentDate");

            MarkOld();
        }*/

        #endregion
    }
}
