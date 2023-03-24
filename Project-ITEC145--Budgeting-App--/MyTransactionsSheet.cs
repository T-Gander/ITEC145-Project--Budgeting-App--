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
    public partial class MyTransactionsSheet : Form
    {
        public static List<DataGridViewRow> deleteList = new List<DataGridViewRow>();

        public MyTransactionsSheet()
        {
            InitializeComponent();
            BudgetSheet.transactionsSheet = this;
        }

        private void btnDeleteSelected_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagridTransactions.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = (DataGridViewCheckBoxCell)row.Cells[2];

                if (checkboxCell.Value != null)
                {
                    if ((bool)checkboxCell.Value == true)   //Datagrids are a pain to interact with...
                    {
                        deleteList.Add(row);
                        BudgetSheet.originalBalance -= (decimal)row.Cells[1].Value;
                    }
                }
            }

            for (int i = 0; i < deleteList.Count; i++)
            {
                datagridTransactions.Rows.Remove(deleteList[i]);
            }

            deleteList.Clear();

            BudgetSheet.budgetSheets[0].recalculateBalance();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
