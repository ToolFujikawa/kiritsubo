using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class FinancialInstitutionBranch : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("支店")]
        public string Branch { get; set; }

        [DisplayName("フリガナ")]
        public string Furigana { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        [DisplayName("FIMS_Id")]
        public string FIMS_Id { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<Journal> JournalFinancialInstitutionBranches { get; set; }

        public virtual ICollection<Journal> JournalIssuedFinancialInstitutionBranches { get; set; }
    }
}