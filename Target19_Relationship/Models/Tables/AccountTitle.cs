using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class AccountTitle : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("勘定科目")]
        public string AccountName { get; set; }

        [DisplayName("ふりがな")]
        public string Furigana { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<GoodsIssue> GoodsIssues { get; set; }

        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; }

        public virtual ICollection<Journal> JournalDebits { get; set; }

        public virtual ICollection<Journal> JournalCredits { get; set; }
    }
}