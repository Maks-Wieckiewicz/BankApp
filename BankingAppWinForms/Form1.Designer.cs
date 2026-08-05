using System.ComponentModel;

namespace BankingAppWinForms;

partial class Form1
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        OwnerTxt = new System.Windows.Forms.TextBox();
        AmountNum = new System.Windows.Forms.NumericUpDown();
        BankAccountsGrid = new System.Windows.Forms.DataGridView();
        CreateAccountBtn = new System.Windows.Forms.Button();
        DepositBtn = new System.Windows.Forms.Button();
        WithdrawBtn = new System.Windows.Forms.Button();
        label3 = new System.Windows.Forms.Label();
        InterestsNum = new System.Windows.Forms.NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)AmountNum).BeginInit();
        ((System.ComponentModel.ISupportInitialize)BankAccountsGrid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)InterestsNum).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        label1.Location = new System.Drawing.Point(26, 20);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(91, 39);
        label1.TabIndex = 0;
        label1.Text = "Owner:";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        label2.Location = new System.Drawing.Point(12, 316);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(105, 39);
        label2.TabIndex = 1;
        label2.Text = "Amount:";
        // 
        // OwnerTxt
        // 
        OwnerTxt.Location = new System.Drawing.Point(123, 29);
        OwnerTxt.Name = "OwnerTxt";
        OwnerTxt.Size = new System.Drawing.Size(224, 23);
        OwnerTxt.TabIndex = 2;
        // 
        // AmountNum
        // 
        AmountNum.Location = new System.Drawing.Point(123, 326);
        AmountNum.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
        AmountNum.Minimum = new decimal(new int[] { 999999999, 0, 0, -2147483648 });
        AmountNum.Name = "AmountNum";
        AmountNum.Size = new System.Drawing.Size(224, 23);
        AmountNum.TabIndex = 3;
        // 
        // BankAccountsGrid
        // 
        BankAccountsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        BankAccountsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        BankAccountsGrid.Location = new System.Drawing.Point(385, 29);
        BankAccountsGrid.Name = "BankAccountsGrid";
        BankAccountsGrid.Size = new System.Drawing.Size(387, 320);
        BankAccountsGrid.TabIndex = 4;
        BankAccountsGrid.Text = "dataGridView1";
        // 
        // CreateAccountBtn
        // 
        CreateAccountBtn.Location = new System.Drawing.Point(152, 126);
        CreateAccountBtn.Name = "CreateAccountBtn";
        CreateAccountBtn.Size = new System.Drawing.Size(195, 48);
        CreateAccountBtn.TabIndex = 5;
        CreateAccountBtn.Text = "Create Account\r\n";
        CreateAccountBtn.UseVisualStyleBackColor = true;
        CreateAccountBtn.Click += CreateAccountBtn_Click;
        // 
        // DepositBtn
        // 
        DepositBtn.Location = new System.Drawing.Point(385, 355);
        DepositBtn.Name = "DepositBtn";
        DepositBtn.Size = new System.Drawing.Size(195, 48);
        DepositBtn.TabIndex = 6;
        DepositBtn.Text = "Deposit";
        DepositBtn.UseVisualStyleBackColor = true;
        DepositBtn.Click += DepositBtn_Click;
        // 
        // WithdrawBtn
        // 
        WithdrawBtn.Location = new System.Drawing.Point(586, 355);
        WithdrawBtn.Name = "WithdrawBtn";
        WithdrawBtn.Size = new System.Drawing.Size(186, 48);
        WithdrawBtn.TabIndex = 7;
        WithdrawBtn.Text = "Withdraw";
        WithdrawBtn.UseVisualStyleBackColor = true;
        WithdrawBtn.MouseClick += WithdrawBtn_MouseClick;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        label3.Location = new System.Drawing.Point(26, 70);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(139, 53);
        label3.TabIndex = 8;
        label3.Text = "Interest Rate:";
        // 
        // InterestsNum
        // 
        InterestsNum.Location = new System.Drawing.Point(188, 80);
        InterestsNum.Name = "InterestsNum";
        InterestsNum.Size = new System.Drawing.Size(145, 23);
        InterestsNum.TabIndex = 9;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(InterestsNum);
        Controls.Add(label3);
        Controls.Add(WithdrawBtn);
        Controls.Add(DepositBtn);
        Controls.Add(CreateAccountBtn);
        Controls.Add(BankAccountsGrid);
        Controls.Add(AmountNum);
        Controls.Add(OwnerTxt);
        Controls.Add(label2);
        Controls.Add(label1);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)AmountNum).EndInit();
        ((System.ComponentModel.ISupportInitialize)BankAccountsGrid).EndInit();
        ((System.ComponentModel.ISupportInitialize)InterestsNum).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.NumericUpDown InterestsNum;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Button CreateAccountBtn;
    private System.Windows.Forms.Button DepositBtn;
    private System.Windows.Forms.Button WithdrawBtn;

    private System.Windows.Forms.TextBox OwnerTxt;
    private System.Windows.Forms.NumericUpDown AmountNum;
    private System.Windows.Forms.DataGridView BankAccountsGrid;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    #endregion
}