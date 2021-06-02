using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoadAndLandDispute
{
    public partial class frmDeleteAndEdit : Form
    {
        public frmDeleteAndEdit()
        {
            InitializeComponent();
        }

        private void frmDeleteAndEdit_Load(object sender, EventArgs e)
        {
            txtCaseDate.Text = commons.date;
            txtFile.Text = commons.fileNo;
            cmbWasama.SelectedItem = commons.wasama;
            txtName.Text = commons.name;
            txtAddress.Text = commons.address;
            txtDescription.Text = commons.description;
            txtReportCallDate.Text = commons.reportCallDate;
            txtNIC.Text = commons.NIC;
            txtFinalDesition.Text = commons.desition;
            txtEndDate.Text = commons.reportEndDate;
            cmbReportType.SelectedItem = commons.reportType;
        }
    }
}
