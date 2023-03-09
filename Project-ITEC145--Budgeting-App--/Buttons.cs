using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITEC145__Budgeting_App__
{
    internal class Buttons
    {
        static public BudgetSheet budgetForm;
        static public MainMenu menuForm;

        private int _width;
        private int _height;
        private string _name;
        private Font _font;
        private string _text;
        private Size _size;
        private Point _location;

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }


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

        public Button MakeButton()
        {
            Button button = new Button();
            button.Name = _name;
            button.Font = _font;
            button.Text = _text;
            button.Size = new Size(_width, _height);
            button.Location = _location;

            return button;
        }

        //public Button CreateMenu()
        //{
        //    //Buttons BasicButtons = new Buttons();


        //    //Button newBudgetButton = new Button();

        //    //newBudgetButton.Name = "New Budget";
        //    //newBudgetButton.Font = new Font("Arial", 12);
        //    //newBudgetButton.Text = "New Budget";
        //    //newBudgetButton.Size = new Size(_width, _height);
        //    //newBudgetButton.Location = new Point(GetWindowCenterX(menuForm) - GetHalfButtonWidth((BasicButtons)), 50);

        //    //return newBudgetButton;
        //}
    }
}
