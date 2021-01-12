using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class AccountTitle : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("勘定科目")]
        public string AccountName { get; set; }

        [DisplayName("フリガナ")]
        public string Furigana { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public string FIMSId { get; set; }
    }
}