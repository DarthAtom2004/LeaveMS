using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LeaveMS
{
    public partial class Leaves : Form
    {
        Functions Con;
        public Leaves()
        {
            InitializeComponent();
            Con = new Functions();
            ShowLeaves();
            GetEmployees();
            GetCategories();
        }

        private void ShowLeaves()
        {
            string Query = "select * from LeaveTbl";
            LeaveList.DataSource = Con.GetData(Query);
        }
        private void FilterLeaves()
        {
            string Query = "select * from LeaveTbl where Status = '{0}'";
            Query = string.Format(Query, SearchCb.SelectedItem.ToString()) ;
            LeaveList.DataSource = Con.GetData(Query);
        }
        private void GetEmployees()
        {
            string Query = "select * from EmployeeTbl";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }

        private void GetCategories()
        {
            string Query = "select * from CategoryTbl";
            CatCb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            CatCb.ValueMember = Con.GetData(Query).Columns["CatId"].ToString();
            CatCb.DataSource = Con.GetData(Query);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatCb.SelectedIndex == -1 || EmpCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1 )
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    int Emp = Convert.ToInt32(EmpCb.SelectedValue.ToString());
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    string DateStart = DateStartTb.Value.Date.ToString();
                    string DateEnd = DateEndTb.Value.Date.ToString();
                    string DateApplied = DateTime.Today.Date.ToString();
                    //  string Status = StatusCb.SelectedItem.ToString();
                    string Status = "Pending";
                    string Query = "insert into LeaveTbl values({0}, {1}, '{2}', '{3}', '{4}', '{5}')";
                    Query = string.Format(Query, Emp, Category, DateStart, DateEnd, DateApplied, Status);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Отпуск добавлен");
                 /*   EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";*/
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;

        private void LeaveList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpCb.Text = LeaveList.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.Text = LeaveList.SelectedRows[0].Cells[2].Value.ToString();
            DateStartTb.Text = LeaveList.SelectedRows[0].Cells[3].Value.ToString();
            DateEndTb.Text = LeaveList.SelectedRows[0].Cells[4].Value.ToString();
            StatusCb.Text = LeaveList.SelectedRows[0].Cells[5].Value.ToString();
            if (EmpCb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(LeaveList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatCb.SelectedIndex == -1 || EmpCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    int Emp = Convert.ToInt32(EmpCb.SelectedValue.ToString());
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    string DateStart = DateStartTb.Value.Date.ToString();
                    string DateEnd = DateEndTb.Value.Date.ToString();
                    string DateApplied = DateTime.Today.Date.ToString();
                     string Status = StatusCb.SelectedItem.ToString();
                    //string Status = "Pending";
                    string Query = "Update LeaveTbl set Employee = {0}, Category = {1}, DateStart = '{2}', DateEnd = '{3}', Status = '{4}'  where LId ={5}";
                    Query = string.Format(Query, Emp, Category, DateStart, DateEnd, Status, Key);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Отпуск изменен");
                   

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatCb.SelectedIndex == -1 || EmpCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                  
                    string Query = "Delete from LeaveTbl where LId ={0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Отпуск изменен");
                   
                   

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            ShowLeaves();
        }

        private void SearchCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterLeaves();
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
