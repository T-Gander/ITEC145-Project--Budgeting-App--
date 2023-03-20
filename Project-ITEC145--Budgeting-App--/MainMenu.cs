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
            Controls.Add(InstructionsButton.MakeButton(doNothing_Click, buttonList));
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
    }
}
