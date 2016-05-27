using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GC_Assignment_Fiza
{
    public partial class AllCustomersAndbills : Form
    {
        public AllCustomersAndbills()
        {
            InitializeComponent();
        }

        private void AllCustomersAndbills_Load(object sender, EventArgs e)
        {
            LoadAllCustomers();

        }

        private void LoadAllCustomers()
        {
            try
            {
                FizaDbEntities db = new FizaDbEntities();
                var res = (from s in db.TblCustomerDetails
                           select s).ToList();
                dataGridView1.DataSource = res;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
