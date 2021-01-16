using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace Target19_Relationship.Models.Tables
{
    public partial class Helper : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("現役")]
        public bool IsActive { get; set; }

        [StringLength(45)]
        [DisplayName("姓")]
        public string LastName { get; set; }

        [StringLength(45)]
        [DisplayName("姓フリガナ")]
        public string LastNameFurigana { get; set; }

        [StringLength(45)]
        [DisplayName("名")]
        public string FirstName { get; set; }

        [StringLength(45)]
        [DisplayName("名フリガナ")]
        public string FirstNameFurigana { get; set; }

        [DisplayName("性別")]
        public int Gender { get; set; }

        [DisplayName("生年月日")]
        public DateTime Birthday { get; set; }

        [DisplayName("担当開始日")]
        public DateTime HireDate { get; set; }

        [DisplayName("担当終了日")]
        public DateTime LeaveDate { get; set; }

        [DisplayName("取引先Id")]
        public int BusinessPartner_Id { get; set; }

        [DisplayName("携帯電話番号")]
        public string CellPhoneNo { get; set; }

        [DisplayName("Eメールアドレス")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        [NotMapped]
        public string FullName { get; set; }

        //ナヴィゲーションプロパティ
        public virtual ICollection<Quotation> Quotations { get; set; }

        [ForeignKey("Recorder_Id")]
        public virtual Staff Recorder { get; set; }

        [ForeignKey("Changer_Id")]
        public virtual Staff Changer { get; set; }
    }
}
