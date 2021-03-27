using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;
using Target19_Relationship.Services;

namespace Target19_Relationship.Controllers
{
    public class QuotationController : Controller
    {
        //見積入力画面の表示。取引先、担当者等共通部分。
        public ActionResult Create()
        {
            var paymentTerm = new SelectList(DataConverter.CreateEnumDictionary<Enums.PaymentTerms>(), "Key", "Value");
            var validityPeriods = new SelectList(DataConverter.CreateEnumDictionary<Enums.ValidityPeriods>(), "Key", "Value");
            ViewBag.PaymentTermOptions = paymentTerm;
            ViewBag.DeferPeriodOptions = validityPeriods;
            AddEstimate addEstimate = new AddEstimate();
            return View(addEstimate);
        }

        /*
        //ViewのRazorで入力行数制御
        [ChildActionOnly]
        public ActionResult InputDetails()//商品詳細を入力する部分ビュー
        {
            return PartialView("_InputDetails");
        }

        //入力データ処理。取引先、担当者は一意。
        [HttpPost]
        public ActionResult Input(List<AddEstimate> addEstimates)
        {
            //価格設定用に、データ挿入前最大値を取得
            EstimateService estimateService = new EstimateService();
            int lastEstimate_Id = estimateService.GetLastEstimateId();

            //新規商品にIdを設定する
            MasterDataService masterDataService = new MasterDataService();
            bool isExists = masterDataService.CreateProduct(addEstimates);

            //見積テーブルにデータを挿入
            estimateService.Add(addEstimates);

            //売上実績があるものに価格を設定
            estimateService.SetUnitPrice(lastEstimate_Id);

            //新規商品があった時は価格問い合わせ依頼作成画面に遷移。問合せメール送信機能あり。
            if (isExists)
            {
                return RedirectToAction("SetPseudonymSupplier");
            }

            //原価のないものは見積依頼書を作成する。新規商品の仕入先けって済みのもの合わせて。

            //価格入力画面を表示する
            return View();
        }

        //新規入力商品の見積依頼メールを作成するための、仕入先設定
        public ActionResult SetPseudonymSupplier()
        {
            MasterDataService masterDataService = new MasterDataService();
            return View(masterDataService.SetPseudonymSupplier());
        }

        //価格問い合わせEメール生成
        [HttpPost]
        public ActionResult SetPseudonymSupplier(List<SetPseudonymSupplier> setPseudonymSuppliers)
        {
            EstimateService estimateService = new EstimateService();
            estimateService.SendInqueryUnitPrice(setPseudonymSuppliers);
            return RedirectToAction("Product", "Masterdata");
        }

        //見積提示のための価格入力画面表示
        public ActionResult Output()
        {
            EstimateService estimateService = new EstimateService();
            var customers = new SelectList(estimateService.CustomerList(), "Value", "Text");
            var responsibleStaffs = new SelectList(estimateService.ResponsibleStaffList(), "Value", "Text");
            var helpers = new SelectList(estimateService.HelperList(), "Value", "Text");
            ViewBag.SelectCustomerOptions = customers;
            ViewBag.SelectResponsibleStaffOptions = responsibleStaffs;
            ViewBag.SelectHelperOptions = helpers;
            return View();
        }

        public ActionResult SelectedEstimate(int customer_Id, int responsibleStaff_Id, int helper_Id)
        {
            if (Request.IsAjaxRequest())
            {
                EstimateService estimateService = new EstimateService();
                var results = estimateService.SellingPriceUnSetHerd(customer_Id, responsibleStaff_Id, helper_Id);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_SellingPricingContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        [HttpPost]
        public ActionResult Output(
            [Bind(Include = "")] List<SetEstimate> setEstimates)//Include内にカンマ区切りでプロパティを列挙
        {
            EstimateService estimateService = new EstimateService();

            //価格入力があるものデータ更新
            List<Estimate> estimates = estimateService.SetSellingPrice(setEstimates);

            //価格更新されたデータの見積書番号を設定
            var tmp = estimateService.SetEstimateNo(estimates);

            //送信するかどうかの判定
            List<SetEstimate> judge = estimateService.SelectSendTarget(tmp, setEstimates);

            //Toにアドレスが設定できなければ処理をしない。
            if (judge?.Count > 0)//メールアドレスが存在する
            {
                estimateService.SendEsimate(judge);

                //見積価格入力候補から除外する処理

                return RedirectToAction("Input");
            }
            else
            {
                return RedirectToAction("Input");
            }
        }
        */
    }
}