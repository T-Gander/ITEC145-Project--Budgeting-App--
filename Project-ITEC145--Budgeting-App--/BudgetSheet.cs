namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        Interface Iinterface;
        Category category;
        CategoryField categoryField;
        Buttons buttons;
        Budgets budgets;

        List<Category> categoriesList;
        List<CategoryField> categoryFieldList;
        List<Buttons> buttonsList;
        List<Budgets> budgetsList;

        public BudgetSheet()
        {
            Interface.budgetForm = this;
            Category.mainForm = this;
            CategoryField.mainForm = this;
            Buttons.budgetForm = this;
            Budgets.mainForm = this;

            InitializeComponent();
        }

        private void BudgetSheet_Load(object sender, EventArgs e)
        {

        }
    }
}