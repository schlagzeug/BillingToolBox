using System.Data.SqlClient;

namespace BillingToolBox.Classes
{
    public class ProcessControl : ITable
    {
        public ProcessControl(SqlDataReader reader)
        {
            ProcessControlNum = reader["ProcessControlNum"].ToString();
            PMDailyRunYN = reader["PMDailyRunYN"].ToString();
            PMMonthlyRunYN = reader["PMMonthlyRunYN"].ToString();
            DBInterfaceYN = reader["DBInterfaceYN"].ToString();
            DBEFTExportYN = reader["DBEFTExportYN"].ToString();
            DBEFTImportYN = reader["DBEFTImportYN"].ToString();
            DBDebitCreditExportYN = reader["DBDebitCreditExportYN"].ToString();
            DBDebitCreditImportYN = reader["DBDebitCreditImportYN"].ToString();
            DBDailyRunYN = reader["DBDailyRunYN"].ToString();
            DBMonthlyRunYN = reader["DBMonthlyRunYN"].ToString();
            DBPolicyImportYN = reader["DBPolicyImportYN"].ToString();
            CheckIssuanceBatchYN = reader["CheckIssuanceBatchYN"].ToString();
            ClaimMonthlyRunYN = reader["ClaimMonthlyRunYN"].ToString();
            AgencyBillInterfaceYN = reader["AgencyBillInterfaceYN"].ToString();
            AgencyBillMonthlyRunYN = reader["AgencyBillMonthlyRunYN"].ToString();
            AgencyBillPolicyImportYN = reader["AgencyBillPolicyImportYN"].ToString();
            MGAInterfaceYN = reader["MGAInterfaceYN"].ToString();
            MGAMonthlyRunYN = reader["MGAMonthlyRunYN"].ToString();
            MVRImportYN = reader["MVRImportYN"].ToString();
            MVRExportYN = reader["MVRExportYN"].ToString();
            GBExportYN = reader["GBExportYN"].ToString();
            AddedDateT = reader["AddedDateT"].ToString();
            AddedUserCode = reader["AddedUserCode"].ToString();
            LastUpdatedUserCode = reader["LastUpdatedUserCode"].ToString();
            LastUpdatedDateT = reader["LastUpdatedDateT"].ToString();
            DBLockBoxImportYN = reader["DBLockBoxImportYN"].ToString();
            CorrespondenceBatchYN = reader["CorrespondenceBatchYN"].ToString();
            PolicyDMVExportYN = reader["PolicyDMVExportYN"].ToString();
            PolicyExportYN = reader["PolicyExportYN"].ToString();
            LossExportYN = reader["LossExportYN"].ToString();
            VINImportYN = reader["VINImportYN"].ToString();
            DRDailyRunYN = reader["DRDailyRunYN"].ToString();
            DeductibleRecoveryMonthlyRunYN = reader["DeductibleRecoveryMonthlyRunYN"].ToString();
            ACBLockBoxImportYN = reader["ACBLockBoxImportYN"].ToString();
            DNAExportYN = reader["DNAExportYN"].ToString();
            DBPaymentExportYN = reader["DBPaymentExportYN"].ToString();
            DBGLExportYN = reader["DBGLExportYN"].ToString();
            ABPaymentImportYN = reader["ABPaymentImportYN"].ToString();
            DBPaymentImportYN = reader["DBPaymentImportYN"].ToString();
            RDEquityDateUpdateYN = reader["RDEquityDateUpdateYN"].ToString();
            NHDiscriminator = reader["NHDiscriminator"].ToString();
            CollectionExportYN = reader["CollectionExportYN"].ToString();
            PolicyTransactionImportManagerDateT = reader["PolicyTransactionImportManagerDateT"].ToString();
            EntityBillPolicyImportYN = reader["EntityBillPolicyImportYN"].ToString();
            EntityBillInterfaceYN = reader["EntityBillInterfaceYN"].ToString();
            CheckDisbursementExportYN = reader["CheckDisbursementExportYN"].ToString();
            CheckDisbursementImportYN = reader["CheckDisbursementImportYN"].ToString();
            CancelledPolicyExportYN = reader["CancelledPolicyExportYN"].ToString();
            PDPaymentImportYN = reader["PDPaymentImportYN"].ToString();
        }

        public string ProcessControlNum { get; set; }
        public string PMDailyRunYN { get; set; }
        public string PMMonthlyRunYN { get; set; }
        public string DBInterfaceYN { get; set; }
        public string DBEFTExportYN { get; set; }
        public string DBEFTImportYN { get; set; }
        public string DBDebitCreditExportYN { get; set; }
        public string DBDebitCreditImportYN { get; set; }
        public string DBDailyRunYN { get; set; }
        public string DBMonthlyRunYN { get; set; }
        public string DBPolicyImportYN { get; set; }
        public string CheckIssuanceBatchYN { get; set; }
        public string ClaimMonthlyRunYN { get; set; }
        public string AgencyBillInterfaceYN { get; set; }
        public string AgencyBillMonthlyRunYN { get; set; }
        public string AgencyBillPolicyImportYN { get; set; }
        public string MGAInterfaceYN { get; set; }
        public string MGAMonthlyRunYN { get; set; }
        public string MVRImportYN { get; set; }
        public string MVRExportYN { get; set; }
        public string GBExportYN { get; set; }
        public string AddedDateT { get; set; }
        public string AddedUserCode { get; set; }
        public string LastUpdatedUserCode { get; set; }
        public string LastUpdatedDateT { get; set; }
        public string DBLockBoxImportYN { get; set; }
        public string CorrespondenceBatchYN { get; set; }
        public string PolicyDMVExportYN { get; set; }
        public string PolicyExportYN { get; set; }
        public string LossExportYN { get; set; }
        public string VINImportYN { get; set; }
        public string DRDailyRunYN { get; set; }
        public string DeductibleRecoveryMonthlyRunYN { get; set; }
        public string ACBLockBoxImportYN { get; set; }
        public string DNAExportYN { get; set; }
        public string DBPaymentExportYN { get; set; }
        public string DBGLExportYN { get; set; }
        public string ABPaymentImportYN { get; set; }
        public string DBPaymentImportYN { get; set; }
        public string RDEquityDateUpdateYN { get; set; }
        public string NHDiscriminator { get; set; }
        public string CollectionExportYN { get; set; }
        public string PolicyTransactionImportManagerDateT { get; set; }
        public string EntityBillPolicyImportYN { get; set; }
        public string EntityBillInterfaceYN { get; set; }
        public string CheckDisbursementExportYN { get; set; }
        public string CheckDisbursementImportYN { get; set; }
        public string CancelledPolicyExportYN { get; set; }
        public string PDPaymentImportYN { get; set; }
    }
}
