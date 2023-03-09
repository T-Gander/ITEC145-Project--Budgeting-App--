namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        static public MainMenu menuForm;

        Interface Iinterface;
        Category category;
        CategoryField categoryField;
        Buttons buttons;
        Budgets budgets;
        MainMenu mainMenu;

        List<Category> categoriesList;
        List<CategoryField> categoryFieldList;
        List<Buttons> buttonsList;
        List<Budgets> budgetsList;

        public BudgetSheet()
        {
            Interface.budgetForm = this;
            Category.budgetForm = this;
            CategoryField.budgetForm = this;
            Buttons.budgetForm = this;
            MainMenu.budgetForm = this;

            InitializeComponent();
        }

        private void BudgetSheet_Load(object sender, EventArgs e)
        {

        }
    }
}