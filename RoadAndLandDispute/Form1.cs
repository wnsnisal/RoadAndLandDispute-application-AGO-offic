using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RoadAndLandDispute
{
    public partial class Form1 : Form
    {
        public static DataSet ds2 = new DataSet();
        public static DataSet ds1 = new DataSet();
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=road&landdispute");

        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string insertQuery = "insert into tbldispute(fileNo,date,name,NIC,address,description,reportCallDate,reportType,desition,fileEndDate,wasama) values('" + txtFile.Text + "','" + txtCaseDate.Text + "','" + txtName.Text + "','" + txtNIC.Text + "','" + txtAddress.Text + "','" + txtDescription.Text + "','" + txtReportCallDate.Text + "','" + cmbReportType.SelectedItem + "','" + txtFinalDesition.Text + "','" + txtEndDate.Text + "','" + cmbWasama.SelectedItem + "')";
            con.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, con);
            
            try
            {
                if (txtFile.Text == "" || txtCaseDate.Text == "" || cmbWasama.SelectedItem.ToString() == "" || txtName.Text == "" || txtAddress.Text == "" || txtDescription.Text == "" || txtReportCallDate.Text == "" || cmbReportType.SelectedItem.ToString() == "" || txtFinalDesition.Text == "" || txtEndDate.Text == "")
                {
                    MessageBox.Show("please fill required fields", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    //if (command.ExecuteNonQuery() == 1)
                    //{
                    command.ExecuteNonQuery();
                    if (MessageBox.Show("ඇතලත් කිරීම සාර්ථකයි", "information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtCaseDate.Text = "";
                            txtFile.Text = "";
                            cmbWasama.Text = "";
                            txtName.Text = "";
                            txtAddress.Text = "";
                            txtNIC.Text = "";
                            txtDescription.Text = "";
                            txtReportCallDate.Text = "";
                            txtFinalDesition.Text = "";
                            cmbReportType.Text = "";
                            txtEndDate.Text = "";

                            con.Close();
                        }
                   // }
                    //else
                   // {
                       // MessageBox.Show("data not inserted", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       // con.Close();
                    //}

                }
            }
            catch
            {
                MessageBox.Show("වැරදි ඇතලත් කිරීමකි, නැවත උත්සහ කරන්න", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbReportType.Text = "තේරන්න";
            cmbReportType2.Text = "තේරන්න";
            cmbWasama.Text = "තේරන්න";
            cmbWasama02.Text = "තේරන්න";
            ds1.Clear();
            ds2.Clear();

            try
            {
                con.Open();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM tbldispute", con))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    
                    con.Close();
                    ds1.Clear();
                    
                }
            }
            catch
            {
                MessageBox.Show("please connect the wamp server", "infrmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            

        }

        private void tabPageAddDisputes_Click(object sender, EventArgs e)
        {

        }

        private void pnlSearchID_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNIC_Click(object sender, EventArgs e)
        {
            
        }

        private void btnWasama_Click(object sender, EventArgs e)
        {
            
        }

        private void btnIDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM tbldispute WHERE NIC = '"+txtNIC.ToString()+"'";
                MySqlDataAdapter adr = new MySqlDataAdapter(selectQuery, con);
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(ds1, "tbldispute");

                int currentRow = 0;
                int rowCount = ds1.Tables["tbldispute"].Rows.Count;
                while (currentRow < rowCount)
                {
                    //int n = dgvSearchDisputes.Rows.Add();

                    currentRow++;

                    if (currentRow > rowCount)
                    {
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("කරැණාකාර සෙවීමට ඇති දෙය සටහන් කරන්න", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnWasamaSearch_Click(object sender, EventArgs e)
        {

            try
            {
                //dgvSearchDisputes.Rows.Clear();
                ds1.Clear();
                //string selectQuery = "SELECT * FROM tbldispute WHERE wasama = '" + cmbSearchWasama.SelectedItem.ToString() + "' order by id";
                //MySqlDataAdapter adr = new MySqlDataAdapter(selectQuery, con);
                //adr.SelectCommand.CommandType = CommandType.Text;
                //adr.Fill(ds1, "tbldispute");

                int currentRow = 0;
                int rowCount = ds1.Tables["tbldispute"].Rows.Count;
                while (currentRow < rowCount)
                {
                    //int n = dgvSearchDisputes.Rows.Add();
                    /*dgvSearchDisputes.Rows[n].Cells[0].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[0].ToString();
                    dgvSearchDisputes.Rows[n].Cells[1].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[1].ToString();
                    dgvSearchDisputes.Rows[n].Cells[2].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[2].ToString();
                    dgvSearchDisputes.Rows[n].Cells[3].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[3].ToString();
                    dgvSearchDisputes.Rows[n].Cells[4].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[4].ToString();
                    dgvSearchDisputes.Rows[n].Cells[5].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[5].ToString();
                    dgvSearchDisputes.Rows[n].Cells[6].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[6].ToString();
                    dgvSearchDisputes.Rows[n].Cells[7].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[7].ToString();
                    dgvSearchDisputes.Rows[n].Cells[8].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[8].ToString();
                    dgvSearchDisputes.Rows[n].Cells[9].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[9].ToString();
                    dgvSearchDisputes.Rows[n].Cells[10].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[10].ToString();
                    dgvSearchDisputes.Rows[n].Cells[11].Value = ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[11].ToString();
                    currentRow++;*/

                    if (currentRow > rowCount)
                    {
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("කරැණාකාර සෙවීමට ඇති දෙය සටහන් කරන්න", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //int n = dgvSearchDisputes.CurrentRow.Index;
            //string deleteQuery = "delete from tbldispute where idStudentInfo='" + dgvSearchDisputes.Rows[n].Cells[4].ToString() + "';";
        }

        private void dgvSearchDisputes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("are you sure..?", "conform", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //int n = dgvSearchDisputes.CurrentCell.RowIndex;
                    //string deleteQuery = "delete from tbldispute where id=" + dgvSearchDisputes.Rows[n].Cells[0].Value + "";

                    //con.Open();

                    //MySqlCommand command = new MySqlCommand(deleteQuery, con);
                   
                    //command.ExecuteNonQuery();
                   

                    //ds1.Clear();
                   // MessageBox.Show("delet sucess", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //con.Close();
                }
            }
            catch
            {
                MessageBox.Show("කරැණාකාර ඉවත් කිරීමට ඇති පේලිය තෝරන්න", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure..?", "conform", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //int n = dgvSearchDisputes.CurrentCell.RowIndex;
                //string updateQuery = "update tbldispute set fileNo="+dgvSearchDisputes.Rows[n].Cells[1].Value+", date="+dgvSearchDisputes.Rows[n].Cells[2].Value+",name = "+ dgvSearchDisputes.Rows[n].Cells[3].Value + ", NIC = "+ dgvSearchDisputes.Rows[n].Cells[4].Value + ", address="+ dgvSearchDisputes.Rows[n].Cells[5].Value + ", description = "+ dgvSearchDisputes.Rows[n].Cells[6].Value + ", repotCallDate = "+ dgvSearchDisputes.Rows[n].Cells[7].Value + ", reportType="+ dgvSearchDisputes.Rows[n].Cells[8].Value + ", desition = "+ dgvSearchDisputes.Rows[n].Cells[9].Value + ", fileEndDate = "+ dgvSearchDisputes.Rows[n].Cells[10].Value + ", wasama = "+ dgvSearchDisputes.Rows[n].Cells[11].Value + " ";

                con.Open();

                //MySqlCommand command = new MySqlCommand(updateQuery, con);
                
                //command.ExecuteNonQuery();
                

                ds1.Clear();
                MessageBox.Show("update sucess", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
        }

        private void cmbWasama02_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds1.Clear();
            lstNIC02.Items.Clear();
            string selectQueryNIC = "SELECT NIC FROM tbldispute WHERE wasama = '" + cmbWasama02.SelectedItem.ToString() + "' order by id";
            MySqlDataAdapter adr = new MySqlDataAdapter(selectQueryNIC, con);
            adr.SelectCommand.CommandType = CommandType.Text;
            adr.Fill(ds1, "tbldispute");

            int currentRow = 0;
            int rowCuont = ds1.Tables["tbldispute"].Rows.Count;
            while (currentRow < rowCuont)
            {
                lstNIC02.Items.Add(ds1.Tables["tbldispute"].Rows[currentRow].ItemArray[0].ToString());
                currentRow++;
            }
        }

        private void lstNIC02_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM tbldispute WHERE NIC = '" + lstNIC02.SelectedItem.ToString() + "' order by id";
                MySqlDataAdapter adr = new MySqlDataAdapter(selectQuery, con);
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(ds2, "tbldispute");

                int currentRow = 0;
                int rowCuont = ds2.Tables["tbldispute"].Rows.Count;
                while (currentRow < rowCuont)
                {
                    txtDate2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[2].ToString();
                    txtFileNo2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[1].ToString();
                    cmbWasama02.SelectedItem = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[11].ToString();
                    txtName2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[3].ToString();
                    txtNIC2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[4].ToString();
                    txtAddress2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[5].ToString();
                    txtDescription2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[6].ToString();
                    txtReportCallDate2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[7].ToString();
                    cmbReportType2.SelectedItem = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[8].ToString();
                    txtDesition2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[9].ToString();
                    txtFileEndDate2.Text = ds2.Tables["tbldispute"].Rows[currentRow].ItemArray[10].ToString();
                    currentRow++;
                }
            }
            catch
            {
                MessageBox.Show("දෝෂයක්, නැවත උත්සහ කරන්න", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnDelete_Click_2(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM tbldispute WHERE NIC = '" + txtNIC2.Text + "'";
                MySqlDataAdapter adr = new MySqlDataAdapter(deleteQuery, con);
                con.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, con);
                command.ExecuteNonQuery();
                MessageBox.Show("delete sucess", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

                txtDate2.Text = "";
                txtFileNo2.Text = "";
                cmbWasama02.SelectedItem = "තේරන්න";
                txtName2.Text = "";
                txtNIC2.Text = "";
                txtAddress2.Text = "";
                txtDescription2.Text = "";
                txtReportCallDate2.Text = "";
                cmbReportType2.SelectedItem = "තේරන්න";
                txtDesition2.Text = "";
                txtFileEndDate2.Text = "";
            }
            catch
            {
                MessageBox.Show("දෝෂයක්","information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE tbldispute SET fileNo = '" + txtFileNo2.Text + "', date = '" + txtDate2.Text + "', name = '" + txtName2.Text + "', NIC = '" + txtNIC2.Text + "', address = '" + txtAddress2.Text + "', description = '" + txtDescription2.Text + "', reportCallDate = '" + txtReportCallDate2.Text + "', reportType = '" + cmbReportType2.Text + "', desition = '" + txtDesition2.Text + "', fileEndDate = '" + txtFileEndDate2.Text + "', wasama = '" + cmbWasama02.Text + "' WHERE NIC = '" + txtNIC2.Text + "'";
                MySqlDataAdapter adr = new MySqlDataAdapter(updateQuery, con);
                con.Open();
                MySqlCommand command = new MySqlCommand(updateQuery, con);
                command.ExecuteNonQuery();
                MessageBox.Show("update sucess", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch
            {
                MessageBox.Show("වැරදි ඇතලත් කිරීමකි", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtDate2.Text = "";
            txtFileNo2.Text = "";
            cmbWasama02.SelectedItem = "තේරන්න";
            txtName2.Text = "";
            txtNIC2.Text = "";
            txtAddress2.Text = "";
            txtDescription2.Text = "";
            txtReportCallDate2.Text = "";
            cmbReportType2.SelectedItem = "තේරන්න";
            txtDesition2.Text = "";
            txtFileEndDate2.Text = "";
        }
    }
}
