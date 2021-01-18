using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Tables
{
    public partial class ShoppingBasket : CreationRecord
    {
        public ShoppingBasket()
        {
            Detail = "";
        }

        public int Id { get; set; }

        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [DisplayName("受注者Id")]
        public int ResponsibleStaff_Id { get; set; }

        [DisplayName("発注指示")]
        public string Detail { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("希望価格")]
        public decimal? AskingPrice { get; set; }

        [DisplayName("希望納期")]
        public DateTime? DeliveryDate { get; set; }

        [DisplayName("納期述語")]
        [EnumDataType(typeof(DeliveryDateInstructions))]
        public DeliveryDateInstructions DeliveryDateInstruction_Id { get; set; }

        [DisplayName("指定仕入先")]
        public int? DesignatedSupplier_Id { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        [DisplayName("受注Id")]
        public int SalesOrder_Id { get; set; }

        [DisplayName("受注詳細")]
        public string SalesOrderDetail { get; set; }

        //ナビゲーションプロパティ
        public SalesOrder SalesOrder { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }

        [ForeignKey("ResponsibleStaff_Id")]
        public virtual Staff ResponsibleStaff { get; set; }
    }
}