using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Models.Views
{
    public partial class BeforeWarehousing
    {
        public int Id { get; set; }

        [DisplayName("仕入先Id")]
        public int Supplier_Id { get; set; }

        [DisplayName("仕入先")]
        public string Supplier { get; set; }
        [DisplayName("メーカーId")]
        public int Manufacturer_Id { get; set; }
        [DisplayName("メーカーId")]
        public int Product_Id { get; set; }
        [DisplayName("メーカー")]
        public string Product { get; set; }
        [DisplayName("数量")]
        public int Quantity { get; set; }
        [DisplayName("単位")]
        public string Unit { get; set; }
        [DisplayName("発注詳細")]
        public string Detail { get; set; }
        [DisplayName("発注責任者Id")]
        public int ResponsibleStaff_Id { get; set; }
        [DisplayName("発注責任者")]
        public string ResponsibleStaff { get; set; }
        [DisplayName("発注日")]
        public DateTime PurchaseDate { get; set; }
        [DisplayName("発注手段")]
        public int PurchaseMethod_Id { get; set; }
        [DisplayName("納期")]
        public DateTime DeliveryDate { get; set; }
        [DisplayName("納期述語")]
        public int DeliveryDateInstruction_Id { get; set; }
        [DisplayName("希望価格")]
        public decimal AskingPrice { get; set; }
        [DisplayName("備考")]
        public string Note { get; set; }
        [DisplayName("受注Id")]
        public int SalesOrder_Id { get; set; }
        [DisplayName("受注詳細")]
        public string SalesOrderDetail { get; set; }
        [DisplayName("中止")]
        public int IsCancel { get; set; }
        [DisplayName("記録者Id")]
        public int Recorder_Id { get; set; }
        [DisplayName("更新者Id")]
        public int Changer_Id { get; set; }
        public string SearchKey { get; set; }
    }
}