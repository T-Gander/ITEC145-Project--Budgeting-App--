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

        private string _name;
        private int _locationy;
        private int _locationx;
        public Category(string Name, ref int locationy)
        {
            _name = Name;
            _locationy = locationy;
            _locationx = 10;
            //Button to add fields
            Label label = new Label();
            label.Text = _name;
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.ForeColor = label.ForeColor = Color.FromArgb(1, 63, 100, 252);
            label.Top = locationy;
            label.Left = _locationx;
            label.Size = new Size(800, 30);
            budgetForm.Controls.Add(label);

            Button button = new Button();
            button.Text = "Add Field";
            button.Top = locationy + 30;
            button.Left = _locationx + 10;
            budgetForm.Controls.Add(button);

            budgetForm.categoriesList.Add(this);
            locationy = locationy + 60;
        }

        

    }
}
