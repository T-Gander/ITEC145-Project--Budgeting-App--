using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project_ITEC145__Budgeting_App__
{
    internal class Load
    {
        private int _categoryCount = 0;
        private int _budgetSheetCount = 0;
        private int _controlCount = 0;
        private string _budgetSheetName = "";


        private List<int> _categories = new List<int>();
        private List<List<int>> _budgetSheets = new List<List<int>>();

        private MyTransactionsSheet _transactions = new MyTransactionsSheet();

        public Load()
        {
            using (Stream stream = File.Open("SavedData.bin", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                _budgetSheets = (List<List<int>>)bin.Deserialize(stream);
                _budgetSheetName = (string)bin.Deserialize(stream);
            }
            _budgetSheetName = BudgetSheet.globalName;

            //Code to be loaded back in

            //foreach (BudgetSheet budgetForm in BudgetSheet.budgetSheets)
            //{
            //    List<List<int>> categories = new List<List<int>>();

            //    foreach (Category category in budgetSheet.categoriesList)
            //    {
            //        foreach (TextBox controlCount in category.categoryMoneyBoxList)
            //        {
            //            _controlCount++;
            //        }

            //        _categories.Add(_controlCount);
            //        _controlCount = 0;
            //        _categoryCount++;
            //    }
            //    _budgetSheets.Add(_categories);
            //    _categoryCount = 0;
            //    _budgetSheetCount++;
            //}

            for(int i = 0; i < _budgetSheets.Count; i++)
            {
                MyTransactionsSheet transactions = new MyTransactionsSheet();
                BudgetSheet loadBudgetSheet = new BudgetSheet(transactions);
                loadBudgetSheet.Show();
            }
        }
    }
}
