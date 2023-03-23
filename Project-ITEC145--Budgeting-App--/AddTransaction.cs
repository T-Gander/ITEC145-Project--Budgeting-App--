using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ITEC145__Budgeting_App__
{
    public partial class AddTransaction : Form
    {
        private bool Credit = false;
        private bool Debit = false;

        public AddTransaction()
        {
            InitializeComponent();
        }

        private void rdoCredit_CheckedChanged(object sender, EventArgs e)
        {
            Credit = true;
            Debit = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoDebit_CheckedChanged(object sender, EventArgs e)
        {
            Debit = true;
            Credit = false;
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                if(amount > 0)
                {
                    if(Debit.Equals(true))
                    {
                        amount *= -1;
                    }
                    else
                    {
                        //Do nothing
                    }

                    DataGridViewRow newDataGridViewRow = new DataGridViewRow();

                    newDataGridViewRow.CreateCells(BudgetSheet.transactionsSheet.datagridTransactions);

                    newDataGridViewRow.Cells[0].Value = name;
                    newDataGridViewRow.Cells[1].Value = amount;

                    BudgetSheet.transactionsSheet.datagridTransactions.Rows.Insert(0,newDataGridViewRow);
                }
                else
                {
                    MessageBox.Show("Please enter a valid positive decimal");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid decimal value.");
            }
            
        }
    }
}
