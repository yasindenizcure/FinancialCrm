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
    public partial class FrmBill : Form
    {
        public FrmBill()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBill_Load(object sender, EventArgs e)
        {
            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillCreate_Click(object sender, EventArgs e)
        {
            string Title =txtBillTitle.Text;
            decimal Amount = decimal.Parse(txtBillAmount.Text);
            string Period = txtBillPeriod.Text;

            TblBill bill = new TblBill();
            bill.BillTitle = Title;
            bill.BillAmount = Amount;
            bill.BillPeriod = Period;
            db.TblBill.Add(bill);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı bir şekilde Eklendi", "Ödeme & Faturalar", MessageBoxButtons.OK,MessageBoxIcon.Information);


            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removeValue = db.TblBill.Find(id);
            db.TblBill.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı bir şekilde Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);


            var values = db.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillUpdate_Click(object sender, EventArgs e)
        {
            string Title = txtBillTitle.Text;
            decimal Amount = decimal.Parse(txtBillAmount.Text);
            string Period = txtBillPeriod.Text;
            int id = int.Parse(txtBillId.Text);

            var values =db.TblBill.Find(id);

            values.BillTitle = Title;
            values.BillAmount = Amount;
            values.BillPeriod = Period;
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı bir şekilde Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);


            var value = db.TblBill.ToList();
            dataGridView1.DataSource = value;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
