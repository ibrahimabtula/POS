using CSLA;
using CSLA.Data;
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

        internal void DBFetch(Criteria crit, SqlCeTransaction tr)
        {
            if (!IsDirty) return;
            using (var cm = new SqlCeCommand())
            {
                cm.Connection = (SqlCeConnection)tr.Connection;
                cm.CommandType = CommandType.Text;
                cm.Transaction = tr;
                cm.CommandText = @"
SELECT
    ID
    ,CustomerID
    ,Sum
    ,PaymentDate
FROM Payment
WHERE ID = @ID";
                cm.Parameters.AddWithValue("@ID", crit.ID);

                using (var dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
                    {
                        Fetch(dr, crit);
                    }
                }
            }
        }

        protected override void DataPortal_Update()
        {
            if (!IsDirty) return;
            SqlCeConnection cn = ConnectionBuilder.GetConnection();
            SqlCeCommand cm = new SqlCeCommand();
            SqlCeTransaction tr;

            try
            {
                cn.Open();
               // Common.RaiseError(Common.MarisanErrors.None, Convert.ToInt32(MarisanProcessControl.Common.MachineType));
            }
            catch
            {
               // Common.RaiseError(Common.MarisanErrors.NoConnectionWithServer, Convert.ToInt32(MarisanProcessControl.Common.MachineType));
                return;
            }
            try
            {
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
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
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cn.Close();
            }
        }

        internal void Update(SqlCeTransaction tr)
        {
            if (!IsDirty) return;
            SqlCeCommand cm = new SqlCeCommand();
            cm.Connection = (SqlCeConnection)tr.Connection;
            cm.Transaction = tr;
            cm.CommandType = CommandType.Text;

            if (this.IsDeleted)
            {
                //is deleted object, check if new
                if (!this.IsNew)
                {
                    cm.CommandText = "DELETE FROM Payment WHERE ID = @ID";//"UPDATE Payment SET IsDeleted = 1 WHERE ID = @ID";
                    cm.Parameters.AddWithValue("@ID", _id);

                    cm.ExecuteNonQuery();
                }
                // reset the object status to be new
                MarkNew();
            }
            else
            {
                // is not deleted object, check if this is an update or insert
                if (this.IsNew)
                {
                    cm.CommandText = @"
INSERT INTO [Payment ]
([CustomerID],[Sum], PaymentDate) 
VALUES(@CustomerID,@Sum, @PaymentDate)";
                }
                else
                {
                    //perform an update, object is not new so object has already been persisted
                    cm.CommandText = @"
UPDATE Payment
SET 
    Sum = @Sum
    ,CustomerID = @CustomerID
    ,PaymentDate = @PaymentDate
WHERE ID = @ID";
                    cm.Parameters.AddWithValue("@ID", _id);
                }
                cm.Parameters.AddWithValue("@Sum", Sum);
                cm.Parameters.AddWithValue("@CustomerID", CustomerID);
                cm.Parameters.AddWithValue("@PaymentDate", new SmartDate(PaymentDate).DBValue);

                if (IsNew)
                {
                    cm.ExecuteNonQuery();
                    cm.CommandText = "select @@IDENTITY";
                    _id = Convert.ToInt32(cm.ExecuteScalar());
                }
                else
                {
                    cm.ExecuteNonQuery();
                }

                // update child object, passing the transaction


                // mark the object as old (persisted)
                MarkOld();
            }
        }

        public void Fetch(SafeDataReader dr, Criteria crit)
        {
            _id = dr.GetInt32("ID");
            _sum = dr.GetDecimal("Sum");
            _customerId = dr.GetInt32("CustomerID");
            _paymetDate = dr.GetDateTime("PaymentDate");

            MarkOld();
        }

        #endregion
    }
}
