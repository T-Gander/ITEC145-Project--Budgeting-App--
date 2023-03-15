using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        static public MainMenu menuForm;
        public bool name = false;

        public const int HEIGHT = 50;
        public int lastLocation = 100;
        public bool anyCategories = false;
        public int categoryIndex = 0;

        public Label currentBalance = new Label();
        public List<Category> categoriesList = new List<Category>();
        public List<Button> buttonList = new List<Button>();
        public List<Label> labelList = new List<Label>();
        public List<Label> variableList = new List<Label>();
        List<Budgets> budgetsList;

        public Button addCategoryButton;

        public BudgetSheet()
        {
            Interface.budgetForm = this;
            Category.budgetForm = this;
            Buttons.budgetForm = this;
            MainMenu.budgetForm = this;
            Labels.budgetForm = this;
            CategoryFieldForm.budgetForm = this;
            BudgetSheetNameForm.budgetForm = this;
            CurrentBalance.budgetForm = this;
            InitializeComponent();
        }
        private void BudgetSheet_Load(object sender, EventArgs e)
        {
            
        }
        private void timerConditions_Tick(object sender, EventArgs e)
        {
            if (name == false)
            {
                Interface budgetSheet = new Interface();
                
                currentBalance.Name = "lblCurrentBalance";
                currentBalance.Text = "Assignable: $0";
                currentBalance.Font = new Font("Arial", 22, FontStyle.Bold);
                currentBalance.ForeColor = Color.Green;
                currentBalance.Top = 50;
                currentBalance.Left = budgetSheet.GetWindowThirdX(this)-600;
                currentBalance.Size = new Size(550, 35);
                currentBalance.IsAccessible = true;
                Controls.Add(currentBalance);

                timerConditions.Enabled = false;
                BudgetSheetNameForm form = new BudgetSheetNameForm();
                form.ShowDialog();

                if (name == true)
                {
                    Labels budgetName = new Labels(550, HEIGHT, $"{this.Text}", new Font("Arial", 24, FontStyle.Bold), 275, 50);

                    Controls.Add(budgetName.MakeHeaderLabel());

                    Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 50);

                    Controls.Add(addCategory.MakeButton(addCategory.addCategory_Click, buttonList));

                    foreach(Button button in buttonList)
                    {
                        if(button.Name == "AddCategory")
                        {
                            addCategoryButton = button;
                        }
                    }

                    //When clicking create category, you can add a category, which will then allow you to add transactions.
                }
            }
            else
            {
                timerConditions.Enabled = false;

                Interface budgetSheet = new Interface();

                Labels budgetName = new Labels(800, HEIGHT, $"{this.Text}", new Font("Arial", 24, FontStyle.Bold), 400, 50);

                Controls.Add(budgetName.MakeHeaderLabel());

                Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 100);

                Controls.Add(addCategory.MakeButton(addCategory.addCategory_Click, buttonList));

                foreach (Button button in buttonList)
                {
                    if (button.Name == "Add Category")
                    {
                        addCategoryButton = button;
                    }
                }

                //When clicking create category, you can add a category, which will then allow you to add transactions.
            }

        }
    }
}