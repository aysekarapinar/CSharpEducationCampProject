using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }


        FinancialCrm.Models.FinancialCrmDbEntities db = new FinancialCrm.Models.FinancialCrmDbEntities();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                var accountController = new AccountController(new AppDbContext());
                accountController.Login(email, password, dataGridView1);
                MessageBox.Show("Başarılı şekilde giriş yapıldı");
            }

        }

        
    }
}
