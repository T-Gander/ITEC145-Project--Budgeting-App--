﻿using System;
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
        private int _controlCount = 0;
        private string _budgetSheetName = "";
                                                                                            

        private List<int> _categories = new List<int>();
        private List<string> _categoryNames = new List<string>();
        private List<int> _categoryLocationy = new List<int>();
        private List<int> _categoryIndex = new List<int>();
        private List<int> _categoryMoneyBoxesCount = new List<int>();
        private List<int> _categoryCountList = new List<int>();
        private List<List<int>> _budgetSheets = new List<List<int>>();
        private List<string> _fieldNames = new List<string>();
        private List<decimal> _moneyBoxes = new List<decimal>();
        private decimal _originalBalance;

        private MyTransactionsSheet _transactions = new MyTransactionsSheet();

        public string name;
        public int locationy;
        public int categoryIndex;
        public int numberOfMoneyBoxes;

        public Save(BudgetSheet budgetSheet)
        {
            _budgetSheetName = BudgetSheet.globalName;
            _transactions = BudgetSheet.transactionsSheet;
            _originalBalance = BudgetSheet.originalBalance;

            //Code to save control data
            foreach (BudgetSheet budgetForm in BudgetSheet.budgetSheets)
            {
                _categoryCountList.Add(budgetForm.categoriesList.Count);

                for (int i = 0; i < budgetForm.categoriesList.Count; i++)
                {
                    if (budgetForm.categoriesList[i].categoryMoneyBoxList.Count == 0)
                    {
                        //Omit Category
                        name = budgetForm.categoriesList[i]._name;
                        locationy = budgetForm.categoriesList[i]._delCategory.Top - 5;
                        categoryIndex = budgetForm.categoriesList[i]._categoryIndex;
                        numberOfMoneyBoxes = budgetForm.categoriesList[i].categoryMoneyBoxList.Count;

                        _categoryNames.Add(name);
                        _categoryLocationy.Add(locationy);
                        _categoryIndex.Add(categoryIndex);
                        _categoryMoneyBoxesCount.Add(numberOfMoneyBoxes);
                        _controlCount = 0;
                    }
                    else
                    {
                        name = budgetForm.categoriesList[i]._name;
                        locationy = budgetForm.categoriesList[i]._delCategory.Top - 5;
                        categoryIndex = budgetForm.categoriesList[i]._categoryIndex;
                        numberOfMoneyBoxes = budgetForm.categoriesList[i].categoryMoneyBoxList.Count;

                        foreach(TextBox fieldName in budgetForm.categoriesList[i].categoryFieldNameList)
                        {
                            _fieldNames.Add(fieldName.Text);
                        }

                        foreach (TextBox moneyBox in budgetForm.categoriesList[i].categoryMoneyBoxList)
                        {
                            _moneyBoxes.Add(decimal.Parse(moneyBox.Text));
                        }

                        _categoryNames.Add(name);
                        _categoryLocationy.Add(locationy);
                        _categoryIndex.Add(categoryIndex);
                        _categoryMoneyBoxesCount.Add(numberOfMoneyBoxes);
                        _controlCount = 0;
                    }
                }
                _categories.Add(budgetForm.categoriesList.Count);
                _budgetSheets.Add(_categories);
            }

            using (Stream stream = File.Open("SavedData.bin", FileMode.Create))     //Stolen from Steve
            {                                                                                                   //Not enough time to finish this for project submission.
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, _budgetSheets);                               //Things to save
                bin.Serialize(stream, _budgetSheetName);
                bin.Serialize(stream, _categoryNames);
                bin.Serialize(stream, _categoryLocationy);
                bin.Serialize(stream, _categoryIndex);
                bin.Serialize(stream, _categories);
                bin.Serialize(stream, _categoryMoneyBoxesCount);
                bin.Serialize(stream, _fieldNames);
                bin.Serialize(stream, _moneyBoxes);
                bin.Serialize(stream, _originalBalance);
            }
        }
    }
}
