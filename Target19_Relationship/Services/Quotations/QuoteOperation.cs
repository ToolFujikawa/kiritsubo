using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;
using Target19_Relationship.Models.Views;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Services.Quotations
{
    public class QuoteOperation
    {
        //見積データの追加
        public void Create(string customer, string helper, string staff, string[] products_Id)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                int[] customer_Ids = BusinessPartnerData.NameToId(db, customer);
                int[] helper_Ids = HelperData.NameToId(db, helper);
                int customer_Id = customer_Ids[0];
                int helper_Id = helper_Ids[0];
                int product_Id = 0;
                int staff_Id = StaffData.EmailToId(db, staff);
                foreach (var item in products_Id)
                {
                    product_Id = int.Parse(item);
                    Quotation quotation = new Quotation(customer_Id, helper_Id, product_Id, staff_Id);
                    db.Quotations.Add(quotation);
                    db.SaveChanges();
                }
            }
        }

        //入力値をデータベースに反映
        public void SetUnitPrice(List<BeforeSubmittingQuotation> quotations)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var deleteZero = quotations
                                .Where(s => s.UnitPrice > 0);

                List<Quotation> results = new List<Quotation>();

                foreach (var item in deleteZero)
                {
                    var quotation = db.Quotations
                                    .Single(q => q.Id == item.Id);
                    quotation.Quantity = item.Quantity;
                    quotation.UnitPrice = item.UnitPrice;
                    quotation.Arrival = IsNull.ToString(item.Arrival);
                    quotation.Detail = IsNull.ToString(item.Detail);

                    db.SaveChanges();
                }
            }
        }

        //見積書出力
        public void Publish(List<BeforeSubmittingQuotation> quotations)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                string responsibleStaff = quotations
                                            .Max(q => q.ResponsibleStaff);
                int staff_Id = NameToId.Staff(db, responsibleStaff)[0];
                db.Database.ExecuteSqlCommand("call publishquotation(" + staff_Id + ")");               
            }
        }
        /*
        //仕入先へ価格問い合わせ
        public void SendInqueryUnitPrice(List<SetPseudonymSupplier> setPseudonymSuppliers)
        {
            var targets = setPseudonymSuppliers
                            .Where(ps => String.IsNullOrEmpty(ps.Supplier) == false && ps.IsContacted == false && ps.ContactOutgoingDate == DateTime.Parse("9999-12-31"))
                            .ToList();

            if (targets.Count != 0)
            {
                Email email = new Email();
                email.SendPriceInquery(targets);
            }

            //発信日付を更新して、次の送信時の選択から除外
            using (Model1 db = new Model1())
            {
                foreach (var item in targets)
                {
                    var updateTargets = db.Estimates
                                            .Single(e => e.Id == item.Id);
                    updateTargets.ContactOutgoingDate = DateTime.Now.Date;
                    db.SaveChanges();
                }

                //問合せ済みのレコードの発信日付を更新します。
                targets = setPseudonymSuppliers
                            .Where(ps => ps.IsContacted == true && ps.ContactOutgoingDate == DateTime.Parse("9999-12-31"))
                            .ToList();

                foreach (var item in targets)
                {
                    var updateTargets = db.Estimates
                                            .Single(e => e.Id == item.Id);
                    updateTargets.ContactOutgoingDate = DateTime.Now.Date;
                    db.SaveChanges();
                }
            }
        }

        //販売価格を設定する対象の選択肢を作成
        public List<SelectListItem> CustomerList()
        {
            using (Model1 db = new Model1())
            {
                List<SelectListItem> results = new List<SelectListItem>();
                results = db.Estimates
                                .Where(e => e.EstimateNo == 0
                                        && e.Pseudonym == "")
                                .Select(e => new SelectListItem
                                {
                                    Text = e.BusinessPartner.CommonName,
                                    Value = e.Customer_Id.ToString()
                                })
                                .Distinct()
                                .ToList();
                results.Insert(0, new SelectListItem() { Value = "0", Text = "提出先を選択" });
                return results;
            }
        }

        //見積を入力した社員のリスト
        public List<SelectListItem> ResponsibleStaffList()
        {
            using (Model1 db = new Model1())
            {
                List<SelectListItem> results = new List<SelectListItem>();
                results = db.Estimates
                            .Where(e => e.EstimateNo == 0
                                        && e.Pseudonym == "")
                            .Select(e => new SelectListItem
                            {
                                Text = e.Staff.LastName + e.Staff.FirstName,
                                Value = e.ResponsibleStaff_Id.ToString()
                            })
                            .Distinct()
                            .ToList();
                results.Insert(0, new SelectListItem() { Value = "0", Text = "入力者を選択" });
                return results;
            }
        }

        //見積提出先の担当者リスト
        public List<SelectListItem> HelperList()
        {
            using (Model1 db = new Model1())
            {
                List<SelectListItem> results = new List<SelectListItem>();
                results = db.Estimates
                            .Where(e => e.EstimateNo == 0
                                        && e.Pseudonym == "")
                            .Select(e => new SelectListItem
                            {
                                Text = e.Helper.LastName + e.Helper.FirstName,
                                Value = e.Helper_Id.ToString()
                            })
                            .Distinct()
                            .ToList();
                results.Insert(0, new SelectListItem() { Value = "0", Text = "相手の担当者を選択" });
                return results;
            }
        }

        //見積価格設定対象となる商品群を返す
        public List<SetEstimate> SellingPriceUnSetHerd(int customer_Id, int responsibleStaff_Id, int helper_Id)
        {
            //検索起点、終点の設定
            DataBase dataBase = new DataBase();

            int startBusinessPartner_Id = 1;
            int startStaff_Id = 1;
            int startHelper_Id = 1;

            int lastBusinessPartner_Id = dataBase.GetLastId("BusinessPartners");
            int lastStaff_Id = dataBase.GetLastId("Staffs");
            int lastHelper_Id = dataBase.GetLastId("Helpers");

            if (customer_Id != 0)
            {
                startBusinessPartner_Id = customer_Id;
                lastBusinessPartner_Id = customer_Id + 1;
            }

            if (responsibleStaff_Id != 0)
            {
                startStaff_Id = responsibleStaff_Id;
                lastStaff_Id = responsibleStaff_Id + 1;
            }

            if (helper_Id != 0)
            {
                startHelper_Id = helper_Id;
                lastHelper_Id = helper_Id + 1;
            }

            //検索実行
            using (Model1 db = new Model1())
            {
                List<SetEstimate> results = db.Estimates
                                            .Where(e => e.Customer_Id >= startBusinessPartner_Id
                                                    && e.Customer_Id < lastBusinessPartner_Id
                                                    && e.ResponsibleStaff_Id >= startStaff_Id
                                                    && e.ResponsibleStaff_Id < lastStaff_Id
                                                    && e.Helper_Id >= startHelper_Id
                                                    && e.Helper_Id < lastHelper_Id
                                                    && e.EstimateNo == 0
                                                    && e.Pseudonym == "")
                                            .Select(e => new SetEstimate
                                            {
                                                Id = e.Id,
                                                IsCancel = e.IsCancel,
                                                ContactOutgoingDate = e.ContactOutgoingDate,
                                                Detail = e.Detail,
                                                ResponsibleStaff_Id = e.ResponsibleStaff_Id,
                                                ResponsibleStaff = e.Staff.LastName + e.Staff.FirstName,
                                                ResponsibleStaffEmailAddress = e.Staff.EmailAddress,
                                                Helper_Id = e.Helper_Id,
                                                Helper = e.Helper.LastName + e.Helper.FirstName,
                                                HelperEmailAddress = e.Helper.EmailAddress,
                                                Customer_Id = e.Customer_Id,
                                                Customer = e.BusinessPartner.CommonName,
                                                CustomerEmailAddress = e.BusinessPartner.BusinessPartnerEMailAddresses
                                                                        .FirstOrDefault(be => be.Rank == 1)
                                                                        .EMailAddress,
                                                ValidityPeriod = e.ValidityPeriod,
                                                PaymentTerm = e.PaymentTerm,
                                                Product = e.Product.Manufacturer.CommonName + " " + e.Product.ProductName + " " + e.Product.Material + " " + e.Product.Model,
                                                Quantity = e.Quantity,
                                                UnitPrice = e.UnitPrice,
                                                Cost = e.Product.Cost,
                                                TransactionUnit = e.Product.TransactionUnit,
                                                Arrival = e.Arrival
                                            })
                                            .ToList();
                return results;
            }
        }

        //入力された価格、納期、備考を反映
        public List<Estimate> SetSellingPrice(List<SetEstimate> setEstimates)
        {
            using (Model1 db = new Model1())
            {
            }
        }

        //価格が反映されたレコードの見積書番号を設定
        public List<Estimate> SetEstimateNo(List<Estimate> estimates)
        {
            //CustomerとHelperによってグループ化されたIdの集合を得る
            //Helperごとの集合
            var everyHelper = estimates
                                .Where(e => e.Helper_Id != 1)
                                .GroupBy(e => e.Helper_Id);

            //Customerごとの集合
            var everyCustomer = estimates
                                .Where(e => e.Helper_Id == 1)
                                .GroupBy(e => e.Customer_Id);

            //見積書番号を設定
            using (Model1 db = new Model1())
            {
                int maxEstimateNo = 0;
                //Helperごとの集合に見積書番号を設定
                foreach (var key in everyHelper)
                {
                    maxEstimateNo = db.Estimates
                                        .Max(e => e.EstimateNo);

                    foreach (var item in key)
                    {
                        var target = db.Estimates
                                        .Single(e => e.Id == item.Id);

                        target.EstimateNo = maxEstimateNo + 1;

                        db.SaveChanges();
                    }
                }
                //Customerごとの集合に見積書番号を付与
                foreach (var key in everyCustomer)
                {
                    maxEstimateNo = db.Estimates
                                        .Max(e => e.EstimateNo);

                    foreach (var item in key)
                    {
                        var target = db.Estimates
                                        .Single(e => e.Id == item.Id);

                        target.EstimateNo = maxEstimateNo + 1;

                        db.SaveChanges();
                    }
                }

                //更新された見積書番号を返す。
                int[] arr = estimates
                            .Select(e => e.Id)
                            .ToArray();

                var reEstimates = db.Estimates
                                    .Where(e => arr.Contains(e.Id))
                                    .ToList();
                return reEstimates;
            }
        }

        //Eメールで送信するかどうか
        public List<SetEstimate> SelectSendTarget(List<Estimate> estimates, List<SetEstimate> setEstimates)
        {
            //処理された集合からId配列を取り出す。回答する販売先は一意。
            int[] array = estimates
                            .Select(e => e.Id)
                            .ToArray();

            //処理される前の集合から処理された集合のIdで抽出
            var results = setEstimates
                            .Where(se => array.Contains(se.Id)
                                        && String.IsNullOrEmpty(se.HelperEmailAddress + se.CustomerEmailAddress) == false)
                            .ToList();

            foreach (var item in results)
            {
                item.EstimateNo = estimates
                                    .Single(e => e.Id == item.Id)
                                    .EstimateNo;
            }
            return results;
        }

        //見積書を送信
        public void SendEsimate(List<SetEstimate> setEstimates)
        {
            //Helperのアドレスがあるものとないものに分割
            var hasHelperEmailAddress = setEstimates
                                        .Where(se => String.IsNullOrEmpty(se.HelperEmailAddress) == false)
                                        .GroupBy(se => se.Helper_Id);

            var notHasHelperEmailAddress = setEstimates
                                            .Where(se => String.IsNullOrEmpty(se.HelperEmailAddress) == true)
                                            .GroupBy(se => se.Customer_Id);

            SendEmail sendEmail = new SendEmail();

            using (Model1 db = new Model1())
            {
                foreach (var item in hasHelperEmailAddress)
                {
                    sendEmail.Estimate(item.AsEnumerable().ToList());
                }
                foreach (var item in notHasHelperEmailAddress)
                {
                    sendEmail.Estimate(item.AsEnumerable().ToList());
                }
            }
        }

        //値段更新前のレコードから更新したデータを除外
        */
    }
}