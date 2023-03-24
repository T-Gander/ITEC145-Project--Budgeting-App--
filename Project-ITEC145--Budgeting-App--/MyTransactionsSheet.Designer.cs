namespace Project_ITEC145__Budgeting_App__
{
    partial class MyTransactionsSheet
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
            btnClose = new Button();
            datagridTransactions = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            transaction = new DataGridViewTextBoxColumn();
            delete = new DataGridViewCheckBoxColumn();
            btnDeleteSelected = new Button();
            ((System.ComponentModel.ISupportInitialize)datagridTransactions).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(713, 390);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 50);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // datagridTransactions
            // 
            datagridTransactions.AllowUserToAddRows = false;
            datagridTransactions.AllowUserToDeleteRows = false;
            datagridTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridTransactions.Columns.AddRange(new DataGridViewColumn[] { name, transaction, delete });
            datagridTransactions.Location = new Point(12, 12);
            datagridTransactions.Name = "datagridTransactions";
            datagridTransactions.RowTemplate.Height = 25;
            datagridTransactions.Size = new Size(776, 372);
            datagridTransactions.TabIndex = 1;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.Name = "name";
            name.Width = 500;
            // 
            // transaction
            // 
            transaction.HeaderText = "Transaction Amount";
            transaction.Name = "transaction";
            // 
            // delete
            // 
            delete.HeaderText = "Delete Transaction?";
            delete.Name = "delete";
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.Location = new Point(12, 390);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(100, 50);
            btnDeleteSelected.TabIndex = 2;
            btnDeleteSelected.Text = "Delete Selected Transactions";
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click_1;
            // 
            // MyTransactionsSheet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btnDeleteSelected);
            Controls.Add(datagridTransactions);
            Controls.Add(btnClose);
            MaximizeBox = false;
            Name = "MyTransactionsSheet";
            ShowIcon = false;
            Text = "BudgetSheet - My Transactions";
            ((System.ComponentModel.ISupportInitialize)datagridTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn transaction;
        private DataGridViewCheckBoxColumn delete;
        private Button btnDeleteSelected;
        public DataGridView datagridTransactions;
    }
}