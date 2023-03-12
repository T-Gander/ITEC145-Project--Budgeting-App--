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
        static public BudgetSheet budgetForm;
        Interface CategoryFieldInterface = new Interface();
        List<Button> ButtonsList = new List<Button>();

        public CurrentBalance()
        {
            InitializeComponent();

            Buttons.balanceForm = this;

            Interface balanceForm = new Interface();
            Buttons addBalanceForm = new Buttons(100, BudgetSheet.HEIGHT, "Ok", new Font("Arial", 12), balanceForm.GetWindowCenterX(this), 50);

            Controls.Add(addBalanceForm.MakeButton(addBalanceForm.currentBalance_Click));
        }
    }
}
