using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Target19_Relationship.Models.Tables
{
    public partial class Manufacturer : CreationRecord
    {
        const string str = "[^ａ-ｚＡ-Ｚ０-９ｱ-ﾝ]" + 
                            "㈱" + 
                            "*";

        public int Id { get; set; }

        [DisplayName("正式社名")]
        [RegularExpression(str, ErrorMessage = "{0}に全角英数、半角カタカナ文字は使用できません。")]
        public string FormalName { get; set; }

        [DisplayName("一般社名")]
        public string CommonName { get; set; }

        [DisplayName("フリガナ")]
        public string Furigana { get; set; }

        [DisplayName("英語名")]
        public string EnglishName { get; set; }

        [DisplayName("郵便番号")]
        public string ZIPCode { get; set; }

        [DisplayName("都道府県")]
        public string Prefecture { get; set; }

        [DisplayName("市区町村")]
        public string City { get; set; }

        [DisplayName("番地")]
        public string Address { get; set; }

        [DisplayName("番地以降")]
        public string StreetAddress { get; set; }

        [DisplayName("電話番号")]
        public string PhoneNo { get; set; }

        [DisplayName("ファックス番号")]
        public string FaxNo { get; set; }

        [DisplayName("ホームページ")]
        public string WebSite { get; set; }

        [DisplayName("Eメールアドレス")]
        public string EmailAddress { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        [DisplayName("FIMS_Id")]
        public string FIMS_Id { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<Product> Products { get; set; }
    }
}