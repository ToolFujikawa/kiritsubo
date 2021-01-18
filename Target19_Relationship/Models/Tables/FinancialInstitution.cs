using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class FinancialInstitution : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("金融機関")]
        public string FinancialInstitutionName { get; set; }

        [DisplayName("フリガナ")]
        public string Furigana { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public string FIMS_Id { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<Journal> JournalFinancialInstitutions { get; set; }

        public virtual ICollection<Journal> JournalIssuedFinancialInstitutions { get; set; }
    }
}