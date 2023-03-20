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
        public BudgetSheet budgetForm;

        private int _width;
        private int _height;
        private string _name;
        private Font _font;
        private string _text;
        private Point _location;
        public bool anyCategories = false;

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }


        public Buttons(int width, int height, string name, Font font, int locationx, int locationy, int budgetSheetIndex)
        {
            budgetForm = BudgetSheet.budgetSheets[budgetSheetIndex];
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
    }
}
