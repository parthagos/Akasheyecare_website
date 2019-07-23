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

public partial class patient_details : System.Web.UI.Page
{
    MySqlConnection msc = new MySqlConnection();
    //string path = ConfigurationManager.AppSettings["CrystalReport_prescription"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();
        try
        {
            msc.Open();
            string fetch = "select reg_no from akasheyecare.patient_details_temp_increment order by reg_no desc limit 1";
            MySqlCommand cmd2 = new MySqlCommand(fetch, msc);
            MySqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = Convert.ToString(dr[0]);
                dr.Close();
            }
        }
        catch
        {
            Label8.Text = "Error in db conncetion";
        }
        finally
        {
            msc.Close();
        }

        //LOADING DOCTOR'S DETAILS

       /* try
        {
            DropDownList2.Items.Clear();
            DropDownList2.Text = "Select Doctor's Name";
            msc.Open();
            string fetch2 = "select dr_name from akasheyecare.doctor_details order by dr_name asc";
            MySqlCommand cmd3 = new MySqlCommand(fetch2, msc);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandType = CommandType.TableDirect;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
        catch (Exception evt)
        {
            Label8.Text = "error db" + evt.ToString();
        }
        finally
        {
            msc.Close();
        }
        */
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

        //FOR INSERTING DATA INTO DATABASE

        // string insert = "insert into akasheyecare.patient_details values (" + textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + comboBox1.Text + "," + richTextBox1.Text + "," + textBox5.Text + "," + System.DateTime.Today.DayOfYear.ToString() +")";
        string insert = "insert into akasheyecare.patient_details(reg_no,name,age,sex,address,ph_no,dr_name,date) values (@reg_no,@name,@age,@sex,@address,@ph_no,@dr_name,@date)";
        try
        {
            // MessageBox.Show(msc.ConnectionString);
            msc.Open();
            MySqlCommand cmd = new MySqlCommand(insert, msc);
            cmd.Parameters.AddWithValue("@reg_no", TextBox1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@age", TextBox3.Text);
            cmd.Parameters.AddWithValue("@sex", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@address", TextBox4.Text);
            cmd.Parameters.AddWithValue("@ph_no", TextBox5.Text);
            cmd.Parameters.AddWithValue("@dr_name", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@date", System.DateTime.Today);
            cmd.ExecuteNonQuery();
            //msc.Close();

           // DialogResult result1 = MessageBox.Show("data uploaded to server successfully. Do you want to print the prescription?", "Print Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result1 == DialogResult.Yes)
           // {
                //for printing data for the particular reg_no

                string str01 = "select * from patient_details where reg_no = '" + TextBox1.Text + "'";

                MySqlDataAdapter dscmd = new MySqlDataAdapter(str01, msc);
                DataSet ds = new DataSet();
                dscmd.Fill(ds, "patient_details");
                ReportDocument prt = new ReportDocument();
                prt.Load(Server.MapPath("patient_prescription.rpt"));

                prt.SetDataSource(ds.Tables["patient_details"]);
                //crystalReportViewer1.ReportSource = prt;
                //crystalReportViewer1.Refresh();

                prt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                prt.PrintOptions.PaperSize = PaperSize.PaperA4;
                prt.PrintToPrinter(2, false, 0, 1);
            //}
           // else
            //{
                Label8.Text = "You can later print the prescription. Thank You.";
           // }
            //for closing the mysql db connection
            msc.Close();

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            DropDownList1.Text = "Male";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList2.Text = "";
        }
        catch //(MySqlException evt)
        {
            Label8.Text = "Error in inserting Data to Server"; //+ evt.ToString();
        }
        finally
        {
            msc.Close();
            this.Page_Load(this, e);
        }
    }
}
