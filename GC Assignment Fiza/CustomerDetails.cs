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
    public partial class CustomerDetails : Form
    {
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            gbCustomerDetails.Enabled = false;
            ControlStatus(false);
        }

        private void ControlStatus(bool v)
        {

        }

        private void LoadAllCustomers()
        {
            //try
            //{
            //    using (var db = new FizaDbEntities())
            //    {
            //        var res = (from c in db.TblCustomerDetails
            //                   select c).ToList();

            //        string[] arr = new string[4];
            //        ListViewItem row;

            //        foreach (var _item in res)
            //        {
            //            arr[0] = _item.PK_Customer_ID.ToString();
            //            arr[1] = _item.Name;
            //            arr[2] = _item.Phone;
            //            arr[3] = _item.Address;
            //            row = new ListViewItem(arr);
            //            lvCustomerDetails.Items.Add(row);
            //        }
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Error in Database Connectivity", "Error", 
            //        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "")
            {
                TblCustomerDetail customer = new TblCustomerDetail();

                customer = GetCustomerObject();

                AddCustomer(customer);

                MessageBox.Show("Your Receipt is here : \n "
                    + customer.Name + " "
                    + " ");
            }
            else
            {
                MessageBox.Show("Please fill up input fields.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void AddCustomer(TblCustomerDetail customer)
        {
            FizaDbEntities db = new FizaDbEntities();

            db.TblCustomerDetails.Add(customer);

            db.SaveChanges();
            
        }

        private TblCustomerDetail GetCustomerObject()
        {
            TblCustomerDetail customer = new TblCustomerDetail();

            customer.Name = tbName.Text;
            customer.Phone = tbPhone.Text;
            customer.Address = tbAddress.Text;
            customer.TotalBill = int.Parse(tbTotalBill.Text);


            #region taking brand form user as Input
            if (rbBrandBrand1.Checked)
            {
                customer.Shoe_Brand = rbBrandBrand1.Text;
            }
            else if (rbBrandBrand2.Checked)
            {
                customer.Shoe_Brand = rbBrandBrand2.Text;
            }
            else if (rbBrandBrand3.Checked)
            {
                customer.Shoe_Brand = rbBrandBrand3.Text;
            }
            else
            {
                customer.Shoe_Brand = "No Brand Selected";
            }
            #endregion

            #region Taking SHoE cOLOR as input

            if (rbColorBlack.Checked)
            {
                customer.Shoe_Color = rbColorBlack.Text;
            }
            else if (rbColorBrown.Checked)
            {
                customer.Shoe_Color = rbColorBrown.Text;
            }
            else if (rbColorWhite.Checked)
            {
                customer.Shoe_Color = rbColorWhite.Text;
            }
            else
            {
                customer.Shoe_Color = "no color selected";
            }

            #endregion

            #region Taking SHoE Size as input

            if (rbSizeSmall.Checked)
            {
                customer.Shoe_Size = rbSizeSmall.Text;
            }
            else if (rbSizeMedium.Checked)
            {
                customer.Shoe_Size = rbSizeMedium.Text;
            }
            else if (rbSizeLarge.Checked)
            {
                customer.Shoe_Size = rbSizeLarge.Text;
            }
            else
            {
                customer.Shoe_Size = "No Size";
            }

            #endregion


            return customer;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gbCustomerDetails.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnViewAllCustomerBills_Click(object sender, EventArgs e)
        {
            AllCustomersAndbills all = new AllCustomersAndbills();
            all.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gbCustomerDetails.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gbCustomerDetails.Enabled = false;

            int id = int.Parse(nudCustomerIdToSearch.Value.ToString());

            TblCustomerDetail cust = new TblCustomerDetail();
            cust = SearchCustomerById(id);
            if (cust == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                UploadCustomerObjectToControls(cust);

            }
        }

        private void UploadCustomerObjectToControls(TblCustomerDetail cust)
        {
            tbID.Text = cust.PK_Customer_ID.ToString();
            tbName.Text = cust.Name;
            tbPhone.Text = cust.Phone;
            tbAddress.Text = cust.Address;
            //tbTotalBill.Value = Convert.ToDecimal(cust.TotalBill.ToString());
            

        }

        private TblCustomerDetail SearchCustomerById(int id)
        {
            TblCustomerDetail cust = new TblCustomerDetail();

            FizaDbEntities db = new FizaDbEntities();

            var res = (from s in db.TblCustomerDetails
                       where s.PK_Customer_ID == id
                       select s).FirstOrDefault();
            cust = res;

            return cust;
        }
    }
}
