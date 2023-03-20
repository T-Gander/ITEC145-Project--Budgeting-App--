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
    public partial class CategoryFieldForm : Form
    {
        public BudgetSheet budgetForm;
        Interface CategoryFieldInterface = new Interface();
        List<Button> ButtonsList = new List<Button>();

        public CategoryFieldForm(int budgetSheetIndex)
        {
            InitializeComponent();

            BudgetSheet.categoryFieldForm = this;   //Assigns this form to the buttons class
            budgetForm = BudgetSheet.budgetSheets[budgetSheetIndex];

            this.StartPosition = FormStartPosition.CenterScreen;

            Buttons OkButton = new Buttons(100, BudgetSheet.HEIGHT, "Ok", new Font("Arial", 12, FontStyle.Regular), CategoryFieldInterface.GetWindowFirstX(this), 50);
            Buttons CancelButton = new Buttons(100, BudgetSheet.HEIGHT, "Cancel", new Font("Arial", 12, FontStyle.Regular), CategoryFieldInterface.GetWindowThirdX(this), 50);

            Controls.Add(OkButton.MakeButton(budgetForm.addCategoryFieldForm_Click, ButtonsList));
            Controls.Add(CancelButton.MakeButton(budgetForm.cancelCategoryFieldForm_Click, ButtonsList));
        }
    }
}
