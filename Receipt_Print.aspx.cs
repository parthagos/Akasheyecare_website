using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using CrystalDecisions;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Web.Services;
//using System.Drawing.Printing;

public partial class _Default : System.Web.UI.Page 
{
    MySqlConnection msc = new MySqlConnection();
    //string path = ConfigurationManager.AppSettings["CrystalReport_cashmemo"];

    protected void Page_Load(object sender, EventArgs e)
    {
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();
        try
        {
            //comboBox1.Items.Clear();
            msc.Open();
            string fetch = "select bill_no from akasheyecare.bill_patient_details order by bill_no desc";
            MySqlCommand cmd = new MySqlCommand(fetch, msc);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandType = CommandType.TableDirect;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
        catch (Exception evt)
        {
            Label6.Text = "Error" + evt.ToString();
        }
        finally
        {
            msc.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();
            string str01 = "select * from akasheyecare.bill_patient_details where bill_no = '" + DropDownList1.Text + "'";

            MySqlDataAdapter dscmd = new MySqlDataAdapter(str01, msc);
            DataSet ds = new DataSet();
            dscmd.Fill(ds, "bill_patient_details");
            ReportDocument prt = new ReportDocument();
            //prt.Load(path);
            prt.Load(Server.MapPath("cash_memo_print.rpt"));
            
            prt.SetDataSource(ds.Tables["bill_patient_details"]);
            //crystalReportViewer1.ReportSource = prt;
            //crystalReportViewer1.Refresh();

            //prt.PrintOptions.PrinterName = "HP Deskjet 2520 series";
            prt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            prt.PrintOptions.PaperSize = PaperSize.PaperA4;
            prt.PrintToPrinter(1, false, 0, 1);

            //DropDownList1.Text = "Select Bill No.";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
        catch (Exception evt)
        {
            Label6.Text = "PRINT_ERROR" + evt.ToString();
        }
        finally
        {
            msc.Close();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            msc.Open();
            string fetch = "select * from akasheyecare.bill_patient_details where bill_no ='" + DropDownList1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(fetch, msc);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TextBox2.Text = (reader["reg_no"].ToString());
                TextBox3.Text = (reader["name"].ToString());
                TextBox4.Text = (reader["address"].ToString());
                TextBox5.Text = (reader["cash"].ToString());
            }
        }
        catch (Exception evt)
        {
            Label6.Text = evt.ToString();
        }
        finally
        {
            msc.Close();
        }
    }
}
