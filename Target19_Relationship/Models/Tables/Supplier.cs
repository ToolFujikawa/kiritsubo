using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class Supplier : CreationRecord
    {
        [Key]
        [Column(Order = 0)]
        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DisplayName("取引先Id")]
        public int Businesspartner_Id { get; set; }

        [DisplayName("特約店")]
        public bool IsDealer { get; set; }

        [DisplayName("順位")]
        public int Rank { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }
    }
}