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
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void txtSpendingId_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = db.TblCategory.ToList();
            cmbCategory.DisplayMember = "CategoryName"; // kullanıcıya görünen
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.SelectedIndex = -1;
        }

        private void btnSpendingList_Click(object sender, EventArgs e)
        {
            var values = db.TblSpending
    .Select(x => new
    {
        x.SpendingId,
        x.SpendingTitle,
        x.SpendingAmount,
        x.SpendingDate,
        x.CategoryId,
        CategoryName = x.TblCategory.CategoryName
    })
    .ToList();

            dataGridView1.DataSource = values;
        }

        private void btnSpendingCreate_Click(object sender, EventArgs e)
        {
            string Title = txtSpendingTitle.Text;
            decimal Amount = decimal.Parse(txtSpendingAmount.Text);
            DateTime date = Convert.ToDateTime(txtSpendingDate.Text);
            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            TblSpending spending = new TblSpending();
            spending.SpendingTitle = Title;
            spending.SpendingAmount = Amount;
            spending.SpendingDate = date;
            spending.CategoryId = categoryId;
            db.TblSpending.Add(spending);
            db.SaveChanges();
            MessageBox.Show("Harcama Başarılı bir şekilde Eklendi", "Giderler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.TblSpending
    .Select(x => new
    {
        x.SpendingId,
        x.SpendingTitle,
        x.SpendingAmount,
        x.SpendingDate,
        x.CategoryId,
        CategoryName = x.TblCategory.CategoryName
    })
    .ToList();

            dataGridView1.DataSource = values;
        }

        private void btnCategoryForm_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBill frm = new FrmBill();
            frm.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnSpendingsForm_Click(object sender, EventArgs e)
        {

        }

        private void btnSpendingDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            var removeValue = db.TblSpending.Find(id);
            db.TblSpending.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Harcama Başarılı bir şekilde Silindi", "Giderler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            var values = db.TblSpending
    .Select(x => new
    {
        x.SpendingId,
        x.SpendingTitle,
        x.SpendingAmount,
        x.SpendingDate,
        x.CategoryId,
        CategoryName = x.TblCategory.CategoryName
    })
    .ToList();

            dataGridView1.DataSource = values;
        }

        private void btnSpendingUpdate_Click(object sender, EventArgs e)
        {
            string Title = txtSpendingTitle.Text;
            decimal Amount = decimal.Parse(txtSpendingAmount.Text);
            DateTime date = Convert.ToDateTime(txtSpendingDate.Text);
            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            int id = int.Parse(txtSpendingId.Text);

            var values = db.TblSpending.Find(id);
            values.SpendingTitle = Title;
            values.SpendingAmount = Amount;
            values.SpendingDate = date;
            values.CategoryId = categoryId;
            db.SaveChanges();
            MessageBox.Show("Harcama Başarılı bir şekilde Güncellendi", "Harcamalar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            var value = db.TblSpending
    .Select(x => new
    {
        x.SpendingId,
        x.SpendingTitle,
        x.SpendingAmount,
        x.SpendingDate,
        x.CategoryId,
        CategoryName = x.TblCategory.CategoryName
    })
    .ToList();

            dataGridView1.DataSource = value;
        }
    }
}
