using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Views
{
    public partial class ReadableProductAttribute
    {
        [Key]
        [Column(Order = 0)]
        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [DisplayName("メーカー")]
        public string Manufacturer { get; set; }

        [Key]
        [Column(Order = 1)]
        [DisplayName("取引先Id")]
        public int BusinessPartner_Id { get; set; }

        [DisplayName("取引先")]
        public string BusinessPartner { get; set; }

        [DisplayName("表記")]
        public string Notation { get; set; }

        [DisplayName("コード番号")]
        public string Attribute { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        [DisplayName("登録者Id")]
        public int Recorder_Id { get; set; }

        [DisplayName("更新者Id")]
        public int Changer_Id { get; set; }

        [DisplayName("登録日")]
        public DateTime RecordingDate { get; set; }

        [DisplayName("登録時刻")]
        public TimeSpan RecordingTime { get; set; }

        [DisplayName("更新日")]
        public DateTime UpdateDate { get; set; }

        [DisplayName("更新時刻")]
        public TimeSpan UpdateTime { get; set; }

        [DisplayName("アクセス元")]
        public string AccessRoute { get; set; }

        public string SearchKey { get; set; }
    }
}