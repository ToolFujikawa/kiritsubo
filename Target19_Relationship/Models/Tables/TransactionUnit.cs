using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public class TransactionUnit : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("単位")]
        public string Unit { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public string FIMS_Id { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<Product> Products { get; set; }
    }
}