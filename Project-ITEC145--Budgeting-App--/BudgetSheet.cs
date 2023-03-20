using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        static public MainMenu menuForm;
        public static bool name = false;                                                       //A bool for checking if the form has been named yet.
        public static string globalName;

        public static int budgetSheetIndexAssign = 0;

        public int budgetSheetIndex = 0;
        public const int HEIGHT = 50;
        public int lastLocation = 100;
        public int categoryIndex = 0;                                                   //Used to keep track of categories within the form.

        public static Label currentBalance = new Label();                               //Global balance label for all budget sheet forms
        public List<Category> categoriesList = new List<Category>();                    
        public List<Button> buttonList = new List<Button>();                            //To keep track of all controls within the form
        public List<Label> labelList = new List<Label>();
        public List<TextBox> variableList = new List<TextBox>();

        static public List<BudgetSheet> budgetSheets;                                   //To kkep track of unique budget sheets

        public Button addCategoryButton;                                                //Used to keep track of a forms add category button

        public BudgetSheet()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;                        //Centers form

            Interface.budgetForm = this;
            Category.budgetForm = this;
            Buttons.budgetForm = this;
            MainMenu.budgetForm = this;                                                 //Links all classes to this form
            Labels.budgetForm = this;
            CategoryFieldForm.budgetForm = this;
            BudgetSheetNameForm.budgetForm = this;
            CurrentBalance.budgetForm = this;

            if (budgetSheets == null)
            {
                budgetSheets = new List<BudgetSheet>();                                 //Creates a budgetsheet if it doesn't already exist
                name = true;
                budgetSheetIndexAssign++;

                Interface budgetSheet = new Interface();                                    //Builds interface class (which contains calculations on finding a location on a form)

                currentBalance.Name = "lblCurrentBalance";                                  //Creates the balance label if the budgetsheet hasn't been named yet
                currentBalance.Text = "Assignable : $0";
                currentBalance.Font = new Font("Arial", 22, FontStyle.Bold);
                currentBalance.ForeColor = Color.Green;
                currentBalance.Top = 50;
                currentBalance.Left = budgetSheet.GetWindowThirdX(this) - 600;
                currentBalance.Size = new Size(550, 35);
                currentBalance.IsAccessible = true;
                Controls.Add(currentBalance);

                timerConditions.Enabled = false;
                BudgetSheetNameForm form = new BudgetSheetNameForm();
                form.ShowDialog();

                Labels budgetLabel = new Labels(550, HEIGHT, $"{this.Text}", new Font("Arial", 24, FontStyle.Bold), 275, 50);                          //Creates a labels class (seems a little redundant and inefficient now, but when I made this class I
                                                                                                                                                        // didn't completely understand classes yet...) which contains all the labels I may want to make
                Controls.Add(budgetLabel.MakeHeaderLabel());

                Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 50);

                Controls.Add(addCategory.MakeButton(addCategory.addCategory_Click, buttonList));                                                        //Same here and adds the button to this budget sheets button list

                Buttons newPage = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this)-300, 800);
                //add a next page button that is invisible until all add fields fields are invisible

                Controls.Add(newPage.MakeButton(newPage.NewPage_Click, buttonList));

                foreach (Button button in buttonList)
                {
                    if (button.Name == "AddCategory")
                    {
                        addCategoryButton = button;
                    }
                }
                //When clicking create category, you can add a category, which will then allow you to assign your money to a field within that category.

                budgetSheets.Add(this);
            }
            else
            {
                budgetSheetIndex = budgetSheetIndexAssign;

                budgetSheetIndexAssign++;

                globalName = budgetSheets[0].Text;

                Interface newPage = new Interface();

                Labels headerLabel = new Labels(800, HEIGHT, $"{globalName}", new Font("Arial", 24, FontStyle.Bold), 400, 50);

                Controls.Add(headerLabel.MakeHeaderLabel());

                Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), newPage.GetWindowThirdX(this), 100);

                Controls.Add(addCategory.MakeButton(addCategory.addCategory_Click, buttonList));

                Buttons previousPage = new Buttons(100, HEIGHT, "Previous Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 300, 800);
                //add a previous page button as well as the add page

                Controls.Add(previousPage.MakeButton(previousPage.PrevPage_Click, buttonList));

                Buttons newPageButton = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 200, 800);

                Controls.Add(newPageButton.MakeButton(newPageButton.NewPage_Click, buttonList));    //Needs to change to next page once a new page has been made

                //Create a Next page button to swap to once a new page has been made

                foreach (Button button in buttonList)
                {
                    if (button.Name == "AddCategory")
                    {
                        addCategoryButton = button;
                    }
                }

                //When clicking create category, you can add a category, which will then allow you to add transactions.

                budgetSheets.Add(this);
            }
        }

        private void BudgetSheet_Load(object sender, EventArgs e)
        {

        }

        private void timerConditions_Tick(object sender, EventArgs e)
        {
            //Redundant
        }
    }
}