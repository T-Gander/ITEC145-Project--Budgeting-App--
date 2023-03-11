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
        private string _name;
        private int _locationy;
        private int _locationx;
        public Category(string Name, ref int locationy)
        {
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
            addField.Top = locationy + 30;
            addField.Left = _locationx + 10;
            addField.Click += new EventHandler(addFields_Click);
            budgetForm.Controls.Add(addField);
            valid.Add(addField);

            budgetForm.categoriesList.Add(this);
            locationy = locationy + 60;
        }

        public void addFields_Click(object sender, EventArgs e)
        {
            //Make fields
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
