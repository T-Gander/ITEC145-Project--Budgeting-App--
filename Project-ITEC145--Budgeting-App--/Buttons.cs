using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ITEC145__Budgeting_App__
{
    internal class Buttons
    {
        static public BudgetSheet budgetForm;
        static public MainMenu menuForm;                                    //So the buttons class can keep track of forms
        static public CategoryFieldForm categoryFieldForm;
        static public BudgetSheetNameForm budgetSheetNameForm;
        static public CurrentBalance balanceForm;

        private int _width;
        private int _height;
        private string _name;
        private int _budgetSheetIndex;
        private Font _font;
        private string _text;
        private Point _location;
        public bool anyCategories = false;

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }


        public Buttons(int width, int height, string name, Font font, int locationx, int locationy, int budgetSheetIndex)
        {
            string fullname = "";
            List<string> nameparts = new List<string>();
            nameparts.AddRange(name.Split(' '));

            foreach (string namepart in nameparts)
            {
                fullname += namepart;
            }

            _width = width;
            _height = height;
            _name = fullname;
            _font = font;
            _location = new Point(locationx - (_width / 2), locationy);
            _text = name;
            _budgetSheetIndex = budgetSheetIndex;
        }

        public Buttons(int width, int height, string name, Font font, int locationx, int locationy)
        {
            string fullname = "";
            List<string> nameparts = new List<string>();
            nameparts.AddRange(name.Split(' '));

            foreach (string namepart in nameparts)
            {
                fullname += namepart;
            }

            _width = width;
            _height = height;
            _name = fullname;
            _font = font;
            _location = new Point(locationx - (_width / 2), locationy);
            _text = name;
        }

        public Button MakeButton(EventHandler clickHandler, List<Button> buttonList)         //Pain to figure this out
        {
            Button button = new Button();
            button.Name = _name;
            button.Font = _font;
            button.Text = _text;
            button.Size = new Size(_width, _height);
            button.Location = _location;
            button.Click += clickHandler;                           //Found this hint on stackoverflow
            buttonList.Add(button);
            return button;
        }

        public Button MakeButton(EventHandler clickHandler, List<Button> buttonList, int budgetSheetIndex, bool visible)         //Pain to figure this out
        {
            Button button = new Button();
            button.Name = budgetSheetIndex.ToString();
            button.Font = _font;
            button.Text = _text;
            button.Size = new Size(_width, _height);
            button.Location = _location;
            button.Click += clickHandler;                           //Found this hint on stackoverflow
            button.Visible = visible;
            buttonList.Add(button);
            return button;
        }

        public Button MakeButton(EventHandler clickHandler)         //Overload method (without adding button to list)
        {
            Button button = new Button();
            button.Name = _name;
            button.Font = _font;
            button.Text = _text;
            button.Size = new Size(_width, _height);
            button.Location = _location;
            button.Click += clickHandler;                           //Found this hint on stackoverflow
            return button;
        }

        //Click events for initialized buttons

        public void doNothing_Click(object sender, EventArgs e)
        {
            //For testing
        }
        public void nameForm_Click(object sender, EventArgs e)
        {
            Buttons.budgetForm.Text = Buttons.budgetSheetNameForm.txtBudgetName.Text;
            Buttons.budgetSheetNameForm.Close();
            CurrentBalance form = new CurrentBalance();
            form.ShowDialog();
        }
        public void menuClose_Click(object sender, EventArgs e)     
        {
            Buttons.menuForm.Close();
        }
        public void openBudgetSheet_Click(object sender, EventArgs e)
        {
            Buttons.menuForm.Hide();
            BudgetSheet budgetSheet = new BudgetSheet();
            budgetSheet.Show();
        }
        
        public void addCategoryFieldForm_Click(object sender, EventArgs e)
        {
            //Add Category to budget sheet
            string CategoryName = Buttons.categoryFieldForm.txtCategoryName.Text;
            Category newCategory = new Category(CategoryName,ref budgetForm.lastLocation, ref budgetForm.categoryIndex, _budgetSheetIndex);
            Buttons.categoryFieldForm.Close();

            foreach (Category category in budgetForm.categoriesList)
            {
                foreach (Button addFields in category.validButton)
                {
                    if (budgetForm.lastLocation > 760)
                    {
                        if (addFields.Name == "AddField")
                        {
                            addFields.Visible = false;
                        }
                    }

                    if (budgetForm.lastLocation > 680)
                    {
                        if (addFields.Name == "AddField")
                        {
                            budgetForm.addCategoryButton.Visible = false;
                        }
                    }
                }
            }
        }
        public void cancelCategoryFieldForm_Click(object sender, EventArgs e)
        {
            Buttons.categoryFieldForm.Close();
        }
        public void currentBalance_Click(object sender, EventArgs e)
        {
            switch(decimal.TryParse(Buttons.balanceForm.txtCurrentBalance.Text, out decimal result))
            {
                case true:
                    BudgetSheet.currentBalance.Text = $"Assignable : ${result}";
                    BudgetSheet.budgetSheetCurrentBalance = result;
                    //Will need to add this value to transactions sheet when I eventually make it.
                    Buttons.balanceForm.Close();
                    break;
                case false:
                    MessageBox.Show("The value entered was not in a decimal format, please try again.");
                    Buttons.balanceForm.txtCurrentBalance.Text = "";
                    break;
            }
        }
        public void NewPage_Click(object sender, EventArgs e)
        {
            List<BudgetSheet> globalBudgetSheets = BudgetSheet.budgetSheets;
            int currentBudgetSheetIndex = globalBudgetSheets.Count-1;

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
                        if (control.Text == "New Page" && result == this._budgetSheetIndex)
                        {
                            control.Visible = false;
                        }

                        if (control.Text == "Next Page" && result == this._budgetSheetIndex)
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
                        if (control.Text == "Previous Page" && result == this._budgetSheetIndex)
                        {
                            BudgetSheet.budgetSheets[_budgetSheetIndex].Hide();
                            BudgetSheet.budgetSheets[_budgetSheetIndex - 1].Show();
                        }
                    }
                }
            }
        }

        public void NextPage_Click(object sender, EventArgs e)
        {
            foreach(BudgetSheet sheet in BudgetSheet.budgetSheets)
            {
                foreach(Control control in sheet.Controls)
                {
                    if(int.TryParse(control.Name, out int result) == true)
                    {
                        if (control.Name == "lblCurrentBalance")
                        {
                            control.Text = $"Assignable : {BudgetSheet.budgetSheetCurrentBalance}";
                        }

                        if (control.Text == "Next Page" && result == this._budgetSheetIndex)
                        {
                            BudgetSheet.budgetSheets[_budgetSheetIndex].Hide();
                            BudgetSheet.budgetSheets[_budgetSheetIndex + 1].Show();
                        }
                    }
                }
            }
        }
    }
}
