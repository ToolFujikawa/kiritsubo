using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Details;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Services.TransactionDatas
{
    public class JournalData
    {
        public List<ReadableJournal> GetSpecificWordGroup(string businessPartner, string debit, string credit, string keywords,
                                                    DateTime startDate, DateTime endDate)
        {
            List<ReadableJournal> readableJournals = new List<ReadableJournal>();
            string[] keywordArray = keywords.Split(new[] { ' ', '　' });
            using (DefaultConnection db = new DefaultConnection())
            {
                int openBusinessPartner_Id = BusinessPartnerData.NameToId(db, businessPartner)[0];
                int closeBusinessPartner_Id = BusinessPartnerData.NameToId(db, businessPartner)[1];
                int openDebit_Id = AccountTitleData.NameToId(db, debit)[0];
                int closeDebit_Id = AccountTitleData.NameToId(db, debit)[1];
                int openCredit_Id = AccountTitleData.NameToId(db, credit)[0];
                int closeCredit_Id = AccountTitleData.NameToId(db, credit)[1];
                var anonymous = db.Journals
                                    .Where(j => j.BusinessPartner_Id >= openBusinessPartner_Id
                                                && j.BusinessPartner_Id <= closeBusinessPartner_Id
                                                && j.Debit_Id >= openDebit_Id
                                                && j.Debit_Id <= closeDebit_Id
                                                && j.Credit_Id >= openCredit_Id
                                                && j.Credit_Id <= closeCredit_Id
                                                && j.AccountingDate >= startDate
                                                && j.AccountingDate <= endDate);

                foreach (var item in keywordArray)
                {
                    anonymous = anonymous
                                .Where(a => a.Apply.Contains(item));
                }

                readableJournals = anonymous
                                    .Select(a => new ReadableJournal
                                    {
                                        Id = a.Id,
                                        AccountingDate = a.AccountingDate,
                                        BusinessPartner_Id = a.BusinessPartner_Id,
                                        BusinessPartner = a.BusinessPartner.CommonName,
                                        Credit_Id = a.Credit_Id,
                                        Credit = a.CreditTitle.AccountName,
                                        Debit_Id = a.Debit_Id,
                                        Debit = a.DebitTitle.AccountName,
                                        Amount = a.Amount,
                                        Tax = a.Tax,
                                        Apply = a.Apply,
                                        FinancialInstitution_Id = a.FinancialInstitution_Id,
                                        FinancialInstitution = a.FinancialInstitution.FinancialInstitutionName,
                                        FinancialInstitutionBranch_Id = a.FinancialInstitutionBranch_Id,
                                        FinancialInstitutionBranch = a.FinancialInstitutionBranche.Branch,
                                        BillStatuses = a.BillStatuses,
                                        BillNo = a.BillNo,
                                        PaymentDate = a.PaymentDate,
                                        IssuedFinancialInstitution_Id = a.IssuedFinancialInstitution_Id,
                                        IssuedFinancialInstitution = a.IssuedFinancialInstitution.FinancialInstitutionName,
                                        IssuedFinancialInstitutionBranch_Id = a.IssuedFinancialInstitutionBranch_Id,
                                        IssuedFinancialInstitutionBranch = a.IssuedFinancialInstitutionBranche.Branch,
                                        Transferee_Id = a.Transferee_Id,
                                        Transferee = a.Transferee.CommonName,
                                        EndorsementTransferDate = a.EndorsementTransferDate,
                                        Note = a.Note
                                    })
                                    .ToList();

                return readableJournals;
            }

        }
    }
}