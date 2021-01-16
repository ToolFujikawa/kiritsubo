using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class DeliveryPlace : CreationRecord
    {
        public int Id { get; set; }
        
        [DisplayName("場所")]
        public string Location { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        //ナビゲーションプロパティ
        [ForeignKey("Recorder_Id")]
        public virtual Staff Recorder { get; set; }

        [ForeignKey("Changer_Id")]
        public virtual Staff Changer { get; set; }
    }
}