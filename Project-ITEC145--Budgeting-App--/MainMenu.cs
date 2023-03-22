using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ITEC145__Budgeting_App__
{
    public partial class MainMenu : Form
    {
        Interface MainMenuInterface = new Interface();
        List<Button> buttonList = new List<Button>();

        public MainMenu()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            Interface.menuForm = this;
            BudgetSheet.menuForm = this;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Buttons NewButton = new Buttons(150, BudgetSheet.HEIGHT, "New Budget", new Font("Arial", 12, FontStyle.Regular), MainMenuInterface.GetWindowCenterX(this), 50);
            Buttons LoadButton = new Buttons(150, BudgetSheet.HEIGHT, "Load Budget", new Font("Arial", 12, FontStyle.Regular), MainMenuInterface.GetWindowCenterX(this), 100);
            Buttons InstructionsButton = new Buttons(150, BudgetSheet.HEIGHT, "Instructions", new Font("Arial", 12, FontStyle.Regular), MainMenuInterface.GetWindowCenterX(this), 150);
            Buttons ExitButton = new Buttons(150, BudgetSheet.HEIGHT, "Exit", new Font("Arial", 12, FontStyle.Regular), MainMenuInterface.GetWindowCenterX(this), 350);


            Controls.Add(NewButton.MakeButton(openBudgetSheet_Click,buttonList));
            Controls.Add(LoadButton.MakeButton(doNothing_Click, buttonList));
            Controls.Add(InstructionsButton.MakeButton(Instructions_Click, buttonList));
            Controls.Add(ExitButton.MakeButton(menuClose_Click, buttonList));
        }
        public void doNothing_Click(object sender, EventArgs e)
        {
            //For testing
        }

        public void openBudgetSheet_Click(object sender, EventArgs e)
        {
            BudgetSheet.menuForm.Hide();
            BudgetSheet budgetSheet = new BudgetSheet();
            budgetSheet.Show();
        }
        public void menuClose_Click(object sender, EventArgs e)
        {
            BudgetSheet.menuForm.Close();
        }
        public void Instructions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Thomas' Budget Sheet Software!" + "\n" + "\n" +
                            "This software is designed in a way that should be fairly straightforward to figure out yourself, but incase you need help keep reading!" + "\n" +
                            "All you need to do is follow the messagebox prompts, and then add a category to start budgeting." + "\n" + "\n" +
                            "This budgeting software assumes you are using the Envelope Budgeting method, which only lets you budget the money you currently have," +
                            " based on the current balance that you intially provide the software upon making a new budget sheet." +"\n" +
                            "Your initial balance is then added to a transactions form to keep track of any transactions you make. In order to add a transaction, press the add transaction" +
                            " button thats located next to a field, the transaction will then be added to your transactions sheet, the debit will also then be reflected in your current assignable balance " 
                            + "and also the transaction amount will be deducted from your assigned amount within your field." + "\n" +
                            "You may view the transaction form at any time by clicking the View Transactions button within your budget form." + "\n" + "\n" +
                            "Other than that, the categories button is used to help keep your budget sheet organised, and a save button is also located on the budget form so that you can load a past budget sheet you've saved." + "\n" + "\n" +
                            "Happy Budgeting!");
        }
    }
}
