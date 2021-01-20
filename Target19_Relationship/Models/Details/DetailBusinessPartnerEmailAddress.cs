using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Details
{
    public class DetailBusinessPartnerEmailAddress : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("取引先")]
        public string BusinessPartner { get; set; }

        [DisplayName("Eメールアドレス")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("優先順位")]
        public int Rank { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }
    }
}