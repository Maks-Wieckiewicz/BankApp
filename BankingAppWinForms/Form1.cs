using System.Data.SqlTypes;
using Shared.Enums;
using System.Net.Http.Json;
using Shared.DTOs;

namespace BankingAppWinForms;


public partial class Form1 : Form
{
    private static readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5158/")
    };
    
   

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

        if (BankAccountTypeCB.SelectedItem == null)
        {
            MessageBox.Show("You need to pick a type of your bank account");
            return;
        }
        CreateBankAccountRequest newUser = new CreateBankAccountRequest();
        
        // adding name to DTO
        newUser.Name = OwnerTxt.Text;
        newUser.InitialDeposit = 0;
        
        if((string)BankAccountTypeCB.SelectedItem == "Savings Account")
            newUser.Type = AccountType.Saving;
        
        else
            newUser.Type = AccountType.Standard;
        
        
        RefreshGrid();
        OwnerTxt.Text = string.Empty;
        BankAccountTypeCB.SelectedItem = null;
        

    }

    private async void RefreshGrid()
    {
        BankAccountsGrid.DataSource = null;
        
        // Need connection with data base
        var Accounts = await _httpClient.GetFromJsonAsync<List<BankAccountResponse> >("api/BankAccounts");
        BankAccountsGrid.DataSource = Accounts;
    }


    private void DepositBtn_Click(object sender, EventArgs e)
    {
        
     if (BankAccountsGrid.SelectedRows.Count != 1 )
     {
         MessageBox.Show("You need to select one account");
         return;
     }

     if (BankAccountsGrid.CurrentRow != null)
     {
         var selectedAccount = (BankAccountResponse)BankAccountsGrid.CurrentRow.DataBoundItem;
         
         Guid accountId = selectedAccount.AccountId;
         //decimal currentBalance = selectedAccount.Balance;

         var inputValue = AmountNum.Value;
         
        CreateMoneyRequest newDeposit = new CreateMoneyRequest();

        newDeposit.BankAccountNumber = accountId;
        newDeposit.Amount = (int)inputValue;



     }
     
     
     
    
     
     
     }
    
    private void WithdrawBtn_MouseClick(object sender, MouseEventArgs e)
    {
        /*if (BankAccountsGrid.SelectedRows.Count != 1)
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
            
        }*/
        
    }

    

    private void SkipTimebtn_Click(object sender, EventArgs e)
    {
        //throw new System.NotImplementedException();
        /*if (Accounts.Count > 0)
        {
            
            foreach (var account in Accounts)
            {
                if (account is InterestBankAccount savings_account)
                    savings_account.CountInterests();
                
            }
            
            
        }
        RefreshGrid();*/
        
        
    }
    
}