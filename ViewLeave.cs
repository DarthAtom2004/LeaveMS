using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMS
{
    public partial class ViewLeave : Form
    {
        Functions Con;
        public ViewLeave()
        {
            InitializeComponent();
            Con = new Functions();
            EmpIdLbl.Text = Login.EmpId + "";
            EmpNameLbl.Text = Login.EmpName;
            ShowLeaves();
        }
        private void ShowLeaves()
        {
            string Query = "select * from LeaveTbl where Employee = {0}";
            Query = String.Format(Query, Login.EmpId);
            LeaveList.DataSource = Con.GetData(Query);
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
