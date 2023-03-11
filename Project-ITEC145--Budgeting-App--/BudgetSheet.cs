namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        static public MainMenu menuForm;
        public bool name = false;

        //Need a variable to keep track of the last control location

        List<Category> categoriesList;
        List<CategoryField> categoryFieldList;
        List<Button> buttonList = new List<Button>();
        List<Budgets> budgetsList;

        public BudgetSheet()
        {
            Interface.budgetForm = this;
            Category.budgetForm = this;
            CategoryField.budgetForm = this;
            Buttons.budgetForm = this;
            MainMenu.budgetForm = this;
            Labels.budgetForm = this;
            CategoryFieldForm.budgetForm = this;
            BudgetSheetNameForm.budgetForm = this;
            InitializeComponent();
        }

        private void BudgetSheet_Load(object sender, EventArgs e)
        {
            
            
        }

        private void timerConditions_Tick(object sender, EventArgs e)
        {
            if (name == false)
            {
                timerConditions.Enabled = false;
                BudgetSheetNameForm form = new BudgetSheetNameForm();
                form.ShowDialog();

                if (name == true)
                {
                    Interface budgetSheet = new Interface();

                    Buttons addCategory = new Buttons(100, 50, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 100);
                    Buttons deleteCategory = new Buttons(100, 50, "Delete Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this) + addCategory.Width, 100);

                    Controls.Add(addCategory.MakeButton(addCategory.addCategory_Click, buttonList));
                    Controls.Add(deleteCategory.MakeButton(deleteCategory.doNothing_Click, buttonList));
                }
            }
            else
            {

            }

        }
    }
}