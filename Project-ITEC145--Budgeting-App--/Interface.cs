using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITEC145__Budgeting_App__
{
    internal class Interface
    {
        static public BudgetSheet budgetForm;
        static public MainMenu menuForm;

        public Interface()
        {

        }

        public int GetWindowCenterX(Form form)
        {
            return form.ClientSize.Width / 2;
        }

        public int GetWindowThirdX(Form form)
        {
            return (form.ClientSize.Width / 4) * 3;
        }

        public int GetWindowFirstX(Form form)
        {
            return (form.ClientSize.Width / 4);
        }

        public int GetHalfButtonWidth(Buttons button)
        {
            return button.Width / 2;
        }
    }
}
