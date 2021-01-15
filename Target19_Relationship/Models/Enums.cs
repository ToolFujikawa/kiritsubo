using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models
{
    public class Enums
    {
        public enum Genders
        {
            女性 = 0,
            男性 = 1
        }

        public enum DeliveryDateInstructions
        {
            [Display(Name = "指定なし")]
            指定なし = 0,
            [Display(Name = "までに")]
            までに = 1,
            [Display(Name = "以降に")]
            以降に = 2
        }

        public enum TransactionUnits
        {
            [Display(Name = "個")]
            個 = 0,
            [Display(Name = "小箱")]
            小箱 = 1,
            [Display(Name = "ケース")]
            ケース = 2,
            [Display(Name = "袋")]
            袋 = 3,
            [Display(Name = "セット")]
            セット = 4,
            [Display(Name = "双")]
            双 = 5,
            [Display(Name = "足")]
            足 = 6,
            [Display(Name = "式")]
            式 = 7,
            [Display(Name = "ダース")]
            ダース = 8,
            [Display(Name = "グロス")]
            グロス = 9,
            [Display(Name = "巻")]
            cm = 10,
            [Display(Name = "cm")]
            m = 11,
            [Display(Name = "m")]
            g = 12,
            [Display(Name = "g")]
            kg = 13,
            [Display(Name = "kg")]
            巻 = 14
        }

        public enum BillStatuses
        {
            [Display(Name = "非手形")]
            非手形 = 0,
            [Display(Name = "交換")]
            交換 = 1,
            [Display(Name = "裏書")]
            裏書 = 2,
            [Display(Name = "割引")]
            割引 = 3,
            [Display(Name = "不渡")]
            不渡 = 4
        }

        public enum PurchaseMethods
        {
            [Display(Name = "口頭")]
            口頭 = 0,
            [Display(Name = "郵送")]
            郵送 = 1,
            [Display(Name = "電話")]
            電話 = 2,
            [Display(Name = "FAX")]
            FAX = 3,
            [Display(Name = "Email")]
            Email = 4,
            [Display(Name = "WEB")]
            WEB = 5
        }

        public enum DocumentTypes
        {
            [Display(Name = "売上")]
            売上 = 0,
            [Display(Name = "仕入")]
            仕入 = 1,
            [Display(Name = "入金")]
            入金 = 2,
            [Display(Name = "出金")]
            出金 = 3,
            [Display(Name = "振替")]
            振替 = 4,
            [Display(Name = "訂正")]
            訂正 = 5
        }

        public enum DeliveryStatus
        {
            [Display(Name = "未定")]
            未定 = 0,
            [Display(Name = "配達")]
            配達 = 1,
            [Display(Name = "来店")]
            来店 = 2,
            [Display(Name = "直送")]
            直送 = 3,
            [Display(Name = "他店引取")]
            他店引取 = 4
        }

        public enum DeferPeriod
        {
            [Display(Name = "不明")]
            不明 = 0,
            [Display(Name = "当月")]
            当月 = 1,
            [Display(Name = "翌月")]
            翌月 = 2,
            [Display(Name = "翌々月")]
            翌々月 = 3
        }

        public enum RemittanceMethod
        {
            [Display(Name = "不明")]
            不明 = 0,
            [Display(Name = "集金")]
            集金 = 1,
            [Display(Name = "振込")]
            振込 = 2,
            [Display(Name = "郵送")]
            郵送 = 3
        }

        public enum TransactionDefinition
        {
            [Display(Name = "売上")]
            売上 = 0,
            [Display(Name = "仕入")]
            仕入 = 1,
            [Display(Name = "売買")]
            売買 = 2
        }

        public enum Days
        {
            [Display (Name = "1日")]
            _1日 = 0,
            [Display (Name = "2日")]
            _2日 = 1,
            [Display (Name = "3日")]                                                      
            _3日 = 2,
            [Display (Name = "4日")]
            _4日 = 3,
            [Display (Name = "5日")]
            _5日 = 4,
            [Display (Name = "6日")]
            _6日 = 5,            
            [Display(Name = "7日")]
            _7日 = 6,
            [Display(Name = "8日")]
            _8日 = 7,
            [Display(Name = "9日")]
            _9日 = 8,
            [Display(Name = "10日")]
            _10日 = 9,
            [Display(Name = "11日")]
            _11日 = 10,
            [Display(Name = "12日")]
            _12日 = 11,
            [Display(Name = "13日")]
            _13日 = 12,
            [Display(Name = "14日")]
            _14日 = 13,
            [Display(Name = "15日")]
            _15日 = 14,
            [Display(Name = "16日")]
            _16日 = 15,
            [Display(Name = "17日")]
            _17日 = 16,
            [Display(Name = "18日")]
            _18日 = 17,
            [Display(Name = "19日")]
            _19日 = 18,
            [Display(Name = "20日")]
            _20日 = 19,
            [Display(Name = "21日")]
            _21日 = 20,
            [Display(Name = "22日")]
            _22日 = 21,
            [Display(Name = "23日")]
            _23日 = 22,
            [Display(Name = "24日")]
            _24日 = 23,
            [Display(Name = "25日")]
            _25日 = 24,
            [Display(Name = "26日")]
            _26日 = 25,
            [Display(Name = "27日")]
            _27日 = 26,
            [Display(Name = "28日")]
            _28日 = 27,
            [Display(Name = "29日")]
            _29日 = 28,
            [Display(Name = "30日")]
            _30日 = 29,
            [Display(Name = "31日")]
            _31日 = 30,
            [Display(Name = "月末")]
            月末 = 31,
        }
        
        public enum Months
        {
            [Display(Name = "1月")]
            _1月 = 0,
            [Display(Name = "2月")]    
            _2月 = 1,
            [Display(Name = "3月")]
            _3月 = 2,                      
            [Display(Name = "4月")]         
            _4月 = 3,       
            [Display(Name = "5月")]        
            _5月 = 4,            
            [Display(Name = "6月")]           
            _6月 = 5,  
            [Display(Name = "7月")]
            _7月 = 6,   
            [Display(Name = "8月")]    
            _8月 = 7,    
            [Display(Name = "9月")]
            _9月 = 8,
            [Display(Name = "10月")]                          
            _10月 = 9,                                                                                   
            [Display(Name = "11月")]
            _11月 = 10,
            [Display(Name = "12月")]
            _12月 = 11,
        }

        public enum Prefectures
        {
            [Display(Name = "北海道")]
            北海道 = 0,
            [Display(Name = "青森県")]
            青森県 = 1,
            [Display(Name = "秋田県")]
            秋田県 = 2,
            [Display(Name = "岩手県")]
            岩手県 = 3,
            [Display(Name = "宮城県")]
            宮城県 = 4,
            [Display(Name = "山形県")]
            山形県 = 5,
            [Display(Name = "福島県")]
            福島県 = 6,
            [Display(Name = "新潟県")]
            新潟県 = 7,
            [Display(Name = "群馬県")]
            群馬県 = 8,
            [Display(Name = "栃木県")]
            栃木県 = 9,
            [Display(Name = "茨城県")]
            茨城県 = 10,
            [Display(Name = "千葉県")]
            千葉県 = 11,
            [Display(Name = "埼玉県")]
            埼玉県 = 12,
            [Display(Name = "東京都")]
            東京都 = 13,
            [Display(Name = "神奈川県")]
            神奈川県 = 14,
            [Display(Name = "山梨県")]
            山梨県 = 15,
            [Display(Name = "静岡県")]
            静岡県 = 16,
            [Display(Name = "長野県")]
            長野県 = 17,
            [Display(Name = "愛知県")]
            愛知県 = 18,
            [Display(Name = "岐阜県")]
            岐阜県 = 19,
            [Display(Name = "富山県")]
            富山県 = 20,
            [Display(Name = "石川県")]
            石川県 = 21,
            [Display(Name = "福井県")]
            福井県 = 22,
            [Display(Name = "滋賀県")]
            滋賀県 = 23,
            [Display(Name = "京都府")]
            京都府 = 24,
            [Display(Name = "奈良県")]
            奈良県 = 25,
            [Display(Name = "三重県")]
            三重県 = 26,
            [Display(Name = "和歌山県")]
            和歌山県 = 27,
            [Display(Name = "大阪府")]
            大阪府 = 28,
            [Display(Name = "兵庫県")]
            兵庫県 = 29,
            [Display(Name = "鳥取県")]
            鳥取県 = 30,
            [Display(Name = "岡山県")]
            岡山県 = 31,
            [Display(Name = "広島県")]
            広島県 = 32,
            [Display(Name = "島根県")]
            島根県 = 33,
            [Display(Name = "山口県")]
            山口県 = 34,
            [Display(Name = "香川県")]
            香川県 = 35,
            [Display(Name = "徳島県")]
            徳島県 = 36,
            [Display(Name = "高知県")]
            高知県 = 37,
            [Display(Name = "愛媛県")]
            愛媛県 = 38,
            [Display(Name = "福岡県")]
            福岡県 = 39,
            [Display(Name = "大分県")]
            大分県 = 40,
            [Display(Name = "佐賀県")]
            佐賀県 = 41,
            [Display(Name = "長崎県")]
            長崎県 = 42,
            [Display(Name = "熊本県")]
            熊本県 = 43,
            [Display(Name = "宮崎県")]
            宮崎県 = 44,
            [Display(Name = "鹿児島県")]
            鹿児島県 = 45,
            [Display(Name = "沖縄県")]
            沖縄県 = 46
        }  
    }
}