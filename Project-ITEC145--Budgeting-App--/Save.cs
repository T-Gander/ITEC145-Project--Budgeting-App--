using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project_ITEC145__Budgeting_App__
{
    [Serializable]
    internal class Save
    {
        private int _categoryCount = 0;
        private int _budgetSheetCount = 0;
        private int _controlCount = 0;
        private string _budgetSheetName = "";
                                                                                            

        private List<int> _categories = new List<int>();
        private List<List<int>> _budgetSheets = new List<List<int>>();

        private MyTransactionsSheet _transactions = new MyTransactionsSheet();

        public Save(BudgetSheet budgetSheet)
        {
            MessageBox.Show("Not Implemented.");

            //_budgetSheetName = BudgetSheet.globalName;
            //_transactions = BudgetSheet.transactionsSheet;

            ////Code to save control data
            //foreach(BudgetSheet budgetForm in BudgetSheet.budgetSheets)
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

            //using (Stream stream = File.Open("SavedData.bin", FileMode.Create))     //Stolen from Steve
            //{                                                                                                   //Not enough time to finish this for project submission.
            //    BinaryFormatter bin = new BinaryFormatter();
            //    bin.Serialize(stream, _budgetSheets);                               //Things to save
            //    bin.Serialize(stream, _budgetSheetName);
            //}
        }
    }
}
