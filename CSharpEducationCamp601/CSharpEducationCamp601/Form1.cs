using CSharpEducationCamp601.Entities;
using CSharpEducationCamp601.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEducationCamp601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerOperations customerOperations = new CustomerOperations();
            
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerCity = txtCustomerCity.Text,
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text)
            };

            customerOperations.AddCustomer(customer);
            MessageBox.Show("Müşteri ekleme işlemi başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customers;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerID.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Müşteri başarıyla silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerID.Text;
            var updateCustomer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerCity=txtCustomerCity.Text,
                CustomerShoppingCount=int.Parse(txtCustomerShoppingCount.Text),
                CustomerSurname=txtCustomerSurname.Text,
                CustomerID=id
            };
            customerOperations.updateCustomer(updateCustomer);
            MessageBox.Show("Müşteri başarıyla güncellendi");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            string id = txtCustomerID.Text;
            Customer customers = customerOperations.GetCustomerByID(id);
            dataGridView1.DataSource = new List<Customer> { customers };
        }
    }
}