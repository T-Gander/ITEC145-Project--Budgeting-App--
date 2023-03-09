namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        static public MainMenu menuForm;

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

            InitializeComponent();
        }

        private void BudgetSheet_Load(object sender, EventArgs e)
        {
            Interface budgetSheet = new Interface();
            Buttons addCategory = new Buttons(100, 50, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 100);
            Buttons deleteCategory = new Buttons(100, 50, "Delete Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this)+addCategory.Width, 100);

            Controls.Add(addCategory.MakeButton(addCategory.doNothing_Click, buttonList));
            Controls.Add(deleteCategory.MakeButton(deleteCategory.doNothing_Click, buttonList));
        }
    }
}