using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        static public MainMenu menuForm;
        public bool name = false;                                                       //A bool for checking if the form has been named yet.
        public static string globalName;

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
            }
            else
            {
                globalName = budgetSheets[0].Text;
            }
        }

        private void BudgetSheet_Load(object sender, EventArgs e)
        {

        }

        private void timerConditions_Tick(object sender, EventArgs e)
        {
            if (name == false)
            {
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

                if (name == true)
                {
                    Labels myLabels = new Labels(550, HEIGHT, $"{this.Text}", new Font("Arial", 24, FontStyle.Bold), 275, 50);                          //Creates a labels class (seems a little redundant and inefficient now, but when I made this class I
                                                                                                                                                        // didn't completely understand classes yet...) which contains all the labels I may want to make
                    Controls.Add(myLabels.MakeHeaderLabel());

                    Buttons myButtons = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 50);

                    Controls.Add(myButtons.MakeButton(myButtons.addCategory_Click, buttonList));                                                        //Same here and adds the button to this budget sheets button list

                    //add a next page button that is invisible until all add fields fields are invisible

                    foreach (Button button in buttonList)
                    {
                        if (button.Name == "AddCategory")
                        {
                            addCategoryButton = button;
                        }
                    }

                    //When clicking create category, you can add a category, which will then allow you to assign your money to a field wothin that category.
                }
            }
            else                                    //If the original budget sheet has already been named, then create a regular "additional page" budget sheet and use the variables from the original
            {
                Interface newPage = new Interface();

                Labels myLabels = new Labels(800, HEIGHT, $"{globalName}", new Font("Arial", 24, FontStyle.Bold), 400, 50);

                Controls.Add(myLabels.MakeHeaderLabel());

                Buttons myButtons = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), newPage.GetWindowThirdX(this), 100);

                Controls.Add(myButtons.MakeButton(myButtons.addCategory_Click, buttonList));

                //add a previous page button as well as the add page

                foreach (Button button in buttonList)
                {
                    if (button.Name == "AddCategory")
                    {
                        addCategoryButton = button;
                    }
                }

                //When clicking create category, you can add a category, which will then allow you to add transactions.

                timerConditions.Enabled = false;
            }
        }
    }
}