﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITEC145__Budgeting_App__
{
    public class Category
    {
        public BudgetSheet budgetForm;                                 //Used to connect to the parent budgetsheet

        public List<Control> delete = new List<Control>();             //Used to delete controls.
        public List<Control> valid = new List<Control>();              //a list of a category controls
        public List<Button> validButton = new List<Button>();          //Used to select buttons only
        public List<TextBox> categoryMoneyBoxList = new List<TextBox>();
        public List<TextBox> categoryFieldNameList = new List<TextBox>();
        
        public string _name;
        public int _locationx;
        public int _count;                                             //Used to give an identifier to a category's fields
        public int _categoryLocation;                                  //Used to assign the category location based on the next available space.
        public int _categoryIndex;                                     //Keeps track of a categories ID and a new one is created each time a category class is made

        public Button _delCategory;
        private Button _addField;

        public Category(string Name, ref int locationy, ref int categoryIndex, BudgetSheet budgetSheet)
        {
            _categoryLocation = locationy;                                    //a location the category class uses to keep track of where to place controls

            _name = Name;
            _locationx = 10;
            _categoryIndex = categoryIndex;
            budgetForm = budgetSheet;
            categoryIndex++;

            Button delCategory = new Button();                          
            delCategory.Text = "X";
            delCategory.Top = locationy + 5;
            delCategory.Left = _locationx;
            delCategory.Size = new Size(30,25);
            delCategory.Click += new EventHandler(delCategory_Click);
            _delCategory = delCategory;
            budgetForm.Controls.Add(delCategory);
            valid.Add(delCategory);

            Label label = new Label();                                  //The label of the category
            label.Text = _name;
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.Top = locationy;
            label.Left = _locationx + 30;
            label.Size = new Size(800, 30);
            budgetForm.Controls.Add(label);
            valid.Add(label);

            Button addField = new Button();                             //The addfield button
            addField.Text = "Add Field";
            addField.Name = "AddField";
            addField.Top = locationy + 40;
            addField.Left = _locationx + 10;
            addField.Click += new EventHandler(addFields_Click);
            _addField = addField;
            budgetForm.Controls.Add(addField);
            valid.Add(addField);
            validButton.Add(addField);

            budgetForm.categoriesList.Add(this);
            locationy += 40;
            _categoryLocation += 40;
            budgetForm.lastLocation += 30;
        }
        public void addFields_Load(string fieldName, string fieldValue, int count)                                     //The addfield load event
        {
            //Make fields that are editable with a delete button
            TextBox textBox = new TextBox();
            textBox.Text = fieldName;
            textBox.Name = count.ToString();
            textBox.Font = new Font("Arial", 18, FontStyle.Bold);
            textBox.Top = _categoryLocation;
            textBox.Left = _locationx + 40;
            textBox.Size = new Size(300, 30);
            budgetForm.Controls.Add(textBox);
            categoryFieldNameList.Add(textBox);
            valid.Add(textBox);

            TextBox moneyBox = new TextBox();                                           //Where you enter your assigned money
            moneyBox.Text = fieldValue;
            moneyBox.Name = count.ToString();
            moneyBox.TextAlign = HorizontalAlignment.Right;
            moneyBox.Font = new Font("Arial", 18, FontStyle.Bold);
            moneyBox.Top = _categoryLocation;
            moneyBox.Left = textBox.Left + 400;
            moneyBox.Size = new Size(150, 30);
            moneyBox.LostFocus += new EventHandler(moneyBox_TextChanged);
            moneyBox.Tag = "MoneyBox";
            BudgetSheet.moneyBoxes.Add(moneyBox);
            budgetForm.Controls.Add(moneyBox);
            budgetForm.variableList.Add(moneyBox);
            categoryMoneyBoxList.Add(moneyBox);
            valid.Add(moneyBox);

            Label label = new Label();                                                  //Dollar sign label, functionally useless
            label.Text = "$";
            label.Name = count.ToString();
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.Top = _categoryLocation;
            label.Left = moneyBox.Left - 30;
            label.Size = new Size(30, 30);
            budgetForm.Controls.Add(label);
            valid.Add(label);

            Button delField = new Button();                                             //Delete field button within a category
            delField.Text = "X";
            delField.Name = count.ToString();
            delField.Tag = delField.Name;                                               //Found out about tags to send a buttons info to a click event (could probably just cast the sender to do the same thing)
            delField.Top = _categoryLocation + 2;
            delField.Left = moneyBox.Left + 160;
            delField.Click += new EventHandler(delFields_Click);
            delField.Size = new Size(30, 30);
            budgetForm.Controls.Add(delField);
            valid.Add(delField);
            validButton.Add(delField);

            Button addTransaction = new Button();                                             //Delete field button within a category
            addTransaction.Text = "Add Transaction";
            addTransaction.Name = count.ToString();
            addTransaction.Tag = addTransaction.Name;
            addTransaction.Top = _categoryLocation + 2;
            addTransaction.Left = delField.Left + 40;
            addTransaction.Size = new Size(100, 30);
            addTransaction.Click += new EventHandler(addTransaction_Click);
            budgetForm.Controls.Add(addTransaction);
            valid.Add(addTransaction);
            validButton.Add(addTransaction);

            _categoryLocation += 40;
            budgetForm.lastLocation += 40;

            foreach (Category category in budgetForm.categoriesList)                 //Used to move all controls that are below a category
            {
                int difference = 40;

                if (category._categoryIndex > _categoryIndex)
                {
                    category._categoryLocation += difference;

                    foreach (Control control in category.valid)
                    {
                        control.Top += difference;
                    }
                }
            }
            foreach (Button addFields in validButton)                               //Used to move the addfields button down that belongs to the current category
            {
                if (_categoryLocation < 800)
                {
                    if (addFields.Name == "AddField")
                    {
                        addFields.Top = _categoryLocation;
                    }
                }
            }
            foreach (Category category in budgetForm.categoriesList)                //Hides add buttons on the form so that no more buttons can be added
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
        public void addFields_Click(object sender, EventArgs e)                         //The addfield button click event
        {
            //Make fields that are editable with a delete button
            TextBox textBox = new TextBox();
            textBox.Text = "Enter Field Name";
            textBox.Name = $"{_count}";
            textBox.Font = new Font("Arial", 18, FontStyle.Bold);
            textBox.Top = _categoryLocation;
            textBox.Left = _locationx + 40;
            textBox.Size = new Size(300, 30);
            budgetForm.Controls.Add(textBox);
            categoryFieldNameList.Add(textBox);
            valid.Add(textBox);

            TextBox moneyBox = new TextBox();                                           //Where you enter your assigned money
            moneyBox.Text = "0";                                                        
            moneyBox.Name = $"{_count}";
            moneyBox.TextAlign = HorizontalAlignment.Right;
            moneyBox.Font = new Font("Arial", 18, FontStyle.Bold);
            moneyBox.Top = _categoryLocation;
            moneyBox.Left = textBox.Left + 400;
            moneyBox.Size = new Size(150, 30);
            moneyBox.LostFocus += new EventHandler(moneyBox_TextChanged);
            moneyBox.Tag = "MoneyBox";
            BudgetSheet.moneyBoxes.Add(moneyBox);
            budgetForm.Controls.Add(moneyBox);
            budgetForm.variableList.Add(moneyBox);
            categoryMoneyBoxList.Add(moneyBox);
            valid.Add(moneyBox);

            Label label = new Label();                                                  //Dollar sign label, functionally useless
            label.Text = "$";
            label.Name = $"{_count}";
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.Top = _categoryLocation;
            label.Left = moneyBox.Left - 30;
            label.Size = new Size(30, 30);
            budgetForm.Controls.Add(label);
            valid.Add(label);

            Button delField = new Button();                                             //Delete field button within a category
            delField.Text = "X";
            delField.Name = $"{_count}";
            delField.Tag = delField.Name;                                               //Found out about tags to send a buttons info to a click event (could probably just cast the sender to do the same thing)
            delField.Top = _categoryLocation+2;
            delField.Left = moneyBox.Left + 160;
            delField.Click += new EventHandler(delFields_Click);
            delField.Size = new Size(30, 30);
            budgetForm.Controls.Add(delField);
            valid.Add(delField);
            validButton.Add(delField);

            Button addTransaction = new Button();                                             //Delete field button within a category
            addTransaction.Text = "Add Transaction";
            addTransaction.Name = $"{_count}";
            addTransaction.Tag = addTransaction.Name;
            addTransaction.Top = _categoryLocation+2;
            addTransaction.Left = delField.Left + 40;
            addTransaction.Size = new Size(100, 30);
            addTransaction.Click += new EventHandler(addTransaction_Click);
            budgetForm.Controls.Add(addTransaction);
            valid.Add(addTransaction);
            validButton.Add(addTransaction);

            _categoryLocation += 40;
            budgetForm.lastLocation += 40;
            _count++;

            foreach (Category category in budgetForm.categoriesList)                 //Used to move all controls that are below a category
            {
                int difference = 40;

                if (category._categoryIndex > _categoryIndex)
                {
                    category._categoryLocation += difference;

                    foreach (Control control in category.valid)
                    {
                        control.Top += difference;
                    }
                }
            }
            foreach (Button addFields in validButton)                               //Used to move the addfields button down that belongs to the current category
            {
                if (_categoryLocation < 800)
                {
                    if (addFields.Name == "AddField")
                    {
                        addFields.Top = _categoryLocation;
                    }
                }
            }
            foreach (Category category in budgetForm.categoriesList)                //Hides add buttons on the form so that no more buttons can be added
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
        public void delFields_Click(object sender, EventArgs eButton)
        {
            Button clickedButton = (Button)sender;                  //Casts the sender into a button so that I can retrieve the Tag variable. (stack overflow)
            clickedButton.Name = clickedButton.Tag.ToString();      //Converts Tag to string and assigns the variable name to the tag
            int difference = 40;

            foreach (Control field in valid)
            {
                if (field.Name == clickedButton.Name)
                {
                    delete.Add(field);                              //Adds objects that have the same name (or count) as the delete button to the delete list
                    if (field.Tag == "MoneyBox")
                    {
                        BudgetSheet.moneyBoxes.Remove((TextBox)field);
                        budgetForm.recalculateBalance();
                    }
                }
            }
            foreach (Control field in delete)
            {
                valid.Remove(field);                                //Removes objects form the valid list in advance of being deleted
            }
            for (int i = 0; i < delete.Count; i++)
            {
                budgetForm.Controls.Remove(delete[i]);              //Deletes objects from budgetsheet
            }
            foreach (Control field in valid)                        //Moves valid buttons up to fill deleted buttons space
            {
                if (int.TryParse(field.Name, out int fieldName) && int.TryParse(clickedButton.Name, out int buttonName))
                {
                    if (fieldName > buttonName)
                    {
                        field.Top -= 40;
                    }
                }
            }
            budgetForm.lastLocation -= difference;
            _categoryLocation -= 40;

            foreach (Button addFields in validButton)
            {
                if (addFields.Name == "AddField")                   //Moves the add field button to the next field row
                {
                    addFields.Top = _categoryLocation;
                }
            }
            foreach (Category category in budgetForm.categoriesList)        //Moves categories and their controls below this one up.
            {
                if (category._categoryIndex > _categoryIndex)
                {
                    foreach (Control control in category.valid)
                    {
                        control.Top -= difference;
                    }
                    category._categoryLocation -= 40;
                }
            }
            foreach (Category category in budgetForm.categoriesList)        //Checks all categories controls and makes their add buttons visible and also shows the add category button again
            {
                foreach (Button addFields in category.validButton)
                {
                    if (_categoryLocation < 760)
                    {
                        if (addFields.Name == "AddField")
                        {
                            addFields.Visible = true;
                        }
                    }

                    if (budgetForm.lastLocation < 720)
                    {
                        if (addFields.Name == "AddField")
                        {
                            budgetForm.addCategoryButton.Visible = true;
                        }
                    }
                }
            }
        }
        public void delCategory_Click(object sender, EventArgs e)
        {
            int topOfCategory = _delCategory.Top;
            int bottomOfCategory = _addField.Top + 35;
            int difference = bottomOfCategory - topOfCategory;

            foreach (Category category in budgetForm.categoriesList)        //Used to move categories down that are below the current category
            {
                if (category._categoryIndex > _categoryIndex)
                {
                    category._categoryLocation -= difference;

                    foreach (Control control in category.valid)
                    {
                        control.Top -= difference;
                    }
                }
            }
            foreach (Control control in valid)                                 //Adds all controls in current category to the delete list
            {
                delete.Add(control);
                if (control.Tag == "MoneyBox")
                {
                    BudgetSheet.moneyBoxes.Remove((TextBox)control);
                    budgetForm.recalculateBalance();
                }
            }
            valid.Clear();

            for (int i = 0; i < delete.Count; i++)
            {
                budgetForm.Controls.Remove(delete[i]);                          //Deletes all controls assigned to be deleted
            }
            foreach (Category category in budgetForm.categoriesList)            //Checks all categories buttons, and hides them if the current category is too far down the page.
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

                    if (budgetForm.lastLocation < 760)
                    {
                        if (addFields.Name == "AddField")
                        {
                            budgetForm.addCategoryButton.Visible = true;
                        }
                    }
                }
            }

            budgetForm.lastLocation -= difference;                              
            _categoryLocation = budgetForm.lastLocation;        //This might be redundant as the category no longer functionally exists
        }
        public void moneyBox_TextChanged(object sender, EventArgs e)    //Used to update the balance on all forms when the text has changed
        {
            TextBox moneyBox = (TextBox)sender; 
            int currentIndex = BudgetSheet.moneyBoxes.IndexOf(moneyBox);
            BudgetSheet.moneyBoxes.RemoveAt(currentIndex);

            if(decimal.TryParse(moneyBox.Text, out decimal result))
            {
                decimal showedResult;
                decimal sum = 0;
                BudgetSheet.moneyBoxes.Add(moneyBox);
                foreach(TextBox allMoneyBoxes in BudgetSheet.moneyBoxes)
                {
                    sum += decimal.Parse(allMoneyBoxes.Text);                           
                }
                
                BudgetSheet.budgetSheetCurrentBalance = BudgetSheet.originalBalance - sum;
                BudgetSheet.currentBalance.Text = $"Assignable : ${BudgetSheet.budgetSheetCurrentBalance}";
            }
            else
            {
                MessageBox.Show("Please enter a value that is considered a decimal.");
                moneyBox.Text = "0";
                BudgetSheet.moneyBoxes.Insert(currentIndex, moneyBox);
            }

            budgetForm.recalculateBalance();
        }
        public void addTransaction_Click(object sender, EventArgs e)
        {
            int controlIndex = 0;
            Button thisButton = (Button)sender;
            controlIndex = int.Parse(thisButton.Tag.ToString());

            AddTransaction addTransaction = new AddTransaction(budgetForm.budgetSheetIndex, _categoryIndex, controlIndex);
            addTransaction.ShowDialog();
        }
    }
}
