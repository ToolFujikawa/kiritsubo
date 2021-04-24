using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Target19_Relationship.WebForms
{
    public partial class Quotation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinShowReport_Click(object sender, EventArgs e)
        {
            DataTable dt = BillingData();
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.ReportPath = @"..\Target19_Relationship\Reports\QuotationMain.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(BillingStatementsSubreportProcessing);
            ReportViewer1.LocalReport.Refresh();
        }

        void BillingStatementsSubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            int Id = int.Parse(e.Parameters["QuotationNoParam"].Values[0].ToString());
            DataTable dtd = GetBillingStatementByBusinessPartnerId(Id);
            ReportDataSource ds = new ReportDataSource("DataSet1", dtd);
            e.DataSources.Add(ds);
        }

        private DataTable BillingData()
        {
            DataTable dt = new DataTable();
            string conect = "server=localhost;user id=yfujikawa;password=bx4q7qv9cr?B;persistsecurityinfo=True;database=target19";
            using (MySqlConnection cnn = new MySqlConnection(conect))
            {
                string query = @"select QuotationNo
                                , SubmissionDate, ResponsibleStaff, Customer
                                , Helper, ValidityPeriod, PaymentTerm
                                from quotationmain";
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                cnn.Open();
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    dt.Load(mySqlDataReader);
                }
            }
            return dt;
        }

        //サブレポートデータの取得
        private DataTable GetBillingStatementByBusinessPartnerId(int Id)
        {
            DataTable dt = new DataTable();
            string conect = "server=localhost;user id=yfujikawa;password=bx4q7qv9cr?B;persistsecurityinfo=True;database=target19";
            using (MySqlConnection cnn = new MySqlConnection(conect))
            {
                string query = @"select TaxRate
                                , Detail, Arrival, Product, Quantity
                                , UnitPrice, Amount
                                from quotationsub
                                where QuotationNo = " + Id + "";
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                cnn.Open();
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    dt.Load(mySqlDataReader);
                }
            }
            return dt;
        }
    }
}