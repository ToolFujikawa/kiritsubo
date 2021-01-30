using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Views
{
    public class ReadableGoodsIssue : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [DisplayName("商品")]
        public string Product { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("勘定科目Id")]
        public int AccountTitle_Id { get; set; }

        [DisplayName("勘定科目")]
        public int AccountTitle { get; set; }

        [DisplayName("責任者Id")]
        public int ResponsibleStaff_Id { get; set; }

        [DisplayName("責任者")]
        public string ResponsibleStaff { get; set; }

        [DisplayName("変動日")]
        public DateTime FluctuatingDate { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        [DisplayName("登録者")]
        public string Recorder { get; set; }

        [DisplayName("更新者")]
        public string Changer { get; set; }
    }
}