using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class Journal : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("記録日")]
        public DateTime AccountingDate { get; set; }

        [DisplayName("当座預金記録日")]
        public DateTime CurrentAccountReflectingDate { get; set; }

        [DisplayName("取引先Id")]
        public int BusinessPartner_Id { get; set; }

        [DisplayName("貸方科目Id")]
        public int Credit_Id { get; set; }

        [DisplayName("借方科目Id")]
        public int Debit_Id { get; set; }

        [DisplayName("合計")]
        public decimal Amount { get; set; }

        [DisplayName("消費税")]
        public decimal Tax { get; set; }

        [DisplayName("適用")]
        public string Apply { get; set; }

        [DisplayName("金融機関Id")]
        public int FinancialInstitution_Id { get; set; }

        [DisplayName("金融機関支店Id")]
        public int FinancialInstitutionBranch_Id { get; set; }

        [DisplayName("手形状態")]
        public int BillStatuse { get; set; }

        [DisplayName("手形番号")]
        public string BillNo { get; set; }

        [DisplayName("支払期日")]
        public DateTime PaymentDate { get; set; }
        
        [DisplayName("手形発行金融機関Id")]
        public int IssuedFinancialInstitution_Id { get; set; }

        [DisplayName("手形発行金融機関支店Id")]
        public int IssuedFinancialInstitutionBranch_Id { get; set; }

        [DisplayName("裏書譲渡先Id")]
        public int Transferee_Id { get; set; }

        [DisplayName("裏書譲渡日")]
        public DateTime EndorsementTransferDate { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public int FIMS_Id { get; set; }

        //ナビゲーションプロパティ
        [ForeignKey("BusinessPartner_Id")]
        public virtual BusinessPartner BusinessPartner { get; set; }

        [ForeignKey("Debit_Id")]
        public virtual AccountTitle DebitTitle { get; set; }

        [ForeignKey("Credit_Id")]
        public virtual AccountTitle CreditTitle { get; set; }

        [ForeignKey("FinancialInstitution_Id")]
        public virtual FinancialInstitution FinancialInstitution { get; set; }

        [ForeignKey("FinancialInstitutionBranch_Id")]
        public virtual FinancialInstitutionBranch FinancialInstitutionBranche { get; set; }

        [ForeignKey("IssuedFinancialInstitution_Id")]
        public virtual FinancialInstitution IssuedFinancialInstitution { get; set; }

        [ForeignKey("IssuedFinancialInstitutionBranch_Id")]
        public virtual FinancialInstitutionBranch IssuedFinancialInstitutionBranche { get; set; }

        [ForeignKey("Transferee_Id")]
        public virtual BusinessPartner Transferee { get; set; }
    }
}