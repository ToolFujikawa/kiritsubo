using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Models
{
    public class CreationRecord
    {
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
    }
}