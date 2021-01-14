﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class GoodsIssue : CreationRecord
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
    }
}