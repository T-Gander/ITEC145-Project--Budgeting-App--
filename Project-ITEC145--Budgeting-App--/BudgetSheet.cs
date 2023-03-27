using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Project_ITEC145__Budgeting_App__
{
    public partial class BudgetSheet : Form
    {
        public static bool load = false;
        public static bool name = false;                                    //A bool for checking if the form has been named yet. (May be redundant now)
        public static string globalName;                                    //Used to set the budget sheet name to all forms
        public static List<TextBox> moneyBoxes = new List<TextBox>();       //Used to calculate all moneyboxes

        public static int budgetSheetIndexAssign = 0;
        public static decimal budgetSheetCurrentBalance = 0;                //An amount of this can likely be refactored, I got better at using classes as I worked on this project.

        public int budgetSheetIndex = 0;                                    //Initial forms index which is changed later if it already exists
        public const int HEIGHT = 50;
        public int lastLocation = 100;                                      //Used to keep track of where to place controls
        public int categoryIndex = 0;                                       //Used to keep track of categories within the form.
        public static decimal originalBalance = 0;                          //May be retired once I have transactions working

        public static Label currentBalance = new Label();                   //Global balance label for all budget sheet forms
        public List<Category> categoriesList = new List<Category>();
        public List<Button> buttonList = new List<Button>();                //To keep track of all controls within the form
        public List<Label> labelList = new List<Label>();
        public List<TextBox> variableList = new List<TextBox>();

        static public BudgetSheetNameForm budgetSheetNameForm;
        static public List<BudgetSheet> budgetSheets;                       //To keep track of unique budget sheets
        static public MainMenu menuForm;                                    //So the buttons class can keep track of forms
        static public CategoryFieldForm categoryFieldForm;
        static public CurrentBalance balanceForm;
        static public MyTransactionsSheet transactionsSheet;

        public Button addCategoryButton;                                    //Used to keep track of a forms add category button
        public Button _delCategory;                                         //Used to keep track of the delete category button.
        public Button _addField;                                            //Used to keep track of the addfield button

        public BudgetSheet(MyTransactionsSheet myTransactionsSheet)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;                        //Centers form

            Interface.budgetForm = this;
            Interface firstPage = new Interface();

            CurrentBalance.budgetForm = this;

            transactionsSheet = myTransactionsSheet;

            Label balance = new Label();
            currentBalance.Name = "lblCurrentBalance";                                  //Creates the balance label if the budgetsheet hasn't been named yet
            currentBalance.Text = $"Assignable : ${budgetSheetCurrentBalance}";
            currentBalance.Font = new Font("Arial", 24, FontStyle.Bold);
            currentBalance.ForeColor = Color.Green;
            currentBalance.Top = 50;
            currentBalance.Left = firstPage.GetWindowCenterX(this) - 125;
            currentBalance.Size = new Size(540, 35);

            if (budgetSheets == null && load == false)
            {
                budgetSheetCurrentBalance = originalBalance;

                budgetSheets = new List<BudgetSheet>();                                 //Creates a budgetsheet if it doesn't already exist
                name = true;
                budgetSheetIndexAssign++;                                               //Used to keep track of budgetsheet forms

                Interface budgetSheet = new Interface();                                //Builds interface class (which contains calculations on finding a location on a form)

                BudgetSheetNameForm form = new BudgetSheetNameForm(this);

                form.ShowDialog();

                Controls.Add(currentBalance);
                Labels budgetLabel = new Labels(550, HEIGHT, $"{globalName}", new Font("Arial", 24, FontStyle.Bold), 275, 50, this); //Labels class creates customised buttons
                Controls.Add(budgetLabel.MakeHeaderLabel());

                Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this) - 250, 130, this);
                Controls.Add(addCategory.MakeButton(addCategory_Click, buttonList));    //Same here and adds the button to this budget sheets button list
                Buttons newPage = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this) - 300, 800, this);
                Controls.Add(newPage.MakeButton(NewPage_Click, buttonList, budgetSheetIndex, true));
                Buttons nextPage = new Buttons(100, HEIGHT, "Next Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this) - 300, 800, this);
                Controls.Add(nextPage.MakeButton(NextPage_Click, buttonList, budgetSheetIndex, false));
                Buttons showTransactions = new Buttons(200, HEIGHT, "Show Transactions", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 800, this);
                Controls.Add(showTransactions.MakeButton(ShowTransactions_Click, buttonList, budgetSheetIndex, true));
                Buttons exit = new Buttons(100, HEIGHT, "Exit", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this) + 300, 800, this);
                Controls.Add(exit.MakeButton(Exit_Click, buttonList, budgetSheetIndex, true));
                Buttons save = new Buttons(100, HEIGHT, "Save", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this) + 200, 800, this);
                Controls.Add(save.MakeButton(Save_Click, buttonList, budgetSheetIndex, true));

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
                if (load == true && budgetSheetIndex == 0)
                {
                    name = true;
                    budgetSheetIndexAssign++;                                               //Used to keep track of budgetsheet forms

                    Interface budgetSheet = new Interface();                                //Builds interface class (which contains calculations on finding a location on a form)

                    Controls.Add(currentBalance);
                    Labels budgetLabel = new Labels(550, HEIGHT, $"{globalName}", new Font("Arial", 24, FontStyle.Bold), 275, 50, this); //Labels class creates customised buttons
                    Controls.Add(budgetLabel.MakeHeaderLabel());

                    Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this) - 250, 130, this);
                    Controls.Add(addCategory.MakeButton(addCategory_Click, buttonList));    //Same here and adds the button to this budget sheets button list
                    Buttons newPage = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this) - 300, 800, this);
                    Controls.Add(newPage.MakeButton(NewPage_Click, buttonList, budgetSheetIndex, true));
                    Buttons nextPage = new Buttons(100, HEIGHT, "Next Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this) - 300, 800, this);
                    Controls.Add(nextPage.MakeButton(NextPage_Click, buttonList, budgetSheetIndex, false));
                    Buttons showTransactions = new Buttons(200, HEIGHT, "Show Transactions", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 800, this);              //Refactorable
                    Controls.Add(showTransactions.MakeButton(ShowTransactions_Click, buttonList, budgetSheetIndex, true));
                    Buttons exit = new Buttons(100, HEIGHT, "Exit", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this) + 300, 800, this);
                    Controls.Add(exit.MakeButton(Exit_Click, buttonList, budgetSheetIndex, true));
                    Buttons save = new Buttons(100, HEIGHT, "Save", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this) + 200, 800, this);
                    Controls.Add(save.MakeButton(Save_Click, buttonList, budgetSheetIndex, true));

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
                    foreach (Control control in budgetSheets[0].Controls)                           //Used to fix loaded budget sheets
                    {
                        if (control.Text == "New Page")
                        {
                            control.Visible = false;
                        }

                        if (control.Text == "Next Page")
                        {
                            control.Visible = true;
                        }
                    }
                    if(budgetSheets.Count > 1)      
                    {
                        foreach (Control control in budgetSheets[budgetSheets.Count - 1].Controls)
                        {
                            if (control.Text == "New Page")
                            {
                                control.Visible = false;
                            }

                            if (control.Text == "Next Page")
                            {
                                control.Visible = true;
                            }
                        }
                    }                                                                               //Used to fix loaded budget sheets

                    decimal difference = 0;

                    foreach (TextBox moneyBox in moneyBoxes)
                    {
                        difference += decimal.Parse(moneyBox.Text);
                    }

                    budgetSheetCurrentBalance = originalBalance - difference;

                    if (budgetSheetCurrentBalance < 0)
                    {
                        currentBalance.ForeColor = Color.Red;
                    }
                    else if (budgetSheetCurrentBalance > 0)
                    {
                        currentBalance.ForeColor = Color.Green;
                    }
                    else
                    {
                        currentBalance.ForeColor = Color.Black;
                    }

                    budgetSheetIndex = budgetSheetIndexAssign;
                    budgetSheetIndexAssign++;

                    Interface newPage = new Interface();

                    Controls.Add(currentBalance);
                    Labels headerLabel = new Labels(550, HEIGHT, $"{globalName}", new Font("Arial", 24, FontStyle.Bold), 275, 50, this);
                    Controls.Add(headerLabel.MakeHeaderLabel());

                    Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), newPage.GetWindowThirdX(this) - 250, 130);
                    Controls.Add(addCategory.MakeButton(addCategory_Click, buttonList));
                    Buttons previousPage = new Buttons(100, HEIGHT, "Previous Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 200, 800, this);
                    Controls.Add(previousPage.MakeButton(PrevPage_Click, buttonList, budgetSheetIndex, true));
                    Buttons newPageButton = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 100, 800, this);
                    Controls.Add(newPageButton.MakeButton(NewPage_Click, buttonList, budgetSheetIndex, true));
                    Buttons nextPageButton = new Buttons(100, HEIGHT, "Next Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 100, 800, this);
                    Controls.Add(nextPageButton.MakeButton(NextPage_Click, buttonList, budgetSheetIndex, false));
                    Buttons deletePage = new Buttons(100, HEIGHT, "Delete Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 300, 800, this);
                    Controls.Add(deletePage.MakeButton(DeletePage_Click, buttonList, budgetSheetIndex, true));
                    Buttons showTransactions = new Buttons(200, HEIGHT, "Show Transactions", new Font("Arial", 12), newPage.GetWindowThirdX(this), 800, this);
                    Controls.Add(showTransactions.MakeButton(ShowTransactions_Click, buttonList, budgetSheetIndex, true));
                    Buttons exit = new Buttons(100, HEIGHT, "Exit", new Font("Arial", 12), newPage.GetWindowThirdX(this) + 300, 800, this);
                    Controls.Add(exit.MakeButton(Exit_Click, buttonList, budgetSheetIndex, true));
                    Buttons save = new Buttons(100, HEIGHT, "Save", new Font("Arial", 12), newPage.GetWindowThirdX(this) + 200, 800, this);
                    Controls.Add(save.MakeButton(Save_Click, buttonList, budgetSheetIndex, true));

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
        }
        public void addCategory_Click(object sender, EventArgs e)
        {
            CategoryFieldForm form = new CategoryFieldForm(this);
            form.ShowDialog();
        }
        public void NewPage_Click(object sender, EventArgs e)
        {
            List<BudgetSheet> globalBudgetSheets = budgetSheets;
            int currentBudgetSheetIndex = globalBudgetSheets.Count - 1;

            BudgetSheet newSheet = new BudgetSheet(transactionsSheet);

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
            lastSheet.Controls.Add(currentBalance);
            currentBalance.BringToFront();

            Hide();
            lastSheet.Show();
        }
        public void NextPage_Click(object sender, EventArgs e)
        {
            int currentIndex = budgetSheets.IndexOf(this);

            BudgetSheet nextSheet = budgetSheets[currentIndex + 1];
            nextSheet.Controls.Add(currentBalance);
            currentBalance.BringToFront();

            Hide();
            nextSheet.Show();
        }
        public void DeletePage_Click(object sender, EventArgs e)
        {
            int currentIndex = budgetSheets.IndexOf(this);

            if (currentIndex == 1 && budgetSheets.Count == 2)
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

                foreach (Control control in budgetSheets[currentIndex].Controls)
                {
                    if (control.Tag == "MoneyBox")
                    {
                        moneyBoxes.Remove((TextBox)control);
                        recalculateBalance();
                    }
                }

                budgetSheets.Remove(this);
                mainSheet.Controls.Add(currentBalance);
                currentBalance.BringToFront();
                mainSheet.Show();

                Close();
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
                        if (budgetSheets.IndexOf(lastSheet) == 0)
                        {
                            control.Visible = true;
                        }
                    }

                    if (control.Text == "New Page")
                    {
                        control.Visible = true;
                        if (budgetSheets.IndexOf(lastSheet) == 0)
                        {
                            control.Visible = false;
                        }
                    }
                }

                foreach (Control control in budgetSheets[currentIndex].Controls)
                {
                    if (control.Tag == "MoneyBox")
                    {
                        moneyBoxes.Remove((TextBox)control);
                        recalculateBalance();
                    }
                }
                budgetSheets.Remove(this);
                lastSheet.Controls.Add(currentBalance);
                currentBalance.BringToFront();
                lastSheet.Show();
                Close();
            }
        }
        public void recalculateBalance()
        {
            decimal sum = 0;

            foreach (TextBox allMoneyBoxes in moneyBoxes)
            {
                sum += decimal.Parse(allMoneyBoxes.Text);
            }

            budgetSheetCurrentBalance = originalBalance - sum;
            if (budgetSheetCurrentBalance < 0)
            {
                currentBalance.ForeColor = Color.Red;
            }
            else if (budgetSheetCurrentBalance > 0)
            {
                currentBalance.ForeColor = Color.Green;
            }
            else
            {
                currentBalance.ForeColor = Color.Black;
            }
            currentBalance.Text = $"Assignable : ${budgetSheetCurrentBalance}";
            Controls.Add(currentBalance);
            currentBalance.BringToFront();
        }
        public void ShowTransactions_Click(object sender, EventArgs e)
        {
            transactionsSheet.Show();
        }
        public void Exit_Click(object sender, EventArgs e)
        {
            menuForm.Close();
        }
        public void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save Successful! (--Under Construction--)");

            Save saveBudgetSheet = new Save(this);
        }

    }
}