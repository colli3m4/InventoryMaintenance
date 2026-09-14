using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static InventoryMaintenance.frmNewItem;

namespace InventoryMaintenance
{
    //Step 4.5: Enapulation Comment 
    //Encapsulation is demonstrated here by keeping datqa fields private (or using auto-properties with controlled access)
    // and restricting direct external modification. Access to the item's state (ItemNo, Description , Price) is managed
    //exclusively through properties , constructors and defined methods.
    public partial class frmInvMaint : Form
    {
        private List<InvItem> invitems = null;
       

        public frmInvMaint() { 
           
         InitializeComponent();
        
           
        }

        


        private void frmInvMaint_Load(object sender, EventArgs e)
        {
            invitems = InvItemDB.GetItems();
        }

        private void FillItemListBox()
        {
            lstItems.Items.Clear();
            foreach (InvItem item in invitems)
            {
                lstItems.Items.Add(item.GetDisplayText());
            }
         
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewItem newItemForm = new frmNewItem();
            InvItem invItem = newItemForm.GetNewItem();

            if (invItem != null)
            {
                invitems.Add(invItem);
                InvItemDB.SaveItems(invitems);
                FillItemListBox();

            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;
            if (i != -1)
            {
                InvItem invItem = invitems[i];
                string message = $"Are you sure you want to delete {invItem.Description}?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (button == DialogResult.Yes)
                {
                    invitems.RemoveAt(i);
                    InvItemDB.SaveItems(invitems);
                    FillItemListBox();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Error");
            }
            }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
