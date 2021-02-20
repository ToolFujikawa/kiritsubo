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
    public partial class Product : CreationRecord
    {
        public Product()
        {
            //引数付きのコンストラクタがあるとき、引数なしのコンストラクタが無いとLINQの検索でエラー発生します。
        }

        public Product(string pseudonym, int recorder_Id)
        {
            Manufacturer_Id = 1;
            Pseudonym = pseudonym;
            ProductName = "新規";
            Material = "";
            Model = "";
            Quantity = 0;
            LowerLimitQuantity = 0;
            OrderQuantity = 0;
            TaxRate = 10;
            TransactionUnit_Id = 1;
            Cost = 0;
            Valuation = 0;
            Note = "";
            IsUnmanaged = false;
            Recorder_Id = recorder_Id;
            Changer_Id = 1;
            RecordingDate = DateTime.Now.Date;
            RecordingTime = DateTime.Now.TimeOfDay;
            UpdateDate = DateTime.Parse("9999-12-31");
            UpdateTime = TimeSpan.Parse("00:00:00");
            AccessRoute = "";
        }

        public int Id { get; set; }

        [DisplayName("メーカーId")]
        public int Manufacturer_Id { get; set; }

        [DisplayName("未確定商品名")]
        public string Pseudonym { get; set; }

        [DisplayName("品名")]
        public string ProductName { get; set; }

        [DisplayName("材質")]
        public string Material { get; set; }

        [DisplayName("型式")]
        public string Model { get; set; }

        [DisplayName("在庫量")]
        public int Quantity { get; set; }

        [DisplayName("在庫下限量")]
        public int LowerLimitQuantity { get; set; }

        [DisplayName("発注量")]
        public int OrderQuantity { get; set; }

        [DisplayName("適用税率")]
        public int TaxRate { get; set; }

        [DisplayName("取引単位")]
        public int TransactionUnit_Id { get; set; }

        [DisplayName("原価")]
        public decimal Cost { get; set; }

        [DisplayName("評価額")]
        public decimal Valuation { get; set; }

        [DisplayName("在庫管理外")]
        public bool IsUnmanaged { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        [NotMapped]
        public string SearchKey { get; set; }

        [NotMapped]
        public int FIMS_Id { get; set; }

        [NotMapped]
        public string MAKER_Id { get; set; }

        [NotMapped]
        public string CREATER_Id { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<GoodsIssue> GoodsIssues { get; set; }

        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; }

        public virtual ICollection<BusinessPartner> BusinessPartners { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        public virtual ICollection<Quotation> Quotations { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }

        public virtual ICollection<ShoppingBasket> ShoppingBaskets { get; set; }

        [ForeignKey("Manufacturer_Id")]
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("TransactionUnit_Id")]
        public virtual TransactionUnit TransactionUnit { get; set; }
    }
}