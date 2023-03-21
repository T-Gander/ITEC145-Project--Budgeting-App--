using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        public static bool name = false;                                    //A bool for checking if the form has been named yet.
        public static string globalName;
        public static List<TextBox> moneyBoxes = new List<TextBox>();       //Used to calculate all moneyboxes

        public static int budgetSheetIndexAssign = 0;
        public static decimal budgetSheetCurrentBalance = 0;                                                                                            //An amount of this can likely be refactored, I got better at using classes as I worked on this project.

        public int budgetSheetIndex = 0;
        public const int HEIGHT = 50;
        public int lastLocation = 100;
        public int categoryIndex = 0;                                       //Used to keep track of categories within the form.

        public static Label currentBalance = new Label();                                 //Global balance label for all budget sheet forms
        public List<Category> categoriesList = new List<Category>();
        public List<Button> buttonList = new List<Button>();                //To keep track of all controls within the form
        public List<Label> labelList = new List<Label>();
        public List<TextBox> variableList = new List<TextBox>();

        static public BudgetSheetNameForm budgetSheetNameForm;
        static public List<BudgetSheet> budgetSheets;                       //To keep track of unique budget sheets
        static public MainMenu menuForm;                                    //So the buttons class can keep track of forms
        static public CategoryFieldForm categoryFieldForm;
        static public CurrentBalance balanceForm;

        public Button addCategoryButton;                                //Used to keep track of a forms add category button
        public Button _delCategory;                                     //Used to keep track of the delete category button.
        public Button _addField;                                        //Used to keep track of the addfield button
        public Label _currentBalance;

        public BudgetSheet()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;                        //Centers form

            Interface.budgetForm = this;
            Interface firstPage = new Interface();

            Label balance = new Label();
            currentBalance.Name = "lblCurrentBalance";                                  //Creates the balance label if the budgetsheet hasn't been named yet
            currentBalance.Text = $"Assignable : ${budgetSheetCurrentBalance}";
            currentBalance.Font = new Font("Arial", 22, FontStyle.Bold);
            currentBalance.ForeColor = Color.Green;
            currentBalance.Top = 50;
            currentBalance.Left = firstPage.GetWindowThirdX(this) - 600;
            currentBalance.Size = new Size(550, 35);
            _currentBalance = currentBalance;

            if (budgetSheets == null)
            {
                budgetSheets = new List<BudgetSheet>();                                 //Creates a budgetsheet if it doesn't already exist
                name = true;
                budgetSheetIndexAssign++;

                Interface budgetSheet = new Interface();                                    //Builds interface class (which contains calculations on finding a location on a form)

                BudgetSheetNameForm form = new BudgetSheetNameForm(this);
                form.ShowDialog();

                Labels currentBalanceLabel = new Labels(550, HEIGHT, $"Assignable : ${budgetSheetCurrentBalance}", new Font("Arial", 22, FontStyle.Bold), budgetSheet.GetWindowThirdX(this) - 350, 50, this);                          //Creates a labels class (seems a little redundant and inefficient now, but when I made this class I
                Controls.Add(currentBalanceLabel.MakeBalanceLabel());
                Labels budgetLabel = new Labels(550, HEIGHT, $"{this.Text}", new Font("Arial", 24, FontStyle.Bold), 275, 50, this);                          //Creates a labels class (seems a little redundant and inefficient now, but when I made this class I
                Controls.Add(budgetLabel.MakeHeaderLabel());

                Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 50, this);
                Controls.Add(addCategory.MakeButton(addCategory_Click, buttonList));                                                        //Same here and adds the button to this budget sheets button list
                Buttons newPage = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this) - 300, 800, this);
                Controls.Add(newPage.MakeButton(NewPage_Click, buttonList, budgetSheetIndex, true));
                Buttons nextPage = new Buttons(100, HEIGHT, "Next Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this) - 300, 800, this);
                Controls.Add(nextPage.MakeButton(NextPage_Click, buttonList, budgetSheetIndex, false));

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

                Labels currentBalanceLabel = new Labels(550, HEIGHT, $"Assignable : ${budgetSheetCurrentBalance}", new Font("Arial", 22, FontStyle.Bold), newPage.GetWindowThirdX(this) - 350, 50, this);                          //Creates a labels class (seems a little redundant and inefficient now, but when I made this class I
                Controls.Add(currentBalanceLabel.MakeBalanceLabel());
                Labels headerLabel = new Labels(800, HEIGHT, $"{globalName}", new Font("Arial", 24, FontStyle.Bold), 400, 50, this);
                Controls.Add(headerLabel.MakeHeaderLabel());

                Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), newPage.GetWindowThirdX(this), 50);
                Controls.Add(addCategory.MakeButton(addCategory_Click, buttonList));
                Buttons previousPage = new Buttons(100, HEIGHT, "Previous Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 300, 800, this);
                Controls.Add(previousPage.MakeButton(PrevPage_Click, buttonList, budgetSheetIndex, true));
                Buttons newPageButton = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 200, 800, this);
                Controls.Add(newPageButton.MakeButton(NewPage_Click, buttonList, budgetSheetIndex, true));
                Buttons nextPageButton = new Buttons(100, HEIGHT, "Next Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 200, 800, this);
                Controls.Add(nextPageButton.MakeButton(NextPage_Click, buttonList, budgetSheetIndex, false));
                Buttons deletePage = new Buttons(100, HEIGHT, "Delete Page", new Font("Arial", 12), newPage.GetWindowThirdX(this) + 100, 50, this);
                Controls.Add(deletePage.MakeButton(DeletePage_Click, buttonList, budgetSheetIndex, true));

                foreach (Button button in buttonList)
                {
                    if (button.Name == "AddCategory")
                    {
                        addCategoryButton = button;
                    }
                }

                budgetSheets.Add(this);
            }
        }
        private void BudgetSheet_Load(object sender, EventArgs e)
        {

        }
        public void addCategory_Click(object sender, EventArgs e)
        {
            CategoryFieldForm form = new CategoryFieldForm(this);
            form.ShowDialog();
        }
        public void NewPage_Click(object sender, EventArgs e)
        {
            List<BudgetSheet> globalBudgetSheets = BudgetSheet.budgetSheets;
            int currentBudgetSheetIndex = globalBudgetSheets.Count - 1;

            BudgetSheet newSheet = new BudgetSheet();

            foreach (BudgetSheet sheet in budgetSheets)
            {
                foreach (Control control in sheet.Controls)
                {
                    if (control.Name == "lblCurrentBalance")
                    {
                        control.Text = $"Assignable : ${budgetSheetCurrentBalance}";
                    }

                    if (int.TryParse(control.Name, out int result) == true)
                    {
                        if (control.Text == "New Page" && result == budgetSheetIndex)
                        {
                            control.Visible = false;
                        }

                        if (control.Text == "Next Page" && result == budgetSheetIndex)
                        {
                            control.Visible = true;
                        }
                    }
                }
            }
            globalBudgetSheets[currentBudgetSheetIndex].Hide();
            newSheet.ShowDialog();
        }
        public void PrevPage_Click(object sender, EventArgs e)
        {
            int currentIndex = budgetSheets.IndexOf(this);

            BudgetSheet lastSheet = budgetSheets[currentIndex - 1];

            this.Hide();
            lastSheet.Show();
        }
        public void NextPage_Click(object sender, EventArgs e)
        {
            int currentIndex = budgetSheets.IndexOf(this);

            BudgetSheet nextSheet = budgetSheets[currentIndex + 1];

            this.Hide();
            nextSheet.Show();
        }
        public void DeletePage_Click(object sender, EventArgs e)
        {
            int currentIndex = budgetSheets.IndexOf(this);

            if (currentIndex == 1)
            {
                BudgetSheet mainSheet = budgetSheets[0];

                foreach (Control control in mainSheet.Controls)
                {
                    if (control.Name == "lblCurrentBalance")
                    {
                        control.Text = $"Assignable : {budgetSheetCurrentBalance}";
                    }

                    if (control.Text == "Next Page")
                    {
                        control.Visible = false;
                    }

                    if (control.Text == "New Page")
                    {
                        control.Visible = true;
                    }
                }
                budgetSheets.Remove(this);
                budgetSheets[budgetSheets.Count - 1].Show();
                this.Close();
            }
            else
            {
                BudgetSheet lastSheet = budgetSheets[currentIndex - 1];

                foreach (Control control in lastSheet.Controls)
                {
                    if (control.Name == "lblCurrentBalance")
                    {
                        control.Text = $"Assignable : {budgetSheetCurrentBalance}";
                    }

                    if (control.Text == "Next Page")
                    {
                        control.Visible = false;
                    }

                    if (control.Text == "New Page")
                    {
                        control.Visible = true;
                    }
                }
                budgetSheets.Remove(this);
                lastSheet.Show();
                this.Close();
            }
        }
    }
}