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
        public int Gender { get; set; }

        [DisplayName("���N����")]
        public DateTime Birthday { get; set; }

        [DisplayName("�S���J�n��")]
        public DateTime HireDate { get; set; }

        [DisplayName("�S���I����")]
        public DateTime LeaveDate { get; set; }

        [DisplayName("�����Id")]
        public int BusinessPartner_Id { get; set; }

        [DisplayName("�g�ѓd�b�ԍ�")]
        public string CellPhoneNo { get; set; }

        [DisplayName("E���[���A�h���X")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("���l")]
        public string Note { get; set; }

        [NotMapped]
        public string FullName { get; set; }

        //�i���B�Q�[�V�����v���p�e�B
        public virtual ICollection<Quotation> Quotations { get; set; }

        [ForeignKey("Recorder_Id")]
        public virtual Staff Recorder { get; set; }

        [ForeignKey("Changer_Id")]
        public virtual Staff Changer { get; set; }
    }
}
