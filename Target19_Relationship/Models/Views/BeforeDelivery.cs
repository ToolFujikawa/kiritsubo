using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Views
{
    public partial class BeforeDelivery
    {
        public int Id { get; set; }

        [DisplayName("中止")]
        public bool IsCancel { get; set; }

        [DisplayName("専用納品書")]
        public bool IsExclusiveDeliveryNote { get; set; }
        [DisplayName("受注明細")]
        public string Detail { get; set; }
        public int ResponsibleStaff_Id { get; set; }
        [DisplayName("受注者")]
        public string ResponsibleStaff { get; set; }
        public int Helper_Id { get; set; }
        [DisplayName("販売先担当者")]
        public string Helper { get; set; }
        public int Customer_Id { get; set; }
        [DisplayName("販売先")]
        public string Customer { get; set; }
        public int DeliveryPlace_Id { get; set; }
        [DisplayName("納品場所")]
        public string DeliveryPlace { get; set; }
        public int Product_Id { get; set; }
        [DisplayName("商品")]
        public string Product { get; set; }
        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("単位")]
        public string Unit { get; set; }
        [DisplayName("受注日")]
        public DateTime SalesOrderDate { get; set; }
        [DisplayName("注文主番号")]
        public string OrderMainNo { get; set; }
        [DisplayName("注文枝番号")]
        public string OrderBranchNo { get; set; }
        [DisplayName("発注済み")]
        public bool IsParchase { get; set; }
        [DisplayName("分納可")]
        public bool IsSeparateDelivery { get; set; }
        [DisplayName("想定売上単価")]
        public decimal EstimatedSale { get; set; }
        [DisplayName("備考")]
        public string Note { get; set; }
    }
}