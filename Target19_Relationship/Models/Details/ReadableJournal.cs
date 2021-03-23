using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Details
{
    public class ReadableJournal
    {
        public int Id { get; set; }

        [DisplayName("記録日")]
        public DateTime AccountingDate { get; set; }

        [DisplayName("当座預金記録日")]
        public DateTime CurrentAccountReflectingDate { get; set; }

        [DisplayName("取引先Id")]
        public int BusinessPartner_Id { get; set; }

        [DisplayName("取引先")]
        public string BusinessPartner { get; set; }

        [DisplayName("貸方科目Id")]
        public int Credit_Id { get; set; }

        [DisplayName("貸方科目")]
        public string Credit { get; set; }

        [DisplayName("借方科目Id")]
        public int Debit_Id { get; set; }

        [DisplayName("借方科目")]
        public string Debit { get; set; }

        [DisplayName("合計")]
        public decimal Amount { get; set; }

        [DisplayName("消費税")]
        public decimal Tax { get; set; }

        [DisplayName("適用")]
        public string Apply { get; set; }

        [DisplayName("金融機関Id")]
        public int FinancialInstitution_Id { get; set; }

        [DisplayName("金融機関")]
        public string FinancialInstitution { get; set; }

        [DisplayName("金融機関支店Id")]
        public int FinancialInstitutionBranch_Id { get; set; }

        [DisplayName("金融機関支店")]
        public string FinancialInstitutionBranch { get; set; }

        [DisplayName("手形状態")]
        [EnumDataType(typeof(BillStatuses))]
        public BillStatuses BillStatuses { get; set; }

        [DisplayName("手形番号")]
        public string BillNo { get; set; }

        [DisplayName("支払期日")]
        public DateTime PaymentDate { get; set; }
        
        [DisplayName("手形発行金融機関Id")]
        public int IssuedFinancialInstitution_Id { get; set; }
        
        [DisplayName("手形発行金融機関")]
        public string IssuedFinancialInstitution { get; set; }

        [DisplayName("手形発行金融機関支店Id")]
        public int IssuedFinancialInstitutionBranch_Id { get; set; }

        [DisplayName("手形発行金融機関支店")]
        public string IssuedFinancialInstitutionBranch { get; set; }

        [DisplayName("裏書譲渡先Id")]
        public int Transferee_Id { get; set; }

        [DisplayName("裏書譲渡先")]
        public string Transferee { get; set; }

        [DisplayName("裏書譲渡日")]
        public DateTime EndorsementTransferDate { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        [DisplayName("記録者")]
        public string Recorder { get; set; }

        [DisplayName("更新者")]
        public string Changer { get; set; }

        public int FIMS_Id { get; set; }

    }
}