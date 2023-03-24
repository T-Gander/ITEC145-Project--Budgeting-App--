using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITEC145__Budgeting_App__
{
    [Serializable]
    public class Save
    {
        private int _categoryCount = 0;
        private int _budgetSheetCount = 0;
        private string _budgetSheetName = "";
        private List<MyTransactionsSheet> _transactions = new List<MyTransactionsSheet>();

        Save(BudgetSheet budgetSheet)
        {
            //Code to save control data
            
        }
    }
}
