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
        public Category(string Name, ref int locationy, ref bool anyCategories)
        {
            if(budgetForm.categoriesList.Count == 0)
            {
                anyCategories = false;
            }
            else
            {
                anyCategories = true;
            }

            if(anyCategories == true)
            {
                budgetForm.lastLocation += 40;
            }

            budgetForm.anyCategories = true;

            _name = Name;
            _locationy = locationy;
            _locationx = 10;

            Button delCategory = new Button();
            delCategory.Text = "X";
            delCategory.Top = locationy+2;
            delCategory.Left = _locationx;
            delCategory.Size = new Size(30,25);
            delCategory.Click += new EventHandler(delCategory_Click);
            budgetForm.Controls.Add(delCategory);
            valid.Add(delCategory);

            Label label = new Label();
            label.Text = _name;
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.ForeColor = label.ForeColor = Color.FromArgb(1, 63, 100, 252);
            label.Top = locationy;
            label.Left = _locationx + 30;
            label.Size = new Size(800, 30);
            budgetForm.Controls.Add(label);
            valid.Add(label);

            Button addField = new Button();
            addField.Text = "Add Field";
            addField.Name = "AddField";
            addField.Top = locationy + 30;
            addField.Left = _locationx + 10;
            addField.Click += new EventHandler(addFields_Click);
            budgetForm.Controls.Add(addField);
            valid.Add(addField);
            validButton.Add(addField);

            budgetForm.categoriesList.Add(this);
            locationy = locationy + 30;
        }

        public void addFields_Click(object sender, EventArgs e)
        {
            //Make fields that are editable with a delete button
            TextBox textBox = new TextBox();
            textBox.Text = "";
            textBox.Font = new Font("Arial", 18, FontStyle.Bold);
            textBox.ForeColor = textBox.ForeColor = Color.FromArgb(1, 63, 70, 252);
            textBox.Top = budgetForm.lastLocation;
            textBox.Left = _locationx + 40;
            textBox.Size = new Size(300, 30);
            budgetForm.Controls.Add(textBox);
            valid.Add(textBox);

            TextBox moneyBox = new TextBox();
            moneyBox.Text = "0";                                                        //Will need error checking for this
            moneyBox.TextAlign = HorizontalAlignment.Right;
            moneyBox.Font = new Font("Arial", 18, FontStyle.Bold);
            moneyBox.ForeColor = moneyBox.ForeColor = Color.FromArgb(1, 63, 70, 252);
            moneyBox.Top = budgetForm.lastLocation;
            moneyBox.Left = textBox.Left + 400;
            moneyBox.Size = new Size(150, 30);
            budgetForm.Controls.Add(moneyBox);
            budgetForm.variableList.Add(moneyBox);
            valid.Add(moneyBox);

            budgetForm.lastLocation += 40;

            foreach(Button addFields in validButton)
            {
                if(addFields.Name == "AddField")
                {
                    addFields.Top = budgetForm.lastLocation;
                }
            }
        }
        public void delCategory_Click(object sender, EventArgs e)
        {
            foreach(Control category in valid)
            {
                delete.Add(category);
            }
            valid.Clear();

            for(int i = 0; i<delete.Count; i++)
            {
                budgetForm.Controls.Remove(delete[i]);
            }

            budgetForm.lastLocation = _locationy;
        }
    }
}
