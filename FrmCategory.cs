using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var value = db.TblCategory.ToList();
            dataGridView1.DataSource = value;
        }


        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            string categoryname = txtCategoryName.Text;
            TblCategory category = new TblCategory();
            category.CategoryName = categoryname;
            db.TblCategory.Add(category);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı bir şekilde Eklendi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Title = txtCategoryName.Text;
            TblCategory category = new TblCategory();
            category.CategoryName = Title;
            db.TblCategory.Add(category);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı bir şekilde Eklendi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);


            var values = db.TblCategory.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.TblCategory.Find(id);
            db.TblCategory.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı bir şekilde Silindi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            var values = db.TblCategory.ToList();
            dataGridView1.DataSource = values;
        }
    }
}
