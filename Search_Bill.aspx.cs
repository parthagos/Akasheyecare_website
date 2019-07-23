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

public partial class Search_Bill : System.Web.UI.Page
{
    MySqlConnection msc = new MySqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Search_Click(object sender, EventArgs e)
    {
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

        msc.Open();
        string search = "select  bill_no as 'Bill No', reg_no as 'Registration No', name as 'Name', address as 'Address', cash as 'Cash', date as 'Date' from akasheyecare.bill_patient_details where name like '" + TextBox1.Text + "%'";
        MySqlCommand cmd = new MySqlCommand(search, msc);
        MySqlDataAdapter dataadap = new MySqlDataAdapter(cmd);
        MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(dataadap);
        DataSet ds = new DataSet();
        dataadap.Fill(ds, "bill_patient_details");
        DataTable datab = ds.Tables["bill_patient_details"];
        msc.Close();
        GridView1.DataSource = ds.Tables["bill_patient_details"];
        //GridView1..ReadOnly = true;
        //GridView1.SelectionMode = GridViewSelectionMode.FullRowSelect;
        //dataGridView1.DataBind();
        GridView1.DataBind();
    }
}
