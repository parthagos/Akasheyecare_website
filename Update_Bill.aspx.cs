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

public partial class Update_Bill : System.Web.UI.Page
{
    MySqlConnection msc = new MySqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            DropDownList1.Items.Clear();
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            Button2.Enabled = false;

            msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();
            try
            {
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
                Label6.Text = "error db" + evt.ToString();
            }
            finally
            {
                msc.Close();
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        TextBox3.Enabled = false;
        TextBox4.Enabled = false;
        Button2.Enabled = false;
        Button1.Enabled = true;
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();
        
        try
        {
            msc.Open();
            string fetch = "select * from akasheyecare.bill_patient_details where bill_no ='" + DropDownList1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(fetch, msc);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TextBox1.Text = (reader["reg_no"].ToString());
                TextBox2.Text = (reader["name"].ToString());
                TextBox3.Text = (reader["address"].ToString());
                TextBox4.Text = (reader["cash"].ToString());
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Enabled = false;
        TextBox2.Enabled = true;
        TextBox3.Enabled = true;
        TextBox4.Enabled = true;
        //errorProvider1.Clear();
        Button1.Enabled = false;
        Button2.Enabled = true;       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        /*//amount
        string amount = textBox4.Text;
        bool hasDigit4 = false;
        foreach (char letter4 in amount)
        {
            if (char.IsDigit(letter4))
            {
                hasDigit4 = true;
                break;
            }
        }
        if (amount == "")
        {
            errorProvider1.Clear();
            errorProvider1.SetError(textBox4, "amount can not be left blank");
        }
        else if (!hasDigit4)
        {
            errorProvider1.Clear();
            errorProvider1.SetError(textBox4, "amount should be digit");
        }
        else
        {
            errorProvider1.Clear();
        }
        */
        //FOR UPDATING DATA

        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();

        string insert = "update akasheyecare.bill_patient_details set reg_no=@reg_no,name=@name,address=@address,cash=@cash where bill_no='" + DropDownList1.Text + "'";

        try
        {
            // MessageBox.Show(msc.ConnectionString);
            msc.Open();
            MySqlCommand cmd = new MySqlCommand(insert, msc);
            cmd.Parameters.AddWithValue("@reg_no", TextBox1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@address", TextBox3.Text);
            cmd.Parameters.AddWithValue("@cash", TextBox4.Text);
            //cmd.Parameters.AddWithValue("@date", System.DateTime.Today);
            cmd.ExecuteNonQuery();
            msc.Close();
            Label6.Text = "Data Updated Successfully";

            //comboBox1.Text = "Select Bill No.";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
        catch(Exception evt)
        {
            Label6.Text = evt.ToString();
            //MessageBox.Show("DataBase Connection Error");
        }
        finally
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            Button1.Enabled = true;
            Button2.Enabled = false;
            msc.Close();
        }
    }
}
