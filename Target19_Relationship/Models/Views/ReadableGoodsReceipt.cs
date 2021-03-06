using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Views
{
    public class ReadableGoodsReceipt
    {
        public int Id { get; set; }

        public int Manufacturer_Id { get; set; }

        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [DisplayName("商品")]
        public string Product { get; set; }

        [DisplayName("数量")]
        public string Quantity { get; set; }

        [DisplayName("勘定科目Id")]
        public int AccountTitle_Id { get; set; }

        [DisplayName("勘定科目")]
        public string AccountTitle { get; set; }

        [DisplayName("責任者Id")]
        public int ResponsibleStaff_Id { get; set; }

        [DisplayName("責任者")]
        public string ResponsibleStaff { get; set; }

        [DisplayName("変動日")]
        public DateTime FluctuatingDate { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public string SearchKey { get; set; }
    }
}