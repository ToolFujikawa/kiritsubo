using Target19_Relationship.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Target19_Relationship.Models.Tables
{
    public partial class SalesOrder : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("中止")]
        public bool IsCancel { get; set; }

        [DisplayName("専用納品書")]
        public bool IsExclusiveDeliveryNote { get; set; }

        [DisplayName("受注明細")]
        public string Detail { get; set; }

        [DisplayName("受注者Id")]
        public int ResponsibleStaff_Id { get; set; }

        [DisplayName("発注者Id")]
        public int Helper_Id { get; set; }

        [DisplayName("受注先Id")]
        public int Customer_Id { get; set; }

        [DisplayName("納品場所Id")]
        public int DeliveryPlace_Id { get; set; }

        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("受注日")]
        public DateTime SalesOrderDate { get; set; }

        [DisplayName("注文主番号")]
        public string OrderMainNo { get; set; }

        [DisplayName("注文枝番号")]
        public string OrderBranchNo { get; set; }

        [DisplayName("発注済")]
        public bool IsParchase { get; set; }

        [DisplayName("分納可")]
        public bool IsSeparateDelivery { get; set; }

        [DisplayName("想定売上")]
        public decimal EstimatedSale { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public int FIMS_Id { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<Sale> Sales { get; set; }

        [ForeignKey("ResponsibleStaff_Id")]
        public virtual Staff ResponsibleStaff { get; set; }

        [ForeignKey("Helper_Id")]
        public virtual Helper Helper { get; set; }

        [ForeignKey("Customer_Id")]
        public virtual BusinessPartner BusinessPartner { get; set; }

        [ForeignKey("DeliveryPlace_Id")]
        public virtual DeliveryPlace DeliveryPlace { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }
    }
}