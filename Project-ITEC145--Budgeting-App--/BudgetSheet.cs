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
        public static decimal budgetSheetCurrentBalance = 0;

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

        public Button _delCategory;                                    //Used to keep track of the delete category button.
        public Button _addField;                                       //Used to keep track of the addfield button
        private BudgetSheet _budgetForm;
        private Category _workingCategory;

        public BudgetSheet()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;                        //Centers form

            Interface.budgetForm = this;
            Buttons.budgetForm = this;
            MainMenu.budgetForm = this;                                                 //Links all classes to this form
            Labels.budgetForm = this;
            CategoryFieldForm.budgetForm = this;
            BudgetSheetNameForm.budgetForm = this;
            CurrentBalance.budgetForm = this;
            _budgetForm = BudgetSheet.budgetSheets[budgetSheetIndex];


            Interface firstPage = new Interface();

            currentBalance.Name = "lblCurrentBalance";                                  //Creates the balance label if the budgetsheet hasn't been named yet
            currentBalance.Text = $"Assignable : ${budgetSheetCurrentBalance}";
            currentBalance.Font = new Font("Arial", 22, FontStyle.Bold);
            currentBalance.ForeColor = Color.Green;
            currentBalance.Top = 50;
            currentBalance.Left = firstPage.GetWindowThirdX(this) - 600;
            currentBalance.Size = new Size(550, 35);
            currentBalance.IsAccessible = true;

            if (budgetSheets == null)
            {
                budgetSheets = new List<BudgetSheet>();                                 //Creates a budgetsheet if it doesn't already exist
                name = true;
                budgetSheetIndexAssign++;

                Interface budgetSheet = new Interface();                                    //Builds interface class (which contains calculations on finding a location on a form)

                BudgetSheetNameForm form = new BudgetSheetNameForm();
                form.ShowDialog();

                Labels currentBalanceLabel = new Labels(550, HEIGHT, $"Assignable : ${budgetSheetCurrentBalance}", new Font("Arial", 22, FontStyle.Bold), budgetSheet.GetWindowThirdX(this) - 350, 50);                          //Creates a labels class (seems a little redundant and inefficient now, but when I made this class I
                                                                                                                                                       // didn't completely understand classes yet...) which contains all the labels I may want to make
                Controls.Add(currentBalanceLabel.MakeBalanceLabel());

                Labels budgetLabel = new Labels(550, HEIGHT, $"{this.Text}", new Font("Arial", 24, FontStyle.Bold), 275, 50);                          //Creates a labels class (seems a little redundant and inefficient now, but when I made this class I
                                                                                                                                                        // didn't completely understand classes yet...) which contains all the labels I may want to make
                Controls.Add(budgetLabel.MakeHeaderLabel());

                Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), budgetSheet.GetWindowThirdX(this), 50, budgetSheetIndex);

                Controls.Add(addCategory.MakeButton(addCategory_Click, buttonList));                                                        //Same here and adds the button to this budget sheets button list

                Buttons newPage = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this)-300, 800, budgetSheetIndex);

                Controls.Add(newPage.MakeButton(NewPage_Click, buttonList, budgetSheetIndex, true));

                Buttons nextPage = new Buttons(100, HEIGHT, "Next Page", new Font("Arial", 12), budgetSheet.GetWindowFirstX(this) - 300, 800, budgetSheetIndex);

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

                Labels currentBalanceLabel = new Labels(550, HEIGHT, $"Assignable : ${budgetSheetCurrentBalance}", new Font("Arial", 22, FontStyle.Bold), newPage.GetWindowThirdX(this) - 350, 50);                          //Creates a labels class (seems a little redundant and inefficient now, but when I made this class I
                                                                                                                                                                                                                                 // didn't completely understand classes yet...) which contains all the labels I may want to make
                Controls.Add(currentBalanceLabel.MakeBalanceLabel());

                Labels headerLabel = new Labels(800, HEIGHT, $"{globalName}", new Font("Arial", 24, FontStyle.Bold), 400, 50);

                Controls.Add(headerLabel.MakeHeaderLabel());

                Buttons addCategory = new Buttons(100, HEIGHT, "Add Category", new Font("Arial", 12), newPage.GetWindowThirdX(this), 50);

                Controls.Add(addCategory.MakeButton(addCategory_Click, buttonList));

                Buttons previousPage = new Buttons(100, HEIGHT, "Previous Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 300, 800, budgetSheetIndex);
                //add a previous page button as well as the add page

                Controls.Add(previousPage.MakeButton(PrevPage_Click, buttonList, budgetSheetIndex, true));

                Buttons newPageButton = new Buttons(100, HEIGHT, "New Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 200, 800, budgetSheetIndex);

                Controls.Add(newPageButton.MakeButton(NewPage_Click, buttonList, budgetSheetIndex, true));

                Buttons nextPageButton = new Buttons(100, HEIGHT, "Next Page", new Font("Arial", 12), newPage.GetWindowFirstX(this) - 200, 800, budgetSheetIndex);

                Controls.Add(nextPageButton.MakeButton(NextPage_Click, buttonList, budgetSheetIndex, false));

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
        public void addCategory_Click(object sender, EventArgs e)
        {
            CategoryFieldForm form = new CategoryFieldForm();
            form.ShowDialog();
        }
        public void delCategory_Click(object sender, EventArgs e)
        {
            int topOfCategory = _delCategory.Top;
            int bottomOfCategory = _addField.Top + 35;
            int difference = bottomOfCategory - topOfCategory;

            foreach(Category currentCategory in categoriesList)
            {
                if(currentCategory._categoryIndex == categoryIndex)
                {
                    _workingCategory = currentCategory;

                    foreach (Category category in categoriesList)                       //Used to move categories down that are below the current category
                    {
                        if (category._categoryIndex > _workingCategory._categoryIndex)
                        {
                            category._categoryLocation -= difference;

                            foreach (Control control in category.valid)
                            {
                                control.Top -= difference;
                            }
                        }
                    }

                    foreach (Control control in _workingCategory.valid)                                 //Adds all controls in current category to the delete list
                    {
                        _workingCategory.delete.Add(control);
                    }
                    _workingCategory.valid.Clear();

                    for (int i = 0; i < _workingCategory.delete.Count; i++)
                    {
                        _budgetForm.Controls.Remove(_workingCategory.delete[i]);                          //Deletes all controls
                    }

                    foreach (Category category in categoriesList)            //Checks all categories buttons, and hides them if the current category is too far down the page.
                    {
                        foreach (Button addFields in category.validButton)
                        {
                            if (category._categoryLocation < 760)
                            {
                                if (addFields.Name == "AddField")
                                {
                                    addFields.Visible = true;
                                }
                            }

                            if (_budgetForm.lastLocation < 760)
                            {
                                if (addFields.Name == "AddField")
                                {
                                    _budgetForm.addCategoryButton.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            
            lastLocation -= difference;                              //These might be redundant as the category no longer functionally exists
            _workingCategory._categoryLocation = _budgetForm.lastLocation;
        }
        public void addCategoryFieldForm_Click(object sender, EventArgs e)
        {
            //Add Category to budget sheet
            string CategoryName = Buttons.categoryFieldForm.txtCategoryName.Text;
            Category newCategory = new Category(CategoryName, ref lastLocation, ref categoryIndex, budgetSheetIndex);
            Buttons.categoryFieldForm.Close();

            foreach (Category category in categoriesList)
            {
                foreach (Button addFields in category.validButton)
                {
                    if (lastLocation > 760)
                    {
                        if (addFields.Name == "AddField")
                        {
                            addFields.Visible = false;
                        }
                    }

                    if (lastLocation > 680)
                    {
                        if (addFields.Name == "AddField")
                        {
                            addCategoryButton.Visible = false;
                        }
                    }
                }
            }
        }
        public void addFields_Click(object sender, EventArgs e)                         //The addfield button click event
        {
            //Make fields that are editable with a delete button
            TextBox textBox = new TextBox();
            textBox.Text = "Enter Field Name";
            textBox.Name = $"{_workingCategory._count}";
            textBox.Font = new Font("Arial", 18, FontStyle.Bold);
            textBox.Top = _workingCategory._categoryLocation;
            textBox.Left = _workingCategory._locationx + 40;
            textBox.Size = new Size(300, 30);
            _budgetForm.Controls.Add(textBox);
            _workingCategory.valid.Add(textBox);

            TextBox moneyBox = new TextBox();                                           //Where you enter your assigned money
            moneyBox.Text = "0";                                                        //Will need error checking for this
            moneyBox.Name = $"{_workingCategory._count}";
            moneyBox.TextAlign = HorizontalAlignment.Right;
            moneyBox.Font = new Font("Arial", 18, FontStyle.Bold);
            moneyBox.Top = _workingCategory._categoryLocation;
            moneyBox.Left = textBox.Left + 400;
            moneyBox.Size = new Size(150, 30);
            _budgetForm.Controls.Add(moneyBox);
            _budgetForm.variableList.Add(moneyBox);
            _workingCategory.valid.Add(moneyBox);

            Label label = new Label();                                                  //Dollar sign label
            label.Text = "$";
            label.Name = $"{_workingCategory._count}";
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.Top = _workingCategory._categoryLocation;
            label.Left = moneyBox.Left - 30;
            label.Size = new Size(30, 30);
            _budgetForm.Controls.Add(label);
            _workingCategory.valid.Add(label);

            Button delField = new Button();                                             //Delete field button within a category
            delField.Text = "X";
            delField.Name = $"{_workingCategory._count}";
            delField.Tag = delField.Name;               //Found out about tags to send a buttons info to a click event
            delField.Top = _workingCategory._categoryLocation;
            delField.Left = moneyBox.Left + 160;
            delField.Click += new EventHandler(_budgetForm.delFields_Click);
            _budgetForm.Controls.Add(delField);
            _workingCategory.valid.Add(delField);
            _workingCategory.validButton.Add(delField);

            _workingCategory._categoryLocation += 40;
            _budgetForm.lastLocation += 40;

            _workingCategory._count++;

            foreach (Category category in _budgetForm.categoriesList)                 //Used to move all controls that are below a category
            {
                int difference = 40;

                if (category._categoryIndex > _workingCategory._categoryIndex)
                {
                    category._categoryLocation += difference;

                    foreach (Control control in category.valid)
                    {
                        control.Top += difference;
                    }
                }
            }

            foreach (Button addFields in _workingCategory.validButton)                               //Used to move the addfields button down that belongs to the current category
            {
                if (_workingCategory._categoryLocation < 800)
                {
                    if (addFields.Name == "AddField")
                    {
                        addFields.Top = _workingCategory._categoryLocation;
                    }
                }
            }

            foreach (Category category in _budgetForm.categoriesList)                //Hides add buttons on the form so that no more buttons can be added
            {
                foreach (Button addFields in category.validButton)
                {
                    if (_budgetForm.lastLocation > 760)
                    {
                        if (addFields.Name == "AddField")
                        {
                            addFields.Visible = false;
                        }
                    }

                    if (_budgetForm.lastLocation > 680)
                    {
                        if (addFields.Name == "AddField")
                        {
                            _budgetForm.addCategoryButton.Visible = false;
                        }
                    }
                }
            }
        }
        public void delFields_Click(object sender, EventArgs eButton)
        {
            Button clickedButton = (Button)sender;                  //Casts the sender into a button so that I can retrieve the Tag variable. (stack overflow)
            clickedButton.Name = clickedButton.Tag.ToString();      //Converts Tag to string and assigns the variable name to the tag
            int difference = 40;

            foreach (Control field in _workingCategory.valid)
            {
                if (field.Name == clickedButton.Name)
                {
                    _workingCategory.delete.Add(field);                              //Adds objects that have the same name (or count) as the delete button to the delete list
                }
            }
            foreach (Control field in _workingCategory.delete)
            {
                _workingCategory.valid.Remove(field);                                //Removes objects form the valid list in advance of being deleted
            }
            for (int i = 0; i < _workingCategory.delete.Count; i++)
            {
                _budgetForm.Controls.Remove(_workingCategory.delete[i]);              //Deletes objects from budgetsheet
            }

            foreach (Control field in _workingCategory.valid)                                                //Moves valid buttons up to fill deleted buttons space
            {
                if (int.TryParse(field.Name, out int fieldName) && int.TryParse(clickedButton.Name, out int buttonName))
                {
                    if (fieldName > buttonName)
                    {
                        field.Top -= 40;
                    }
                }
            }
            _budgetForm.lastLocation -= difference;
            _workingCategory._categoryLocation -= 40;

            foreach (Button addFields in _workingCategory.validButton)
            {
                if (addFields.Name == "AddField")                   //Moves the add field button to the next field row
                {
                    addFields.Top = _workingCategory._categoryLocation;
                }
            }

            foreach (Category category in _budgetForm.categoriesList)        //Moves categories and their controls below this one up.
            {
                if (category._categoryIndex > _workingCategory._categoryIndex)
                {
                    foreach (Control control in category.valid)
                    {
                        control.Top -= difference;
                    }
                    category._categoryLocation -= 40;
                }
            }

            foreach (Category category in _budgetForm.categoriesList)        //Checks all categories controls and makes their add buttons visible and also shows the add category button again
            {
                foreach (Button addFields in category.validButton)
                {
                    if (_workingCategory._categoryLocation < 760)
                    {
                        if (addFields.Name == "AddField")
                        {
                            addFields.Visible = true;
                        }
                    }

                    if (_budgetForm.lastLocation < 720)
                    {
                        if (addFields.Name == "AddField")
                        {
                            _budgetForm.addCategoryButton.Visible = true;
                        }
                    }
                }
            }
        }
        public void cancelCategoryFieldForm_Click(object sender, EventArgs e)
        {
            Buttons.categoryFieldForm.Close();
        }
        public void NewPage_Click(object sender, EventArgs e)
        {
            List<BudgetSheet> globalBudgetSheets = BudgetSheet.budgetSheets;
            int currentBudgetSheetIndex = globalBudgetSheets.Count - 1;

            BudgetSheet newSheet = new BudgetSheet();

            foreach (BudgetSheet sheet in BudgetSheet.budgetSheets)
            {
                foreach (Control control in sheet.Controls)
                {
                    if (control.Name == "lblCurrentBalance")
                    {
                        control.Text = $"Assignable : ${BudgetSheet.budgetSheetCurrentBalance}";
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
            foreach (BudgetSheet sheet in BudgetSheet.budgetSheets)
            {
                foreach (Control control in sheet.Controls)
                {
                    if (control.Name == "lblCurrentBalance")
                    {
                        control.Text = $"Assignable : ${BudgetSheet.budgetSheetCurrentBalance}";
                    }

                    if (int.TryParse(control.Name, out int result) == true)
                    {
                        if (control.Text == "Previous Page" && result == budgetSheetIndex)
                        {
                            BudgetSheet.budgetSheets[budgetSheetIndex].Hide();
                            BudgetSheet.budgetSheets[budgetSheetIndex - 1].Show();
                        }
                    }
                }
            }
        }

        public void NextPage_Click(object sender, EventArgs e)
        {
            foreach (BudgetSheet sheet in BudgetSheet.budgetSheets)
            {
                foreach (Control control in sheet.Controls)
                {
                    if (int.TryParse(control.Name, out int result) == true)
                    {
                        if (control.Name == "lblCurrentBalance")
                        {
                            control.Text = $"Assignable : {BudgetSheet.budgetSheetCurrentBalance}";
                        }

                        if (control.Text == "Next Page" && result == budgetSheetIndex)
                        {
                            BudgetSheet.budgetSheets[budgetSheetIndex].Hide();
                            BudgetSheet.budgetSheets[budgetSheetIndex + 1].Show();
                        }
                    }
                }
            }
        }
    }
}