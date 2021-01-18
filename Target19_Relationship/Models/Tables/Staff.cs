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

        [DisplayName("����")]
        public bool IsActive { get; set; }

        [StringLength(45)]
        [DisplayName("��")]
        public string LastName { get; set; }

        [StringLength(45)]
        [DisplayName("���t���K�i")]
        public string LastNameFurigana { get; set; }

        [StringLength(45)]
        [DisplayName("��")]
        public string FirstName { get; set; }

        [StringLength(45)]
        [DisplayName("���t���K�i")]
        public string FirstNameFurigana { get; set; }

        [DisplayName("����")]
        [EnumDataType(typeof(Genders))]
        public Genders Gender_Id { get; set; }

        [DisplayName("���N����")]
        public DateTime Birthday { get; set; }

        [DisplayName("���Г�")]
        public DateTime HireDate { get; set; }

        [DisplayName("�ގГ�")]
        public DateTime LeaveDate { get; set; }

        [DisplayName("�d�b�ԍ�")]
        public string PhoneNo { get; set; }

        [DisplayName("�g�ѓd�b�ԍ�")]
        public string CellPhoneNo { get; set; }

        [DisplayName("�ݗ^�g�ѓd�b�ԍ�")]
        public string LentCellPhoneNo { get; set; }

        [DisplayName("�X�֔ԍ�")]
        public string ZIPCode { get; set; }

        [DisplayName("�s���{��")]
        [EnumDataType(typeof(Prefectures))]
        public Prefectures Prefecture { get; set; }

        [DisplayName("�s�撬��")]
        public string City { get; set; }

        [DisplayName("�Ԓn")]
        public string Address { get; set; }

        [DisplayName("�Ԓn�ȉ�")]
        public string StreetAddress { get; set; }

        [DisplayName("E���[���A�h���X")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("�ݗ^E���[���A�h���X")]
        [EmailAddress]
        public string LentEmailAddress { get; set; }

        [DisplayName("���l")]
        public string Note { get; set; }

        public string FIMS_Id { get; set; }

        [NotMapped]
        public string FullName { get; set; }

        //�i�r�Q�[�V�����v���p�e�B
        public virtual ICollection<GoodsIssue> GoodsIssueResponsibleStaffs { get; set; }

        public virtual ICollection<GoodsReceipt> GoodsReceiptResponsibleStaffs { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrderResponsibleStaffs { get; set; }

        public virtual ICollection<Quotation> QuotationResponsibleStaffs { get; set; }

        public virtual ICollection<SalesOrder> SalesOrderResponsibleStaffs { get; set; }

        public virtual ICollection<ShoppingBasket> ShoppingBasketResponsibleStaffs { get; set; }
    }
}
