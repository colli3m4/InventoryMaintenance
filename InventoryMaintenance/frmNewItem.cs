using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmNewItem : Form
    {
        public InvItem invItem = null;

        public InvItem InvItemDB { get; private set; }

        public frmNewItem()
        {
            InitializeComponent();
        }
        public InvItem GetNewItem()
        {
            this.ShowDialog();
            return invItem;
        }
      
        private bool IsValidData()
        {
            return Validator.IsPresent(txtItemNo) &&
                   Validator.IsInt32(txtItemNo) &&
                   Validator.IsPresent(txtDescription) &&
                   Validator.IsPresent(txtPrice) &&
                   Validator.IsDecimal(txtPrice);
        }
        //Monica Collins
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                int itemNo = Convert.ToInt32(txtItemNo.Text);
                string description = txtDescription.Text;
                decimal price = Convert.ToDecimal(txtPrice.Text);

                invItem = new InvItem(itemNo, description, price);
                this.Close();
            }
        }
        //Monica
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
     

                this.Close();
            }
        }
        //Step 4.5:Encapsulation Comment 
        // Encasuplation hides the data insude the class and protects it.
        //Other parts of the program can only read or change the item's info (ItemNo, Description , Price) through controlled properties and methods.

        public class InvItem
        {
            public int ItemNo { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public InvItem()
            {
                ItemNo = 0;
                Description = "";
                Price = 0.0m;
            }
            //Monica Collins
            //Step 4.4:  Constructor is a method that builds a new object .
            //Purpose: Creates a inventory item with default blank values 


            public InvItem(int itemNo, string description, decimal price)
            {
                ItemNo = itemNo;
                Description = description;
                Price = price;
            }
            //Monica Collins
            //Method to return formatted display text for the list box
            public string GetDisplayText()
            {
                return $"{ItemNo}  {Description}   ({Price})";
            }

        }
    }
}
