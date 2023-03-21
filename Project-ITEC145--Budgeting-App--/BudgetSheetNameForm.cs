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
    public partial class BudgetSheetNameForm : Form
    {
        private BudgetSheet _budgetForm;

        public BudgetSheetNameForm(BudgetSheet budgetSheet)
        {
            InitializeComponent();

            _budgetForm = budgetSheet;

            this.StartPosition = FormStartPosition.CenterScreen;

            BudgetSheet.budgetSheetNameForm = this;

            Interface budgetSheetNameForm = new Interface();
            Buttons nameForm = new Buttons(100, BudgetSheet.HEIGHT, "Ok", new Font("Arial", 12), budgetSheetNameForm.GetWindowCenterX(this), 50);

            Controls.Add(nameForm.MakeButton(nameForm_Click));
        }
        public void nameForm_Click(object sender, EventArgs e)
        {
            _budgetForm.Text = BudgetSheet.budgetSheetNameForm.txtBudgetName.Text;
            BudgetSheet.budgetSheetNameForm.Close();
            CurrentBalance form = new CurrentBalance();
            form.ShowDialog();
        }
    }
}
