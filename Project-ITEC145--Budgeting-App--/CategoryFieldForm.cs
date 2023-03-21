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
        private BudgetSheet _budgetForm;
        Interface CategoryFieldInterface = new Interface();
        List<Button> ButtonsList = new List<Button>();

        public CategoryFieldForm(BudgetSheet budgetSheet)
        {
            InitializeComponent();

            BudgetSheet.categoryFieldForm = this;   //Assigns this form to the buttons class
            _budgetForm = budgetSheet;

            this.StartPosition = FormStartPosition.CenterScreen;

            Buttons OkButton = new Buttons(100, BudgetSheet.HEIGHT, "Ok", new Font("Arial", 12, FontStyle.Regular), CategoryFieldInterface.GetWindowFirstX(this), 50);
            Buttons CancelButton = new Buttons(100, BudgetSheet.HEIGHT, "Cancel", new Font("Arial", 12, FontStyle.Regular), CategoryFieldInterface.GetWindowThirdX(this), 50);

            Controls.Add(OkButton.MakeButton(addCategoryFieldForm_Click, ButtonsList));
            Controls.Add(CancelButton.MakeButton(cancelCategoryFieldForm_Click, ButtonsList));
        }
        public void addCategoryFieldForm_Click(object sender, EventArgs e)
        {
            //Add Category to budget sheet
            string CategoryName = BudgetSheet.categoryFieldForm.txtCategoryName.Text;
            Category newCategory = new Category(CategoryName, ref this._budgetForm.lastLocation, ref this._budgetForm.categoryIndex, _budgetForm);
            Close();

            foreach (Category category in _budgetForm.categoriesList)
            {
                foreach (Button addFields in category.validButton)
                {
                    if (this._budgetForm.lastLocation > 760)
                    {
                        if (addFields.Name == "AddField")
                        {
                            addFields.Visible = false;
                        }
                    }

                    if (this._budgetForm.lastLocation > 680)
                    {
                        if (addFields.Name == "AddField")
                        {
                            this._budgetForm.addCategoryButton.Visible = false;
                        }
                    }
                }
            }
        }
        public void cancelCategoryFieldForm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
