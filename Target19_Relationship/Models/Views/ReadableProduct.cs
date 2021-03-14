using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Views
{
    public partial class ReadableProduct : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("未確定商品名")]
        public string Pseudonym { get; set; }

        public int Manufacturer_Id { get; set; }

        [DisplayName("商品")]
        public string Product { get; set; }

        [DisplayName("取引単位")]
        public string Unit { get; set; }

        [DisplayName("在庫量")]
        public int Quantity { get; set; }

        [DisplayName("在庫下限量")]
        public int LowerLimitQuantity { get; set; }

        [DisplayName("発注量")]
        public int OrderQuantity { get; set; }

        [DisplayName("適用税率")]
        public int TaxRate { get; set; }

        [DisplayName("原価")]
        public decimal Cost { get; set; }

        [DisplayName("評価額")]
        public decimal Valuation { get; set; }

        [DisplayName("在庫管理外")]
        public bool IsUnmanaged { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }
    }
}