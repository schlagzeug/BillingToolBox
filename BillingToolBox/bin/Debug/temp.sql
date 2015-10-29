USING AXTestBilling
SELECT PolicyJournalNum, * FROM DailyRunDBLog WHERE PolicyJournalNum = '123456'
SELECT PolicyJournalNum, * FROM DirectBillAR WHERE PolicyJournalNum = '123456'
SELECT PolicyJournalNum, * FROM DirectBillARAlloc WHERE PolicyJournalNum = '123456'
SELECT PolicyJournalNum, * FROM PolicyJournal WHERE PolicyJournalNum = '123456'
