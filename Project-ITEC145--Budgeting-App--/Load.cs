﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Transactions;

namespace Project_ITEC145__Budgeting_App__
{
    internal class Load
    {
        private int _categoryCount = 0;
        private int _budgetSheetCount = 0;
        private int _controlCount = 0;
        private string _budgetSheetName = "";
        private decimal _budgetSheetBalance;
                                                                                        //Not enough time to finish this for project submission.

        private List<int> _categoriesCount = new List<int>();
        private List<List<int>> _budgetSheetsCount = new List<List<int>>();

        private MyTransactionsSheet _transactions = new MyTransactionsSheet();
        private List<BudgetSheet> _budgetSheets = new List<BudgetSheet>();
        private List<decimal> _moneyBoxes = new List<decimal>();
        private Label _currentBalance = new Label();
        private decimal _originalBalance;

        private List<string> _categoryNames;
        private List<int> _categoryLocationy;
        private List<int> _categoryIndex;
        private List<int> _categoryMoneyBoxesCount;
        private List<string> _fieldNames;



        public Load()
        {
            try
            {
                using (Stream stream = File.Open("SavedData.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    _budgetSheetsCount = (List<List<int>>)bin.Deserialize(stream);
                    _budgetSheetName = (string)bin.Deserialize(stream);
                    _categoryNames = (List<string>)bin.Deserialize(stream);
                    _categoryLocationy = (List<int>)bin.Deserialize(stream);
                    _categoryIndex = (List<int>)bin.Deserialize(stream);
                    _categoriesCount = (List<int>)bin.Deserialize(stream);
                    _categoryMoneyBoxesCount = (List<int>)bin.Deserialize(stream);
                    _fieldNames = (List<string>)bin.Deserialize(stream);
                    _moneyBoxes = (List<decimal>)bin.Deserialize(stream);
                    _originalBalance = (decimal)bin.Deserialize(stream);
                }

                BudgetSheet.globalName = _budgetSheetName;
                BudgetSheet.budgetSheets = _budgetSheets;
                BudgetSheet.budgetSheetCurrentBalance = _budgetSheetBalance;
                BudgetSheet.load = true;
                BudgetSheet.transactionsSheet = _transactions;
                BudgetSheet.currentBalance = _currentBalance;
                BudgetSheet.originalBalance = _originalBalance;

                int fieldNameCount = 0;

                for (int i = 0; i < _budgetSheetsCount.Count; i++)
                {
                    BudgetSheet loadBudgetSheet = new BudgetSheet(BudgetSheet.transactionsSheet);

                    for (int j = 0; j < _categoriesCount.Count; j++)
                    {
                        int categoryLocationy = _categoryLocationy[j];
                        int categoryIndex = _categoryIndex[j];
                        

                        Category addCategory = new Category(_categoryNames[j], ref categoryLocationy, ref categoryIndex, loadBudgetSheet);

                        for (int k = 0; k < _categoryMoneyBoxesCount[j]; k++)
                        {
                            addCategory.addFields_Load(_fieldNames[fieldNameCount], _moneyBoxes[fieldNameCount].ToString());
                            fieldNameCount++;
                        }
                    }
                    _budgetSheets.Add(loadBudgetSheet);
                }
                _budgetSheets[0].recalculateBalance();
                _budgetSheets[0].Show();
                
                

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


            }
            catch
            {
                MessageBox.Show("No saved file detected.");
            }
        }
    }
}