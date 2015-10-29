using System.Data.SqlClient;

namespace BillingToolBox.Classes
{
    class BillingDecisionsConfiguration
    {
        public BillingDecisionsConfiguration(SqlDataReader reader)
        {
            ConfigurationType = reader["ConfigurationType"].ToString();
            Description = reader["Description"].ToString();
            DirectBillFlag = reader["DirectBillFlag"].ToString();
            AgencyBillFlag = reader["AgencyBillFlag"].ToString();
            AccountBillFlag = reader["AccountBillFlag"].ToString();
            EntityBillFlag = reader["EntityBillFlag"].ToString();
            PayrollDeductionFlag = reader["PayrollDeductionFlag"].ToString();
            Value = reader["Value"].ToString();
            AddedDateT = reader["AddedDateT"].ToString();
            AddedUserCode = reader["AddedUserCode"].ToString();
            LastUpdatedDateT = reader["LastUpdatedDateT"].ToString();
            LastUpdatedUserCode = reader["LastUpdatedUserCode"].ToString();
            NHDiscriminator = reader["NHDiscriminator"].ToString();
            EnabledFlag = reader["EnabledFlag"].ToString();
        }

        public string ConfigurationType { get; set; }
        public string Description { get; set; }
        public string DirectBillFlag { get; set; }
        public string AgencyBillFlag { get; set; }
        public string AccountBillFlag { get; set; }
        public string EntityBillFlag { get; set; }
        public string PayrollDeductionFlag { get; set; }
        public string Value { get; set; }
        public string AddedDateT { get; set; }
        public string AddedUserCode { get; set; }
        public string LastUpdatedDateT { get; set; }
        public string LastUpdatedUserCode { get; set; }
        public string NHDiscriminator { get; set; }
        public string EnabledFlag { get; set; }
    }
}
