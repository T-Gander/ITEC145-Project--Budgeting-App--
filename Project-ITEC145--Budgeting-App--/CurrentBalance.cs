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
    public partial class CurrentBalance : Form
    {
        public CurrentBalance()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            BudgetSheet.balanceForm = this;

            Interface balanceForm = new Interface();
            Buttons addBalanceForm = new Buttons(100, BudgetSheet.HEIGHT, "Ok", new Font("Arial", 12), balanceForm.GetWindowCenterX(this), 50);

            Controls.Add(addBalanceForm.MakeButton(currentBalance_Click));
        }
        public void currentBalance_Click(object sender, EventArgs e)
        {
            switch (decimal.TryParse(txtCurrentBalance.Text, out decimal result))
            {
                case true:
                    BudgetSheet.currentBalance.Text = $"Assignable : ${result}";
                    BudgetSheet.originalBalance = result;
                    //Will need to add this value to transactions sheet when I eventually make it.
                    BudgetSheet.balanceForm.Close();
                    break;
                case false:
                    MessageBox.Show("The value entered was not in a decimal format, please try again.");
                    BudgetSheet.balanceForm.txtCurrentBalance.Text = "";
                    break;
            }
        }
    }
}
