using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITEC145__Budgeting_App__
{
    public class Category
    {
        public BudgetSheet budgetForm;

        public List<Control> delete = new List<Control>();             //Used to delete controls.
        public List<Control> valid = new List<Control>();              //a list of a category controls
        public List<Button> validButton = new List<Button>();           //Used to select buttons only
        private string _name;
        public int _locationx;
        public int _count;
        public int _categoryLocation;                                  //Used to assign the category location based on the next available space.
        public int _categoryIndex;                                     //Keeps track of a categories ID and a new one is created each time a category class is made

        public Category(string Name, ref int locationy, ref int categoryIndex, int budgetSheetIndex)
        {
            _categoryLocation += 40;                                    //a location the category class uses to keep track of where to place controls

            _name = Name;
            _locationx = 10;
            _categoryIndex = categoryIndex;
            budgetForm = BudgetSheet.budgetSheets[budgetSheetIndex];
            categoryIndex++;

            Button delCategory = new Button();                          
            delCategory.Text = "X";
            delCategory.Top = locationy + 5;
            delCategory.Left = _locationx;
            delCategory.Size = new Size(30,25);
            delCategory.Click += new EventHandler(budgetForm.delCategory_Click);
            budgetForm._delCategory = delCategory;
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
            addField.Click += new EventHandler(budgetForm.addFields_Click);
            budgetForm._addField = addField;
            budgetForm.Controls.Add(addField);
            valid.Add(addField);
            validButton.Add(addField);

            budgetForm.categoriesList.Add(this);
            locationy = locationy + 40;
            budgetForm.lastLocation += 30;
        }

        
        
        
    }
}
