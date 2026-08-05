namespace BankingAppWinForms;

public partial class Form1 : Form
{
    List<BankAccount> Accounts = new List<BankAccount>();

    public Form1()
    {
        InitializeComponent();
        
    }


    private void CreateAccountBtn_Click(object sender, EventArgs e)
    {
        
        if (string.IsNullOrEmpty(OwnerTxt.Text))
        {
            MessageBox.Show("You need to type your name");
            return;
        }
        
        if(InterestsNum.Value != 0)
            Accounts.Add(new InterestBankAccount(OwnerTxt.Text, InterestsNum.Value));
        else
            Accounts.Add(new BankAccount(OwnerTxt.Text));
        
        
        RefreshGrid();
        OwnerTxt.Text = string.Empty;
        InterestsNum.Value = 0;

    }

    private void RefreshGrid()
    {
        BankAccountsGrid.DataSource = null;
        BankAccountsGrid.DataSource = Accounts;
    }


    private void DepositBtn_Click(object sender, EventArgs e)
    {
        
     if (BankAccountsGrid.SelectedRows.Count != 1 )
     {
         MessageBox.Show("You need to select one account");
         return;
     }
     
     BankAccount seleceted_account = BankAccountsGrid.SelectedRows[0].DataBoundItem as BankAccount;

     if (seleceted_account == null)
     {
         MessageBox.Show("Reading Failed");
         return;
     }
     
    
     try
     {
         seleceted_account.Deposit(AmountNum.Value);
         RefreshGrid();
         AmountNum.Value = 0;
         MessageBox.Show("Deposited Successfully");


     }
     catch (Exception exception)
     {
         MessageBox.Show(exception.Message,"Deposit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
     }
     
     }
    
    private void WithdrawBtn_MouseClick(object sender, MouseEventArgs e)
    {
        if (BankAccountsGrid.SelectedRows.Count != 1)
        {
            
            MessageBox.Show("You need to select one account");
            return;
            
        }
        
        BankAccount selected_account = BankAccountsGrid.SelectedRows[0].DataBoundItem as BankAccount;

        if (selected_account == null)
        {
            
            MessageBox.Show("Reading Failed");
            return;
        }
        
        try
        {
            selected_account.Withdraw(AmountNum.Value);
        
            RefreshGrid();
            AmountNum.Value = 0;
            MessageBox.Show("Withdrawn Successfully");
        }
    
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message,"Withdraw Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
        
    }
}




