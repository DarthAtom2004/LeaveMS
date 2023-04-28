using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace LeaveMS
{
    public partial class Login : Form
    {
        Functions Con;
        public Login()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public static int EmpId;
        public static string EmpName = "";
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTbl.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Нет данных");
            }
            else
            {
                if (UNameTbl.Text == "Admin" && PasswordTb.Text == "12345")
                {
                    Employees Obj = new Employees();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    try
                    {
                        string Query = "Select * from EmployeeTbl where EmpName = '{0}' and EmpPass = '{1}'";
                        Query = string.Format(Query, UNameTbl.Text, PasswordTb.Text);
                        DataTable dt = Con.GetData(Query);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Неправильный пароль");
                            UNameTbl.Text = "";
                            PasswordTb.Text = "";
                        }
                        else
                        {
                            EmpId = Convert.ToInt32(dt.Rows[0][0].ToString());
                            EmpName = dt.Rows[0][1].ToString();
                            ViewLeave Obj = new ViewLeave();
                            Obj.Show();
                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}