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
        private List<Button> validButton = new List<Button>();
        private string _name;
        private int _locationy;
        private int _locationx;
        private int _count;
        private int _categoryLocation = budgetForm.lastLocation;
        private int _categoryIndex;
        private Button _delCategory;
        private Button _addField;
        private List<Label> _convertableLabels = new List<Label>();
        private List<TextBox> _convertableTextBox = new List<TextBox>();
        private List<Label> _convertableMoneyLabels = new List<Label>();
        private List<TextBox> _convertableMoneyTextBox = new List<TextBox>();
        //Need to fix Add Fields Button

        public Category(string Name, ref int locationy, ref bool anyCategories, ref int categoryIndex)
        {
            if(budgetForm.categoriesList.Count == 0)
            {
                anyCategories = false;
                _categoryLocation += 40;
            }
            else
            {
                anyCategories = true;
            }

            if(anyCategories == true)
            {
                _categoryLocation += 40;
            }

            budgetForm.anyCategories = true;

            _name = Name;
            _locationy = locationy;
            _locationx = 10;
            _categoryIndex = categoryIndex;
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
            label.Tag = label.Text;
            budgetForm.Controls.Add(label);
            valid.Add(label);
            //Make this convertable

            Button addField = new Button();
            addField.Text = "Add Field";
            addField.Name = "AddField";
            addField.Top = locationy + 30;
            addField.Left = _locationx + 10;
            addField.Click += new EventHandler(addFields_Click);
            _addField = addField;
            budgetForm.Controls.Add(addField);
            valid.Add(addField);
            validButton.Add(addField);

            budgetForm.categoriesList.Add(this);
            locationy = locationy + 30;
            budgetForm.lastLocation += 30;
        }

        public void addFields_Click(object sender, EventArgs e)
        {
            int offFormLocation = 0;

            Label label = new Label();
            label.Text = "Click to Add Name";
            label.Name = $"{_count}";
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.ForeColor = label.ForeColor = Color.FromArgb(1, 0, 0, 0);
            label.Top = _categoryLocation;
            label.Left = _locationx + 40;
            label.Size = new Size(300, 30);
            label.Tag = label.Name;
            label.Click += new EventHandler(convertToTextbox_Click);
            _convertableLabels.Add(label);
            budgetForm.Controls.Add(label);
            valid.Add(label);

            Label moneyBox = new Label();
            moneyBox.Text = "0";                                                        //Will need error checking for this
            moneyBox.Name = $"{_count}";
            moneyBox.TextAlign = ContentAlignment.MiddleRight;
            moneyBox.Font = new Font("Arial", 18, FontStyle.Bold);
            moneyBox.ForeColor = moneyBox.ForeColor = Color.FromArgb(1, 0, 0, 0);
            moneyBox.Top = _categoryLocation;
            moneyBox.Left = label.Left + 400;
            moneyBox.Size = new Size(150, 30);
            moneyBox.Tag = moneyBox.Name;
            moneyBox.Click += new EventHandler(convertToMoneyTextbox_Click);
            _convertableMoneyLabels.Add(moneyBox);            
            budgetForm.Controls.Add(moneyBox);
            valid.Add(moneyBox);

            Label label2 = new Label();
            label2.Text = "$";
            label2.Name = $"{_count}";
            label2.Font = new Font("Arial", 18, FontStyle.Bold);
            label2.ForeColor = label2.ForeColor = Color.FromArgb(1, 0, 0, 0);
            label2.Top = _categoryLocation;
            label2.Left = moneyBox.Left - 30;
            label2.Size = new Size(30, 30);
            budgetForm.Controls.Add(label2);
            valid.Add(label2);

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
            budgetForm.lastLocation += 40;                  //Problem Location?

            foreach(Button addFields in validButton)
            {
                int location = _categoryLocation;

                if(addFields.Name == "AddField" && location < 840)
                {
                    addFields.Top = _categoryLocation;     //Problem location
                }

                if (addFields.Name == "AddField" && location > 840)
                {
                    addFields.Visible = false;                                       //Weird issue that only occurs based on auto scroll position. 
                    budgetForm.addCategoryButton.Visible = false;                    //Ended up adding a next page button
                }

            }
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
        }
        public void delCategory_Click(object sender, EventArgs e)
        {
            int topOfCategory = _delCategory.Top;
            int bottomOfCategory = _addField.Top + 25;
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
            
            budgetForm.lastLocation -= difference;
            _categoryLocation = budgetForm.lastLocation;

            if(_categoryLocation < 840)
            {
                budgetForm.addCategoryButton.Visible = true;
            }
        }
        public void delFields_Click(object sender, EventArgs eButton)
        {
            if (_categoryLocation < 880)
            {
                budgetForm.addCategoryButton.Visible = true;
            }

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
        }

        public void convertToTextbox_Click(object sender, EventArgs eButton)
        {
            Label clickedLabel = (Label)sender;
            clickedLabel.Name = clickedLabel.Tag.ToString();
            TextBox newTextBox = new TextBox();

            foreach(Label label in _convertableLabels)
            {
                if(clickedLabel.Name == label.Name)
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = label.Text;
                    textBox.Name = label.Name;
                    textBox.Font = label.Font;
                    textBox.ForeColor = label.ForeColor;
                    textBox.Top = label.Top;
                    textBox.Left = label.Left;
                    textBox.Size = label.Size;
                    textBox.Tag = label.Tag;
                    textBox.Leave += new EventHandler(convertToLabel_Leave);
                    _convertableTextBox.Add(textBox);
                    budgetForm.Controls.Add(textBox);
                    valid.Add(textBox);
                    delete.Add(label);
                    newTextBox = textBox; 
                }
            }

            foreach (Label label in _convertableMoneyLabels)
            {
                if (clickedLabel.Name == label.Name)
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = label.Text;
                    textBox.Name = label.Name;
                    textBox.Font = label.Font;
                    textBox.ForeColor = label.ForeColor;
                    textBox.Top = label.Top;
                    textBox.Left = label.Left;
                    textBox.Size = label.Size;
                    textBox.Tag = label.Tag;
                    textBox.Leave += new EventHandler(convertToLabel_Leave);
                    _convertableMoneyTextBox.Add(textBox);
                    budgetForm.Controls.Add(textBox);
                    valid.Add(textBox);
                    delete.Add(label);
                    budgetForm.variableList.Remove(label);
                    newTextBox = textBox;
                }
            }
            newTextBox.Focus();

            for (int i = 0; i < delete.Count; i++)
            {
                if (clickedLabel.Name == delete[i].Name && delete[i].GetType() == typeof(Label))
                {
                    _convertableLabels.Remove((Label)delete[i]);
                    budgetForm.Controls.Remove(delete[i]);
                    valid.Remove(delete[i]);
                }
            }
        }

        public void convertToMoneyTextbox_Click(object sender, EventArgs eButton)
        {
            Label clickedLabel = (Label)sender;
            clickedLabel.Name = clickedLabel.Tag.ToString();
            TextBox newTextBox = new TextBox();

            foreach (Label label in _convertableMoneyLabels)
            {
                if (clickedLabel.Name == label.Name)
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = label.Text;
                    textBox.Name = label.Name;
                    textBox.Font = label.Font;
                    textBox.ForeColor = label.ForeColor;
                    textBox.Top = label.Top;
                    textBox.Left = label.Left;
                    textBox.Size = label.Size;
                    textBox.Tag = label.Tag;
                    textBox.Leave += new EventHandler(convertToMoneyLabel_Leave);
                    _convertableMoneyTextBox.Add(textBox);
                    budgetForm.Controls.Add(textBox);
                    valid.Add(textBox);
                    delete.Add(label);
                    budgetForm.variableList.Remove(label);
                    newTextBox = textBox;
                }
            }
            newTextBox.Focus();

            for (int i = 0; i < delete.Count; i++)
            {
                if (clickedLabel.Name == delete[i].Name && delete[i].GetType() == typeof(Label))
                {
                    _convertableMoneyLabels.Remove((Label)delete[i]);
                    budgetForm.Controls.Remove(delete[i]);
                    valid.Remove(delete[i]);
                }
            }
        }

        public void convertToLabel_Leave(object sender, EventArgs eButton)
        {
            TextBox enteredTextbox = (TextBox)sender;
            enteredTextbox.Name = enteredTextbox.Tag.ToString();

            foreach (TextBox textBox in _convertableTextBox)
            {
                if (enteredTextbox.Name == textBox.Name)
                {
                    Label label = new Label();
                    label.Text = textBox.Text;
                    label.Name = textBox.Name;
                    label.Font = textBox.Font;
                    label.ForeColor = textBox.ForeColor;
                    label.Top = textBox.Top;
                    label.Left = textBox.Left;
                    label.Size = textBox.Size;
                    label.Tag = textBox.Tag;
                    label.Click += new EventHandler(convertToTextbox_Click);
                    _convertableLabels.Add(label);
                    budgetForm.Controls.Add(label);
                    valid.Add(label);
                    delete.Add(textBox);
                }
            }

            foreach (TextBox textBox in _convertableMoneyTextBox)
            {
                if (enteredTextbox.Name == textBox.Name)
                {
                    Label label = new Label();
                    label.Text = textBox.Text;
                    label.Name = textBox.Name;
                    label.Font = textBox.Font;
                    label.ForeColor = textBox.ForeColor;
                    label.Top = textBox.Top;
                    label.Left = textBox.Left;
                    label.Size = textBox.Size;
                    label.Tag = textBox.Tag;
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Click += new EventHandler(convertToTextbox_Click);
                    _convertableMoneyLabels.Add(label);
                    budgetForm.Controls.Add(label);
                    valid.Add(label);
                    delete.Add(textBox);
                    budgetForm.variableList.Add(label);
                }
            }

            for (int i = 0; i < delete.Count; i++)
            {
                if (enteredTextbox.Name == delete[i].Name && delete[i].GetType() == typeof(TextBox))
                {
                    _convertableTextBox.Remove((TextBox)delete[i]);
                    budgetForm.Controls.Remove(delete[i]);
                    valid.Remove(delete[i]);
                }
            }
        }
        public void convertToMoneyLabel_Leave(object sender, EventArgs eButton)
        {
            TextBox enteredTextbox = (TextBox)sender;
            enteredTextbox.Name = enteredTextbox.Tag.ToString();

            foreach (TextBox textBox in _convertableMoneyTextBox)
            {
                if (enteredTextbox.Name == textBox.Name)
                {
                    Label label = new Label();
                    label.Text = textBox.Text;
                    label.Name = textBox.Name;
                    label.Font = textBox.Font;
                    label.ForeColor = textBox.ForeColor;
                    label.Top = textBox.Top;
                    label.Left = textBox.Left;
                    label.Size = textBox.Size;
                    label.Tag = textBox.Tag;
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Click += new EventHandler(convertToMoneyTextbox_Click);
                    _convertableMoneyLabels.Add(label);
                    budgetForm.Controls.Add(label);
                    valid.Add(label);
                    delete.Add(textBox);
                    budgetForm.variableList.Add(label);
                }
            }

            for (int i = 0; i < delete.Count; i++)
            {
                if (enteredTextbox.Name == delete[i].Name && delete[i].GetType() == typeof(TextBox))
                {
                    _convertableMoneyTextBox.Remove((TextBox)delete[i]);
                    budgetForm.Controls.Remove(delete[i]);
                    valid.Remove(delete[i]);
                }
            }
        }
    }
}
