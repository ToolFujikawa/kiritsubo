using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Target19_Relationship.Models.Details;
using Target19_Relationship.Models.Tables;
using Target19_Relationship.Models.Views;

namespace Target19_Relationship.Models
{
    public partial class DefaultConnection : DbContext
    {
        public DefaultConnection()
        : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<AccountTitle> AccountTitles { get; set; }
        public virtual DbSet<BusinessPartner> BusinessPartners { get; set; }
        public virtual DbSet<BusinessPartnerEmailAddress> BusinessPartnerEMailAddresses { get; set; }
        public virtual DbSet<DeliveryPlace> DeliveryPlaces { get; set; }
        public virtual DbSet<FinancialInstitution> FinancialInstitutions { get; set; }
        public virtual DbSet<FinancialInstitutionBranch> FinancialInstitutionBranches { get; set; }
        public virtual DbSet<GoodsIssue> GoodsIssues { get; set; }
        public virtual DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public virtual DbSet<Helper> Helpers { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        //Views
        public virtual DbSet<BeforeDelivery> BeforeDeliveries { get; set; }
        public virtual DbSet<BeforeIssuingPurchaseOrder> BeforeIssuingPurchaseOrders { get; set; }
        public virtual DbSet<BeforeWarehousing> BeforeWarehousings { get; set; }
        public virtual DbSet<ReadableGoodsIssue> ReadableGoodsIssues { get; set; }
        public virtual DbSet<ReadableProduct> ReadableProducts { get; set; }
        public virtual DbSet<ReadableProductAttribute> ReadableProductAttributes { get; set; }
        public System.Data.Entity.DbSet<Target19_Relationship.Models.Views.ReadableGoodsReceipt> ReadableGoodsReceipts { get; set; }
        public System.Data.Entity.DbSet<Target19_Relationship.Models.Details.ReadableJournal> ReadableJournals { get; set; }
        public virtual DbSet<ReadablePurchase> ReadablePurchases { get; set; }
        public virtual DbSet<ReadableQuotation> ReadableQuotations { get; set; }
        public virtual DbSet<ReadableSale> ReadableSales { get; set; }
        /*
public virtual DbSet<ProductList> ProductLists { get; set; }
public virtual DbSet<AddProductAttribute> InputProductAttributes { get; set; }
public virtual DbSet<ProductWithCommonName> ProductWithCommonNames { get; set; }
public virtual DbSet<InvoiceEntryTarget> InvoiceEntryTargets { get; set; }
public virtual DbSet<Shipment> Shipments { get; set; }
public virtual DbSet<BeforeDelivery> BeforeDeliveries { get; set; }
public virtual DbSet<StockFluctuation> StockFluctuations { get; set; }
public virtual DbSet<BeforeSendPurchaseOrder> BeforeSendPurchaseOrders { get; set; }
public virtual DbSet<BeforePurchase> BeforePurchases { get; set; }
public virtual DbSet<AfterDelivery> AfterDeliveries { get; set; }
public virtual DbSet<AfterPurchase> AfterPurchases { get; set; }
public virtual DbSet<BeforeSetSellingPrice> BeforeSetSellingPrices { get; set; }
*/
    }
}