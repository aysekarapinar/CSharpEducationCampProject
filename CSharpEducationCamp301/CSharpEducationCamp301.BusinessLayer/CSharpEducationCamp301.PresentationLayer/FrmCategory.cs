using CSharpEducationCamp301.BusinessLayer.Abstract;
using CSharpEducationCamp301.BusinessLayer.Concrete;
using CSharpEducationCamp301.DataAccessLayer.EntityFramework;
using CSharpEducationCamp301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEducationCamp301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory(ICategoryService categoryService)
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        public FrmCategory()
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCategoryID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            var deletedValues = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme başarılı)");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updateId = int.Parse(txtCategoryID.Text);
            var updatedValue = _categoryService.TGetById(updateId);
            updatedValue.CategoryName = txtCategoryName.Text;
            updatedValue.CategoryStatus = true;
            _categoryService.TUpdate(updatedValue);
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var values=_
        }
    }
}
