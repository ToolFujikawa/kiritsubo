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
        public virtual ICollection<AccountTitle> AccountTitleRecorders { get; set; }
        public virtual ICollection<AccountTitle> AccountTitleChangers { get; set; }

        public virtual ICollection<BusinessPartner> BusinessPartnerChangers { get; set; }
        public virtual ICollection<BusinessPartner> BusinessPartnerRecorders { get; set; }

        public virtual ICollection<BusinessPartnerEMailAddress> BusinessPartnerEMailAddressChangers { get; set; }
        public virtual ICollection<BusinessPartnerEMailAddress> BusinessPartnerEMailAddressRecorders { get; set; }

        public virtual ICollection<DeliveryPlace> DeliveryPlaceChanger { get; set; }
        public virtual ICollection<DeliveryPlace> DeliveryPlaceRecorderr { get; set; }

        public virtual ICollection<FinancialInstitution> FinancialInstitutionChangers { get; set; }
        public virtual ICollection<FinancialInstitution> FinancialInstitutionRecorders { get; set; }

        public virtual ICollection<FinancialInstitutionBranche> FinancialInstitutionBrancheChangers { get; set; }
        public virtual ICollection<FinancialInstitutionBranche> FinancialInstitutionBrancheRecorders { get; set; }

        public virtual ICollection<GoodsIssue> GoodsIssueChangers { get; set; }
        public virtual ICollection<GoodsIssue> GoodsIssueRecorders { get; set; }
        public virtual ICollection<GoodsIssue> GoodsIssueResponsibleStaffs { get; set; }

        public virtual ICollection<GoodsReceipt> GoodsReceiptChangers { get; set; }
        public virtual ICollection<GoodsReceipt> GoodsReceiptRecorders { get; set; }
        public virtual ICollection<GoodsReceipt> GoodsReceiptResponsibleStaffs { get; set; }

        public virtual ICollection<Helper> HelperChanger { get; set; }
        public virtual ICollection<Helper> HelperRecorderr { get; set; }

        public virtual ICollection<Journal> JournalChanger { get; set; }
        public virtual ICollection<Journal> JournalRecorderr { get; set; }

        public virtual ICollection<Manufacturer> ManufacturerChanger { get; set; }
        public virtual ICollection<Manufacturer> ManufacturerRecorderr { get; set; }

        public virtual ICollection<Product> ProductChangers { get; set; }
        public virtual ICollection<Product> ProductRecorders { get; set; }

        public virtual ICollection<Quotation> Quotations { get; set; }

    }
}
