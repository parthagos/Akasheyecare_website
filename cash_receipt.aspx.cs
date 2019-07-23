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

public partial class cash_receipt : System.Web.UI.Page
{
    MySqlConnection msc = new MySqlConnection();
    //string path = ConfigurationManager.AppSettings["CrystalReport_cashmemo"].ToString();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

            // FOR SHOWING BILL_NO WITH 1 INCREASED VALUE

            try
            {
                msc.Open();
                string fetch = "select bill_no from akasheyecare.bill_patient_details_temp_increment order by bill_no desc limit 1";
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
                Label6.Text = "Error in db conncetion";
            }
            finally
            {
                msc.Close();
            }

            //COMBO BOX ITEMS ADD WITH REG_NO

            try
            {
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("Select Registration No.");
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
                Label6.Text = "error db" + evt.ToString();
            }
            finally
            {
                msc.Close();
            }
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
       /* //Cash
        string cash = TextBox4.Text;
        bool hasDigit4 = false;
        foreach (char letter4 in cash)
        {
            if (char.IsDigit(letter4))
            {
                hasDigit4 = true;
                break;
            }
        }

        if (cash == "")
        {
            errorProvider1.Clear();
            errorProvider1.SetError(TextBox4, "Cash can not be left blank");
        }
        else if (!hasDigit4)
        {
            errorProvider1.Clear();
            errorProvider1.SetError(TextBox4, "Cash should be digit");
        }
        else
        {
            errorProvider1.Clear();
        }
        */
        //FOR INSERTING DATA INTO DATABASE

        // string insert = "insert into akasheyecare.patient_details values (" + textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + comboBox1.Text + "," + richTextBox1.Text + "," + textBox5.Text + "," + System.DateTime.Today.DayOfYear.ToString() +")";
        
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

        string insert = "insert into akasheyecare.bill_patient_details(bill_no,reg_no,name,address,cash,date) values (@bill_no,@reg_no,@name,@address,@cash,@date)";
        try
        {
            // MessageBox.Show(msc.ConnectionString);
            msc.Open();
            MySqlCommand cmd = new MySqlCommand(insert, msc);
            cmd.Parameters.AddWithValue("@bill_no", TextBox1.Text);
            cmd.Parameters.AddWithValue("@reg_no", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@address", TextBox3.Text);
            cmd.Parameters.AddWithValue("@cash", TextBox4.Text);
            cmd.Parameters.AddWithValue("@date", System.DateTime.Today);
            cmd.ExecuteNonQuery();
            //msc.Close();

            //DialogResult result1 = MessageBox.Show("Data uploaded to server successfully. Do you want to print the Bill?", "Print Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result1 == DialogResult.Yes)
            //{
                //for printing data for the particular reg_no

                string str01 = "select * from akasheyecare.bill_patient_details where bill_no = '" + TextBox1.Text + "'";

                MySqlDataAdapter dscmd = new MySqlDataAdapter(str01, msc);
                DataSet ds = new DataSet();
                dscmd.Fill(ds, "bill_patient_details");
                ReportDocument prt = new ReportDocument();
                prt.Load(Server.MapPath("cash_memo_print.rpt"));

                prt.SetDataSource(ds.Tables["bill_patient_details"]);
                //crystalReportViewer1.ReportSource = prt;
                //crystalReportViewer1.Refresh();

                //prt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                //prt.PrintOptions.PaperSize = PaperSize.PaperA4;
                prt.PrintToPrinter(1, false, 0, 1);
            //}
            //else
            //{
                Label6.Text = "You can later print the Bill. Thank You.";
            //}

            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";

        }
        catch (MySqlException evt)
        {
            Label6.Text="Error in inserting Data to Server" + evt.ToString();
        }
        finally
        {
            //for closing the mysql db connection
            msc.Close();
            this.Page_Load(this, e);
            Response.Redirect("cash_receipt.aspx");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();
            msc.Open();
            string fetch = "select name,address from akasheyecare.patient_details where reg_no ='" + DropDownList1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(fetch, msc);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TextBox2.Text = (reader["name"].ToString());
                //textBox2.Text = (reader["age"].ToString());
                //comboBox2.Text = (reader["sex"].ToString());
                TextBox3.Text = (reader["address"].ToString());
                //textBox4.Text = (reader["ph_no"].ToString());
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