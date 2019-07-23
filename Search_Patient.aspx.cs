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

public partial class Search_Patient : System.Web.UI.Page
{
    MySqlConnection msc = new MySqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

        msc.Open();
        string search = "select  reg_no as 'Registration No', name as 'Name', age as 'Age', sex as 'Sex', address as 'Address', ph_no as 'Phone No', dr_name as 'Doctor Name', date as 'Date' from patient_details where name like '" + TextBox1.Text + "%'";
        MySqlCommand cmd = new MySqlCommand(search, msc);
        MySqlDataAdapter dataadap = new MySqlDataAdapter(cmd);
        MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(dataadap);
        DataSet ds = new DataSet();
        dataadap.Fill(ds, "patient_details");
        DataTable datab = ds.Tables["patient_details"];
        msc.Close();
        GridView1.DataSource = ds.Tables["patient_details"];
        //GridView1.ReadOnly = true;
        //GridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //dataGridView1.DataBind();
        GridView1.DataBind();
    }
}
