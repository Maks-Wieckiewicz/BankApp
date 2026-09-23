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
         var selectedAccount = (CreateMoneyRequest)BankAccountsGrid.CurrentRow.DataBoundItem;
         
         Guid accountId = selectedAccount.BankAccountNumber;
         //decimal currentBalance = selectedAccount.Balance;

         var inputValue = AmountNum.Value;
         
        CreateMoneyRequest newDeposit = new CreateMoneyRequest();

        newDeposit.BankAccountNumber = accountId;
        newDeposit.Amount = inputValue;


        RefreshGrid();
     }
     
     
     
    
     
     
     }
    
    private void WithdrawBtn_MouseClick(object sender, MouseEventArgs e)
    {
        if (BankAccountsGrid.SelectedRows.Count != 1)
        {
            
            MessageBox.Show("You need to select one account");
            return;
            
        }
        
        if (BankAccountsGrid.CurrentRow != null)
        {
            var selectedAccount = (CreateMoneyRequest)BankAccountsGrid.CurrentRow.DataBoundItem;
         
            Guid accountId = selectedAccount.BankAccountNumber;
            

            var inputValue = AmountNum.Value;
         
            CreateMoneyRequest newDeposit = new CreateMoneyRequest();

            newDeposit.BankAccountNumber = accountId;
            newDeposit.Amount = inputValue;



        }
        
        RefreshGrid();
        
    }

    

    private void SkipTimebtn_Click(object sender, EventArgs e)
    {
        
        // Nothing to send 
        // Just relode the grid
        
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
        
        RefreshGrid();
    }
    private Guid? _sourceAccountId = null;
    private Guid? _targetAccountId = null;

    private void SenderBtn_Click(object sender, EventArgs e)
    {
        if (BankAccountsGrid.SelectedRows.Count != 1 )
        {
            MessageBox.Show("You need to select one account");
            return;
        }
        
        if (BankAccountsGrid.CurrentRow != null)
        {
            var selectedAccount = (BankAccountResponse)BankAccountsGrid.CurrentRow.DataBoundItem;
         
            _sourceAccountId = selectedAccount.AccountId;
            

            MessageBox.Show($"Sender: {selectedAccount.Name} ({selectedAccount.AccountId})");

        }
        
    }
    
    private void ReciverBtn_Click(object sender, EventArgs e)
    {
        if (BankAccountsGrid.SelectedRows.Count != 1 )
        {
            MessageBox.Show("You need to select one account");
            return;
        }
        
        if (BankAccountsGrid.CurrentRow != null)
        {
            var selectedAccount = (BankAccountResponse)BankAccountsGrid.CurrentRow.DataBoundItem;
         
            _targetAccountId = selectedAccount.AccountId;
            

            MessageBox.Show($"Receiver: {selectedAccount.Name} ({selectedAccount.AccountId})");

        }
    }
    
    
    
    private void TransferBtn_Click(object sender, EventArgs e)
    {
        if (_sourceAccountId != null && _targetAccountId != null)
        {
            CreateTransferRequest newTransfer = new CreateTransferRequest();
            var Amount = AmountNum.Value;
            
            newTransfer.TransferFrom = _sourceAccountId;
            newTransfer.TransferTo = _targetAccountId;
            newTransfer.Amount = Amount;
            
        }
        
    }



}