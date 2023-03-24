namespace Project_ITEC145__Budgeting_App__
{
    partial class AddTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            txtAmount = new TextBox();
            btnAddTransaction = new Button();
            btnCancel = new Button();
            rdoCredit = new RadioButton();
            rdoDebit = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Transaction Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(338, 9);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 1;
            label2.Text = "Amount $.$$";
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(226, 23);
            txtName.TabIndex = 2;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(338, 27);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(99, 23);
            txtAmount.TabIndex = 3;
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Location = new Point(12, 112);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(125, 23);
            btnAddTransaction.TabIndex = 4;
            btnAddTransaction.Text = "Add Transaction";
            btnAddTransaction.UseVisualStyleBackColor = true;
            btnAddTransaction.Click += btnAddTransaction_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(338, 112);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // rdoCredit
            // 
            rdoCredit.AutoSize = true;
            rdoCredit.Location = new Point(20, 56);
            rdoCredit.Name = "rdoCredit";
            rdoCredit.Size = new Size(172, 19);
            rdoCredit.TabIndex = 6;
            rdoCredit.TabStop = true;
            rdoCredit.Text = "Credit (Positive Transaction)";
            rdoCredit.UseVisualStyleBackColor = true;
            rdoCredit.CheckedChanged += rdoCredit_CheckedChanged;
            // 
            // rdoDebit
            // 
            rdoDebit.AutoSize = true;
            rdoDebit.Location = new Point(20, 81);
            rdoDebit.Name = "rdoDebit";
            rdoDebit.Size = new Size(174, 19);
            rdoDebit.TabIndex = 7;
            rdoDebit.TabStop = true;
            rdoDebit.Text = "Debit (Negative Transaction)";
            rdoDebit.UseVisualStyleBackColor = true;
            rdoDebit.CheckedChanged += rdoDebit_CheckedChanged;
            // 
            // AddTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 147);
            Controls.Add(rdoDebit);
            Controls.Add(rdoCredit);
            Controls.Add(btnCancel);
            Controls.Add(btnAddTransaction);
            Controls.Add(txtAmount);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            MinimizeBox = false;
            Name = "AddTransaction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BudgetSheet V1 - Category - Add a Transaction";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private TextBox txtAmount;
        private Button btnAddTransaction;
        private Button btnCancel;
        private RadioButton rdoCredit;
        private RadioButton rdoDebit;
    }
}