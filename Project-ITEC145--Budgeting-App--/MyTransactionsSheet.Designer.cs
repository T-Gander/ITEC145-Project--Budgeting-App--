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
            this.btnClose = new System.Windows.Forms.Button();
            this.datagridTransactions = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 50);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // datagridTransactions
            // 
            this.datagridTransactions.AllowUserToAddRows = false;
            this.datagridTransactions.AllowUserToDeleteRows = false;
            this.datagridTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.transaction,
            this.delete});
            this.datagridTransactions.Location = new System.Drawing.Point(12, 12);
            this.datagridTransactions.Name = "datagridTransactions";
            this.datagridTransactions.RowTemplate.Height = 25;
            this.datagridTransactions.Size = new System.Drawing.Size(776, 372);
            this.datagridTransactions.TabIndex = 1;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.Width = 500;
            // 
            // transaction
            // 
            this.transaction.HeaderText = "Transaction Amount";
            this.transaction.Name = "transaction";
            // 
            // delete
            // 
            this.delete.HeaderText = "Delete Transaction?";
            this.delete.Name = "delete";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(12, 390);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(100, 50);
            this.btnDeleteSelected.TabIndex = 2;
            this.btnDeleteSelected.Text = "Delete Selected Transactions";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click_1);
            // 
            // MyTransactionsSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.datagridTransactions);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.Name = "MyTransactionsSheet";
            this.ShowIcon = false;
            this.Text = "MyTransactionsSheet";
            ((System.ComponentModel.ISupportInitialize)(this.datagridTransactions)).EndInit();
            this.ResumeLayout(false);

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