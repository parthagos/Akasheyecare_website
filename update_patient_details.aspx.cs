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

public partial class update_patient_details : System.Web.UI.Page
{
    MySqlConnection msc = new MySqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {

        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        DropDownList2.Enabled = false;
        TextBox3.Enabled = false;
        TextBox4.Enabled = false;
        DropDownList3.Enabled = false;
        Button2.Enabled = false;

        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();
        try
        {
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
        if (Page.IsPostBack == false)
        {
            //FOR RETRIEVING DOCTOR DETAILS
            try
            {
                msc.Open();
                DropDownList3.Items.Clear();
                string fetch3 = "select dr_name from akasheyecare.doctor_details order by dr_name asc";
                MySqlCommand cmd3 = new MySqlCommand(fetch3, msc);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.TableDirect;
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    DropDownList3.Items.Add(ds3.Tables[0].Rows[i][0].ToString());
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
        TextBox1.Enabled = true;
        TextBox2.Enabled = true;
        DropDownList2.Enabled = true;
        TextBox3.Enabled = true;
        TextBox4.Enabled = true;
        DropDownList3.Enabled = true;
        Button1.Enabled = false;
        Button2.Enabled = true;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        DropDownList2.Enabled = false;
        TextBox3.Enabled = false;
        TextBox4.Enabled = false;
        DropDownList3.Enabled = false;
        Button2.Enabled = false;
        Button1.Enabled = true;

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
                DropDownList2.Text = (reader["sex"].ToString());
                TextBox3.Text = (reader["address"].ToString());
                TextBox4.Text = (reader["ph_no"].ToString());
                DropDownList3.Text = (reader["dr_name"].ToString());
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        //FOR UPDATING DATA
        msc.ConnectionString = ConfigurationManager.ConnectionStrings["MySql"].ToString();
        string insert = "update akasheyecare.patient_details set name=@name,age=@age,sex=@sex,address=@address,ph_no=@ph_no,dr_name=@dr_name where reg_no='" + DropDownList1.Text + "'";
        string insert2 = "update akasheyecare.bill_patient_details set name=@name, address=@address where reg_no='" + DropDownList1.Text + "'";

        try
        {
            // MessageBox.Show(msc.ConnectionString);
            msc.Open();
            MySqlCommand cmd = new MySqlCommand(insert, msc);
            //cmd.Parameters.AddWithValue("@reg_no", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@age", TextBox2.Text);
            cmd.Parameters.AddWithValue("@sex", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@address", TextBox3.Text);
            cmd.Parameters.AddWithValue("@ph_no", TextBox4.Text);
            cmd.Parameters.AddWithValue("@dr_name", DropDownList3.Text);
            //cmd.Parameters.AddWithValue("@date", System.DateTime.Today);
            cmd.ExecuteNonQuery();
            msc.Close();
            Label7.Text = "Data Updated Successfully";


            msc.Open();
            MySqlCommand cmd2 = new MySqlCommand(insert2, msc);
            cmd2.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd2.Parameters.AddWithValue("@address", TextBox3.Text);
            cmd2.ExecuteNonQuery();
            msc.Close();
            // MessageBox.Show("Data udated in Bill Details Sucessfully");

            //DropDownList1.Text = "Select Registration No.";
            TextBox1.Text = "";
            TextBox2.Text = "";
            DropDownList2.Text = "Male";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
        catch (Exception evt)
        {
            Label7.Text = "DataBase Connection Error" + evt.ToString();
        }
        finally
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            DropDownList2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            DropDownList3.Enabled = false;
            Button1.Enabled = true;
            Button2.Enabled = false;
            msc.Close();
        }
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Enabled = true;
        TextBox2.Enabled = true;
        DropDownList2.Enabled = true;
        TextBox3.Enabled = true;
        TextBox4.Enabled = true;
        DropDownList3.Enabled = true;
        Button1.Enabled = false;
        Button2.Enabled = true;
    }
}
