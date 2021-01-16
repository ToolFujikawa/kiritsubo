using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class GoodsReceipt : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("勘定科目Id")]
        public int AccountTitle_Id { get; set; }

        [DisplayName("責任者Id")]
        public int ResponsibleStaff_Id { get; set; }

        [DisplayName("変動日")]
        public DateTime FluctuatingDate { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        //ナビゲーションプロパティ
        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; } 

        [ForeignKey("AccountTitle_Id")]
        public virtual AccountTitle AccountTitle { get; set; }

        [ForeignKey("ResponsibleStaff_Id")]
        public virtual Staff Staff { get; set; }
    }
}