using System;
using System.Data;
using System.Configuration;
using System.Collections;
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

public partial class Print_prescription : System.Web.UI.Page
{
    MySqlConnection msc = new MySqlConnection();
    System.Drawing.Printing.PrinterSettings ps;
    System.Drawing.Printing.PageSettings pseting;

    //string path = ConfigurationManager.AppSettings["CrystalReport_prescription"].ToString();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

            try
            {
                DropDownList1.Items.Clear();
                msc.Open();
                string fetch = "select reg_no from akasheyecare.patient_details order by reg_no desc";
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
                Label7.Text = "error db" + evt.ToString();
            }
            finally
            {
                msc.Close();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

        string str01 = "select * from akasheyecare.patient_details where reg_no = '" + DropDownList1.Text + "'";

        MySqlDataAdapter dscmd = new MySqlDataAdapter(str01, msc);
        DataSet ds = new DataSet();
        dscmd.Fill(ds, "patient_details");
        ReportDocument prt = new ReportDocument();
        prt.Load(Server.MapPath("patient_prescription.rpt"));

        prt.SetDataSource(ds.Tables["patient_details"]);


        //crystalReportViewer1.ReportSource = prt;
        //crystalReportViewer1.Refresh();

       //ps = new System.Drawing.Printing.PrinterSettings();
        //pseting = new System.Drawing.Printing.PageSettings();
        //ps.PrinterName = @"\\CASH\\HP_Deskjet_2520_series";

        //prt.PrintOptions.CopyTo(ps, pseting);

        
        //pseting.PrinterSettings = ps;
        //prt.PrintOptions.PrinterName = ps.PrinterName;

        prt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
        prt.PrintOptions.PaperSize = PaperSize.PaperA4;
        prt.PrintToPrinter(2, false, 0, 1);


        //DropDownList1.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

        try
        {
            msc.Open();
            string fetch = "select * from akasheyecare.patient_details where reg_no ='" + DropDownList1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(fetch, msc);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TextBox1.Text = (reader["name"].ToString());
                TextBox2.Text = (reader["age"].ToString());
                TextBox3.Text = (reader["sex"].ToString());
                TextBox4.Text = (reader["address"].ToString());
                TextBox5.Text = (reader["dr_name"].ToString());
            }
        }
        catch (Exception evt)
        {
            Label7.Text = evt.ToString();
        }
        finally
        {
            msc.Close();
        }
    }
}
