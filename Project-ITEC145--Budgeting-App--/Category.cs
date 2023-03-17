using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITEC145__Budgeting_App__
{
    public class Category
    {
        static public BudgetSheet budgetForm;

        private List<Control> delete = new List<Control>();
        private List<Control> valid = new List<Control>();
        public List<Button> validButton = new List<Button>();
        private string _name;
        private int _locationx;
        private int _count;
        private int _categoryLocation = budgetForm.lastLocation;
        private int _categoryIndex;
        private Button _delCategory;
        private Button _addField;

        public Category(string Name, ref int locationy, ref bool anyCategories, ref int categoryIndex)
        {
            
            _categoryLocation += 40;                //a location the category class uses to keep track of where to place controls

            _name = Name;
            _locationx = 10;
            _categoryIndex = categoryIndex;         //Keeps track of a categories ID and a new one is created each time a category class is made
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

            Label label = new Label();
            label.Text = _name;
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.ForeColor = label.ForeColor = Color.FromArgb(1, 0, 0, 0);
            label.Top = locationy;
            label.Left = _locationx + 30;
            label.Size = new Size(800, 30);
            budgetForm.Controls.Add(label);
            valid.Add(label);

            Button addField = new Button();
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
            locationy = locationy + 40;
            budgetForm.lastLocation += 30;
        }

        public void addFields_Click(object sender, EventArgs e)
        {
            //Make fields that are editable with a delete button
            TextBox textBox = new TextBox();
            textBox.Text = "Enter Field Name";
            textBox.Name = $"{_count}";
            textBox.Font = new Font("Arial", 18, FontStyle.Bold);
            textBox.ForeColor = textBox.ForeColor = Color.FromArgb(1, 0, 0, 0);
            textBox.Top = _categoryLocation;
            textBox.Left = _locationx + 40;
            textBox.Size = new Size(300, 30);
            budgetForm.Controls.Add(textBox);
            valid.Add(textBox);

            TextBox moneyBox = new TextBox();
            moneyBox.Text = "0";                                                        //Will need error checking for this
            moneyBox.Name = $"{_count}";
            moneyBox.TextAlign = HorizontalAlignment.Right;
            moneyBox.Font = new Font("Arial", 18, FontStyle.Bold);
            moneyBox.ForeColor = moneyBox.ForeColor = Color.FromArgb(1, 0, 0, 0);
            moneyBox.Top = _categoryLocation;
            moneyBox.Left = textBox.Left + 400;
            moneyBox.Size = new Size(150, 30);
            budgetForm.Controls.Add(moneyBox);
            budgetForm.variableList.Add(moneyBox);
            valid.Add(moneyBox);

            Label label = new Label();
            label.Text = "$";
            label.Name = $"{_count}";
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.ForeColor = label.ForeColor = Color.FromArgb(1, 0, 0, 0);
            label.Top = _categoryLocation;
            label.Left = moneyBox.Left - 30;
            label.Size = new Size(30, 30);
            budgetForm.Controls.Add(label);
            valid.Add(label);

            Button delField = new Button();
            delField.Text = "X";
            delField.Name = $"{_count}";
            delField.Tag = delField.Name;               //Found out about tags to send a buttons info to a click event
            delField.Top = _categoryLocation;
            delField.Left = moneyBox.Left + 160;
            delField.Click += new EventHandler(delFields_Click);
            budgetForm.Controls.Add(delField);
            valid.Add(delField);
            validButton.Add(delField);

            _categoryLocation += 40;
            budgetForm.lastLocation += 40;

            _count++;

            foreach(Category category in budgetForm.categoriesList)
            {
                int difference = 40;

                if (category._categoryIndex > this._categoryIndex)
                {
                    category._categoryLocation += difference;

                    foreach (Control control in category.valid)
                    {
                       control.Top += difference;
                    }
                }
            }

            foreach (Button addFields in validButton)
            {
                if (_categoryLocation < 800)
                {
                    if (addFields.Name == "AddField")
                    {
                        addFields.Top = _categoryLocation;
                    }
                }
            }

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
        public void delCategory_Click(object sender, EventArgs e)
        {
            int topOfCategory = _delCategory.Top;
            int bottomOfCategory = _addField.Top + 35;
            int difference = bottomOfCategory - topOfCategory;

            foreach (Category category in budgetForm.categoriesList)
            {
                if (category._categoryIndex > this._categoryIndex)
                {
                    category._categoryLocation -= difference;

                    foreach (Control control in category.valid)
                    {
                        control.Top -= difference;
                    }
                }
            }

            foreach (Control category in valid)
            {
                delete.Add(category);
            }
            valid.Clear();

            for(int i = 0; i<delete.Count; i++)
            {
                budgetForm.Controls.Remove(delete[i]);
            }

            foreach (Category category in budgetForm.categoriesList)
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
            _categoryLocation = budgetForm.lastLocation;
        }
        public void delFields_Click(object sender, EventArgs eButton)
        {
            Button clickedButton = (Button)sender;                  //Casts the sender into a button so that I can retrieve the Tag variable. (stack overflow)
            clickedButton.Name = clickedButton.Tag.ToString();      //Converts Tag to string and assigns the variable name to the tag
            int difference = 40;

            foreach (Control field in valid)
            {
                if(field.Name == clickedButton.Name)
                {
                    delete.Add(field);                              //Adds objects that have the same name (or count) as the delete button to the delete list
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

            foreach (Control field in valid)                                                //Moves valid buttons up to fill deleted buttons space
            {
                if(int.TryParse(field.Name, out int fieldName) && int.TryParse(clickedButton.Name, out int buttonName))
                {
                    if(fieldName > buttonName)
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

            foreach (Category category in budgetForm.categoriesList)
            {
                if (category._categoryIndex > this._categoryIndex)
                {
                    foreach (Control control in category.valid)
                    {
                        control.Top -= difference;
                    }
                    category._categoryLocation -= 40;
                }
            }

            foreach (Category category in budgetForm.categoriesList)
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
    }
}
