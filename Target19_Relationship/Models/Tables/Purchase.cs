using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class Purchase : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("発注Id")]
        public int PurchaseOrder_Id { get; set; }

        [DisplayName("入庫日")]
        public DateTime ReceiptDate { get; set; }

        [DisplayName("被請求日")]
        public DateTime BilledDate { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("単価")]
        public decimal UnitPrice { get; set; }

        [DisplayName("適用税率")]
        public int TaxRate { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public int FIMS_Id { get; set; }
    }
}