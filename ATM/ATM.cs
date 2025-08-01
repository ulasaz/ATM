namespace ATM;

public class ATM
{
    private static Dictionary<int, Account> _accounts = new();
    private int _totalBalance;
    private int _id;
    
    public ATM(int id, int totalBalance)
    {
        _id = id;
        _totalBalance = totalBalance;
    }
    public static void AddAccounts( List<Account> Accounts)
    {
        foreach (var account in Accounts)
        {
            _accounts.Add(account.AccountNumber, account);
        }
    }
    static ATM()
    {
        GenerateAccount.Generate();
        List<Account> Accounts = CSVReader.ReadCSV();
        
        AddAccounts(Accounts);
    }
    public int Id
    {
        get { return _id; }
    }
    public int TotalBalance
    {
        get { return _totalBalance; }
    }
    public double GetBalance(int accountNumber, int id)
    {
        Account account = _accounts[accountNumber];
        var getBalanceTransaction = new GetBalanceTransaction("Get Balance", DateTime.Now, id);
        TransactionHistory.AddTransactionToHistory(getBalanceTransaction, accountNumber);
        
        return account.Balance;
    }
    public double TopUp(int accountNumber, int amount, int id)
    {
        Account account = _accounts[accountNumber];
        var topUpMoneyTransactionTransaction = new MoneyTransaction("Top Up", DateTime.Now, amount, id);
        TransactionHistory.AddTransactionToHistory(topUpMoneyTransactionTransaction, accountNumber);
        
        return account.Balance += amount;
    }
    public double Withdraw(int accountNumber, int amount, int id)
    {
        Account account = _accounts[accountNumber];
        
        if (amount > TotalBalance)
            return -2;
        
        double balance = account.Balance -= amount;
        if (account.Balance == balance)
            return -1;
        else
        {
            var WitdrawTransaction = new MoneyTransaction("Withdraw from Credit Account", DateTime.Now, amount, id);
            TransactionHistory.AddTransactionToHistory(WitdrawTransaction, accountNumber);
        }
        return balance;
    }
    public double Transfer(int fromAccountNumber, int amount, int toAccountNumber, int id)
    {
        Account account = _accounts[fromAccountNumber];
        double balance = 0;
        
        if (account is CreditAccount creditAccount && creditAccount.Balance - amount >= -creditAccount.CreditLimit)
        {
            balance = Withdraw(fromAccountNumber, amount, id);
        }
        else
        {
            balance = Withdraw(fromAccountNumber, amount, id);
        }
        if (balance == -1)
            return -1;
        else
        {
            TopUp(toAccountNumber, amount, id);
            var transferTransaction = new TransferTransaction("Transfer", DateTime.Now, amount, id, fromAccountNumber, toAccountNumber);
            TransactionHistory.AddTransactionToHistory(transferTransaction, fromAccountNumber);
        }
        return balance;
    }
    
}

