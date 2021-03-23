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
            using (DefaultConnection db = new DefaultConnection())
            {
                int[] businessPartner_Ids = BusinessPartnerData.NameToId(db, businessPartner);
                int openBusinessPartner_Id = businessPartner_Ids[0];
                int closeBusinessPartner_Id = businessPartner_Ids[1];
                int[] debit_Ids = AccountTitleData.NameToId(db, debit);
                int openDebit_Id = debit_Ids[0];
                int closeDebit_Id = debit_Ids[1];
                int[] credit_Ids = AccountTitleData.NameToId(db, credit);
                int openCredit_Id = credit_Ids[0];
                int closeCredit_Id = credit_Ids[1];

                var anonymous = db.Journals
                                    .Where(j => j.BusinessPartner_Id >= openBusinessPartner_Id
                                                && j.BusinessPartner_Id <= closeBusinessPartner_Id
                                                && j.Debit_Id >= openDebit_Id
                                                && j.Debit_Id <= closeDebit_Id
                                                && j.Credit_Id >= openCredit_Id
                                                && j.Credit_Id <= closeCredit_Id
                                                && j.AccountingDate >= startDate
                                                && j.AccountingDate <= endDate)
                                    .Select(j => new
                                    {
                                        j.Id,
                                        j.AccountingDate,
                                        j.CurrentAccountReflectingDate,
                                        j.BusinessPartner_Id,
                                        j.BusinessPartner.CommonName,
                                        j.Credit_Id,
                                        Credit = j.CreditTitle.AccountName,
                                        j.Debit_Id,
                                        Debit = j.DebitTitle.AccountName,
                                        j.Amount,
                                        j.Tax,
                                        j.Apply,
                                        j.FinancialInstitution_Id,
                                        FinancialInstitution = j.FinancialInstitution.FinancialInstitutionName,
                                        j.FinancialInstitutionBranch_Id,
                                        FinancialInstitutionBranche = j.FinancialInstitutionBranche.Branch,
                                        j.BillStatus_Id,
                                        j.BillNo,
                                        j.PaymentDate,
                                        j.IssuedFinancialInstitution_Id,
                                        IssuedFinancialInstitution = j.IssuedFinancialInstitution.FinancialInstitutionName,
                                        j.IssuedFinancialInstitutionBranch_Id,
                                        IssuedFinancialInstitutionBranche = j.IssuedFinancialInstitutionBranche.Branch,
                                        j.Transferee_Id,
                                        Transferee = j.Transferee.CommonName,
                                        j.EndorsementTransferDate,
                                        j.Note
                                    })
                                   .ToList();
                if (String.IsNullOrEmpty(keywords))
                {
                    string[] keywordArray = keywords.Split(new[] { ' ', '　' });
                    foreach (var item in keywordArray)
                    {
                        anonymous = anonymous
                                    .Where(a => a.Apply.Contains(item))
                                    .ToList();
                    }
                }

                return anonymous
                        .OrderByDescending(a => a.AccountingDate)
                                    .Select(a => new ReadableJournal
                                    {
                                        Id = a.Id,
                                        AccountingDate = a.AccountingDate,
                                        BusinessPartner_Id = a.BusinessPartner_Id,
                                        BusinessPartner = a.CommonName,
                                        Credit_Id = a.Credit_Id,
                                        Credit = a.Credit,
                                        Debit_Id = a.Debit_Id,
                                        Debit = a.Debit,
                                        Amount = a.Amount,
                                        Tax = a.Tax,
                                        Apply = a.Apply,
                                        FinancialInstitution_Id = a.FinancialInstitution_Id,
                                        FinancialInstitution = a.FinancialInstitution,
                                        FinancialInstitutionBranch_Id = a.FinancialInstitutionBranch_Id,
                                        FinancialInstitutionBranch = a.FinancialInstitutionBranche,
                                        BillStatuses = a.BillStatus_Id,
                                        BillNo = a.BillNo,
                                        PaymentDate = a.PaymentDate,
                                        IssuedFinancialInstitution_Id = a.IssuedFinancialInstitution_Id,
                                        IssuedFinancialInstitution = a.IssuedFinancialInstitution,
                                        IssuedFinancialInstitutionBranch_Id = a.IssuedFinancialInstitutionBranch_Id,
                                        IssuedFinancialInstitutionBranch = a.IssuedFinancialInstitutionBranche,
                                        Transferee_Id = a.Transferee_Id,
                                        Transferee = a.Transferee,
                                        EndorsementTransferDate = a.EndorsementTransferDate,
                                        Note = a.Note
                                    })
                                    .ToList();
            }
        }
    }
}