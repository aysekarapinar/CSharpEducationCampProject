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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        FinancialCrm.Models.FinancialCrmDbEntities db = new FinancialCrm.Models.FinancialCrmDbEntities();

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var categories = db.Categories.ToList();
            dataGridView1.DataSource = categories;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategory categoryForm = new FrmCategory();
            categoryForm.Show();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Kategori adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.Categories.Add(new Category { Name = categoryName });
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCategoryName.Clear();
            LoadCategories();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kategoriyi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçili satırdan kategori ID'sini alır
            int categoryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            var category = db.Categories.Find(categoryId);
            if (category != null)
            {
                var confirmation = MessageBox.Show($"{category.Name} kategorisini silmek istediğinize emin misiniz?",
                                                   "Onay",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    MessageBox.Show("Kategori başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories(); // Listeyi yenile
                }
            }
            else
            {
                MessageBox.Show("Kategori bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }
}
