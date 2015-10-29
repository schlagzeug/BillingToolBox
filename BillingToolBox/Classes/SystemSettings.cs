using System.Data.SqlClient;

namespace BillingToolBox.Classes
{
    class SystemSettings
    {
        public SystemSettings(SqlDataReader reader)
        {
            SystemSettingsNum = reader["SystemSettingsNum"].ToString();
            CommissionReport1099BoxNo = reader["CommissionReport1099BoxNo"].ToString();
            ImagePath = reader["ImagePath"].ToString();
            MailMergePath = reader["MailMergePath"].ToString();
            AddedDateT = reader["AddedDateT"].ToString();
            AddedUserCode = reader["AddedUserCode"].ToString();
            LastUpdatedUserCode = reader["LastUpdatedUserCode"].ToString();
            LastUpdatedDateT = reader["LastUpdatedDateT"].ToString();
            EncryptFileYN = reader["EncryptFileYN"].ToString();
            BankAccountNo = reader["BankAccountNo"].ToString();
            CancelInactiveReasonCode = reader["CancelInactiveReasonCode"].ToString();
            NonRenewInactiveReasonCode = reader["NonRenewInactiveReasonCode"].ToString();
            ERPExpiredInactiveReasonCode = reader["ERPExpiredInactiveReasonCode"].ToString();
            ERPReversedInactiveReasonCode = reader["ERPReversedInactiveReasonCode"].ToString();
            GenerateAccountNoYN = reader["GenerateAccountNoYN"].ToString();
            AccountPrefix = reader["AccountPrefix"].ToString();
            FirstAccountNo = reader["FirstAccountNo"].ToString();
            LastAccountNo = reader["LastAccountNo"].ToString();
            LastUsedAccountNo = reader["LastUsedAccountNo"].ToString();
            PolicyPrefix = reader["PolicyPrefix"].ToString();
            FirstPolicyNo = reader["FirstPolicyNo"].ToString();
            LastPolicyNo = reader["LastPolicyNo"].ToString();
            LastUsedPolicyNo = reader["LastUsedPolicyNo"].ToString();
            ClaimPrefix = reader["ClaimPrefix"].ToString();
            FirstClaimNo = reader["FirstClaimNo"].ToString();
            LastClaimNo = reader["LastClaimNo"].ToString();
            LastUsedClaimNo = reader["LastUsedClaimNo"].ToString();
            AlwaysGenerateClaimNoYN = reader["AlwaysGenerateClaimNoYN"].ToString();
            AllowDeletePendingNewBusYN = reader["AllowDeletePendingNewBusYN"].ToString();
            AllowDeleteClaimFeatureYN = reader["AllowDeleteClaimFeatureYN"].ToString();
            AllowDeleteNotePadYN = reader["AllowDeleteNotePadYN"].ToString();
            AllowChangeNotePadYN = reader["AllowChangeNotePadYN"].ToString();
            ClaimIssueNotePadTypeCode = reader["ClaimIssueNotePadTypeCode"].ToString();
            AllowDeleteClaimYN = reader["AllowDeleteClaimYN"].ToString();
            EncryptDFINoInFileYN = reader["EncryptDFINoInFileYN"].ToString();
            ServerDateOverride = reader["ServerDateOverride"].ToString();
            MaxLoginAttempts = reader["MaxLoginAttempts"].ToString();
            ReportingServicesURL = reader["ReportingServicesURL"].ToString();
            CompanyCode = reader["CompanyCode"].ToString();
            ABANo = reader["ABANo"].ToString();
            DFINo = reader["DFINo"].ToString();
            ImmediateDestinationName = reader["ImmediateDestinationName"].ToString();
            OriginatorDFINo = reader["OriginatorDFINo"].ToString();
            DBBypassMonthEndPostCheckYN = reader["DBBypassMonthEndPostCheckYN"].ToString();
            TransactionAccountCode = reader["TransactionAccountCode"].ToString();
            TransactionTypeCode = reader["TransactionTypeCode"].ToString();
            ProgramCode = reader["ProgramCode"].ToString();
            PostPaymentImportYN = reader["PostPaymentImportYN"].ToString();
            SubSystemCode = reader["SubSystemCode"].ToString();
            MailMergeTempFilePath = reader["MailMergeTempFilePath"].ToString();
            DedlRecovTranAccount = reader["DedlRecovTranAccount"].ToString();
            DedlRecovTranType = reader["DedlRecovTranType"].ToString();
            AutomaticDueDateDays = reader["AutomaticDueDateDays"].ToString();
            LockBoxTransactionAccountCode = reader["LockBoxTransactionAccountCode"].ToString();
            LockBoxTransactionTypeCode = reader["LockBoxTransactionTypeCode"].ToString();
            InstallmentOffsetTranAccount = reader["InstallmentOffsetTranAccount"].ToString();
            InstallmentOffsetTranType = reader["InstallmentOffsetTranType"].ToString();
            RecoveryCode = reader["RecoveryCode"].ToString();
            UseShortBillYN = reader["UseShortBillYN"].ToString();
            UseRenewalQuotesYN = reader["UseRenewalQuotesYN"].ToString();
            DBAgentStatementSettlementYN = reader["DBAgentStatementSettlementYN"].ToString();
            DBFirstSettlementAfterMonths = reader["DBFirstSettlementAfterMonths"].ToString();
            DBSecondSettlementAfterMonths = reader["DBSecondSettlementAfterMonths"].ToString();
            DBThirdSettlementAfterMonths = reader["DBThirdSettlementAfterMonths"].ToString();
            DBAR1CorNotifyControlNum = reader["DBAR1CorNotifyControlNum"].ToString();
            DBAR2CorNotifyControlNum = reader["DBAR2CorNotifyControlNum"].ToString();
            DBAR3CorNotifyControlNum = reader["DBAR3CorNotifyControlNum"].ToString();
            DefaultCheckTypeToManualYN = reader["DefaultCheckTypeToManualYN"].ToString();
            SyncDedAccountNumberYN = reader["SyncDedAccountNumberYN"].ToString();
            DefaultRecoveryAssociate = reader["DefaultRecoveryAssociate"].ToString();
            AccountBillInsFeeMethod = reader["AccountBillInsFeeMethod"].ToString();
            ClientCode = reader["ClientCode"].ToString();
            JournalCommentsRequiredYN = reader["JournalCommentsRequiredYN"].ToString();
            BillingServiceURL = reader["BillingServiceURL"].ToString();
            ZipCodeValidateYN = reader["ZipCodeValidateYN"].ToString();
            MaxNSFCountBeforeDNA = reader["MaxNSFCountBeforeDNA"].ToString();
            PaymentSourceCodeBD = reader["PaymentSourceCodeBD"].ToString();
            NHDiscriminator = reader["NHDiscriminator"].ToString();
            UseEnterpriseActivityMgrYN = reader["UseEnterpriseActivityMgrYN"].ToString();
            EDBServerNm = reader["EDBServerNm"].ToString();
            EDBDBNm = reader["EDBDBNm"].ToString();
            ABReallocTransactionAccountCode = reader["ABReallocTransactionAccountCode"].ToString();
            ABReallocTransactionTypeCode = reader["ABReallocTransactionTypeCode"].ToString();
            RCCUseOriginalDueDateYN = reader["RCCUseOriginalDueDateYN"].ToString();
            ServiceBusEnabledYN = reader["ServiceBusEnabledYN"].ToString();
            MaxResubmitCount = reader["MaxResubmitCount"].ToString();
            PaymentForExportFunction = reader["PaymentForExportFunction"].ToString();
            DefaultReadyToReleaseYN = reader["DefaultReadyToReleaseYN"].ToString();
            ExternalPrintDirectory = reader["ExternalPrintDirectory"].ToString();
            PreProcessorXsltName = reader["PreProcessorXsltName"].ToString();
            PolicyToBillingXsltName = reader["PolicyToBillingXsltName"].ToString();
            ManualRescindCommentsRequiredYN = reader["ManualRescindCommentsRequiredYN"].ToString();
            EntityBillAltPayorDays = reader["EntityBillAltPayorDays"].ToString();
            AccountBillReminderNotice1Days = reader["AccountBillReminderNotice1Days"].ToString();
            AccountBillReminderNotice2Days = reader["AccountBillReminderNotice2Days"].ToString();
            AccountBillReminderNotice3Days = reader["AccountBillReminderNotice3Days"].ToString();
            UpdateCancellationEffectiveDateYN = reader["UpdateCancellationEffectiveDateYN"].ToString();
        }

        public string SystemSettingsNum { get; set; }
        public string CommissionReport1099BoxNo { get; set; }
        public string ImagePath { get; set; }
        public string MailMergePath { get; set; }
        public string AddedDateT { get; set; }
        public string AddedUserCode { get; set; }
        public string LastUpdatedUserCode { get; set; }
        public string LastUpdatedDateT { get; set; }
        public string EncryptFileYN { get; set; }
        public string BankAccountNo { get; set; }
        public string CancelInactiveReasonCode { get; set; }
        public string NonRenewInactiveReasonCode { get; set; }
        public string ERPExpiredInactiveReasonCode { get; set; }
        public string ERPReversedInactiveReasonCode { get; set; }
        public string GenerateAccountNoYN { get; set; }
        public string AccountPrefix { get; set; }
        public string FirstAccountNo { get; set; }
        public string LastAccountNo { get; set; }
        public string LastUsedAccountNo { get; set; }
        public string PolicyPrefix { get; set; }
        public string FirstPolicyNo { get; set; }
        public string LastPolicyNo { get; set; }
        public string LastUsedPolicyNo { get; set; }
        public string ClaimPrefix { get; set; }
        public string FirstClaimNo { get; set; }
        public string LastClaimNo { get; set; }
        public string LastUsedClaimNo { get; set; }
        public string AlwaysGenerateClaimNoYN { get; set; }
        public string AllowDeletePendingNewBusYN { get; set; }
        public string AllowDeleteClaimFeatureYN { get; set; }
        public string AllowDeleteNotePadYN { get; set; }
        public string AllowChangeNotePadYN { get; set; }
        public string ClaimIssueNotePadTypeCode { get; set; }
        public string AllowDeleteClaimYN { get; set; }
        public string EncryptDFINoInFileYN { get; set; }
        public string ServerDateOverride { get; set; }
        public string MaxLoginAttempts { get; set; }
        public string ReportingServicesURL { get; set; }
        public string CompanyCode { get; set; }
        public string ABANo { get; set; }
        public string DFINo { get; set; }
        public string ImmediateDestinationName { get; set; }
        public string OriginatorDFINo { get; set; }
        public string DBBypassMonthEndPostCheckYN { get; set; }
        public string TransactionAccountCode { get; set; }
        public string TransactionTypeCode { get; set; }
        public string ProgramCode { get; set; }
        public string PostPaymentImportYN { get; set; }
        public string SubSystemCode { get; set; }
        public string MailMergeTempFilePath { get; set; }
        public string DedlRecovTranAccount { get; set; }
        public string DedlRecovTranType { get; set; }
        public string AutomaticDueDateDays { get; set; }
        public string LockBoxTransactionAccountCode { get; set; }
        public string LockBoxTransactionTypeCode { get; set; }
        public string InstallmentOffsetTranAccount { get; set; }
        public string InstallmentOffsetTranType { get; set; }
        public string RecoveryCode { get; set; }
        public string UseShortBillYN { get; set; }
        public string UseRenewalQuotesYN { get; set; }
        public string DBAgentStatementSettlementYN { get; set; }
        public string DBFirstSettlementAfterMonths { get; set; }
        public string DBSecondSettlementAfterMonths { get; set; }
        public string DBThirdSettlementAfterMonths { get; set; }
        public string DBAR1CorNotifyControlNum { get; set; }
        public string DBAR2CorNotifyControlNum { get; set; }
        public string DBAR3CorNotifyControlNum { get; set; }
        public string DefaultCheckTypeToManualYN { get; set; }
        public string SyncDedAccountNumberYN { get; set; }
        public string DefaultRecoveryAssociate { get; set; }
        public string AccountBillInsFeeMethod { get; set; }
        public string ClientCode { get; set; }
        public string JournalCommentsRequiredYN { get; set; }
        public string BillingServiceURL { get; set; }
        public string ZipCodeValidateYN { get; set; }
        public string MaxNSFCountBeforeDNA { get; set; }
        public string PaymentSourceCodeBD { get; set; }
        public string NHDiscriminator { get; set; }
        public string UseEnterpriseActivityMgrYN { get; set; }
        public string EDBServerNm { get; set; }
        public string EDBDBNm { get; set; }
        public string ABReallocTransactionAccountCode { get; set; }
        public string ABReallocTransactionTypeCode { get; set; }
        public string RCCUseOriginalDueDateYN { get; set; }
        public string ServiceBusEnabledYN { get; set; }
        public string MaxResubmitCount { get; set; }
        public string PaymentForExportFunction { get; set; }
        public string DefaultReadyToReleaseYN { get; set; }
        public string ExternalPrintDirectory { get; set; }
        public string PreProcessorXsltName { get; set; }
        public string PolicyToBillingXsltName { get; set; }
        public string ManualRescindCommentsRequiredYN { get; set; }
        public string EntityBillAltPayorDays { get; set; }
        public string AccountBillReminderNotice1Days { get; set; }
        public string AccountBillReminderNotice2Days { get; set; }
        public string AccountBillReminderNotice3Days { get; set; }
        public string UpdateCancellationEffectiveDateYN { get; set; }
    }
}
