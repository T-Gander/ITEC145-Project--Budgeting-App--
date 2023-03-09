using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITEC145__Budgeting_App__
{
    internal class Labels
    {
        static public BudgetSheet budgetForm;

        private int _width;
        private int _height;
        private string _name;
        private Font _font;
        private string _text;
        private Size _size;
        private Point _location;

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }


        public Labels(int width, int height, string name, Font font, int locationx, int locationy)
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

        public Label MakeLabel()         
        {
            Label label = new Label();
            label.Name = _name;
            label.Font = _font;
            label.Text = _text;
            label.Size = new Size(_width, _height);
            label.Location = _location;

            return label;
        }


    }
}
