using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class BusinessPartnerEMailAddress : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("取引先Id")]
        public int BusinessPartner_Id { get; set; }

        [DisplayName("Eメールアドレス")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("優先順位")]
        public int Rank { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        //ナビゲーションプロパティ
        [ForeignKey("BusinessPartner_Id")]
        public virtual BusinessPartner BusinessPartner { get; set; }

        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}