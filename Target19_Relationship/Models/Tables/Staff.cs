using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Tables
{
    public partial class Staff : CreationRecord
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
        [EnumDataType(typeof(Genders))]
        public Genders Gender_Id { get; set; }

        [DisplayName("生年月日")]
        public DateTime Birthday { get; set; }

        [DisplayName("入社日")]
        public DateTime HireDate { get; set; }

        [DisplayName("退社日")]
        public DateTime LeaveDate { get; set; }

        [DisplayName("電話番号")]
        public string PhoneNo { get; set; }

        [DisplayName("携帯電話番号")]
        public string CellPhoneNo { get; set; }

        [DisplayName("貸与携帯電話番号")]
        public string LentCellPhoneNo { get; set; }

        [DisplayName("郵便番号")]
        public string ZIPCode { get; set; }

        [DisplayName("都道府県")]
        [EnumDataType(typeof(Prefectures))]
        public Prefectures Prefecture { get; set; }

        [DisplayName("市区町村")]
        public string City { get; set; }

        [DisplayName("番地")]
        public string Address { get; set; }

        [DisplayName("番地以下")]
        public string StreetAddress { get; set; }

        [DisplayName("Eメールアドレス")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("貸与Eメールアドレス")]
        [EmailAddress]
        public string LentEmailAddress { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public string FIMS_Id { get; set; }

        [NotMapped]
        public string FullName { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<GoodsIssue> GoodsIssueResponsibleStaffs { get; set; }

        public virtual ICollection<GoodsReceipt> GoodsReceiptResponsibleStaffs { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrderResponsibleStaffs { get; set; }

        public virtual ICollection<Quotation> QuotationResponsibleStaffs { get; set; }

        public virtual ICollection<SalesOrder> SalesOrderResponsibleStaffs { get; set; }

        public virtual ICollection<ShoppingBasket> ShoppingBasketResponsibleStaffs { get; set; }
    }
}
