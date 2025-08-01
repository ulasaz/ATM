namespace ATM;

public static class TransactionHistory
{
    private static Dictionary<int, List<Transaction>> _transactionHistory = new();
    
    public static void AddTransactionToHistory(Transaction transaction, int accountNumber)
    {
        if (!_transactionHistory.ContainsKey(accountNumber))
        {
            _transactionHistory[accountNumber] = new List<Transaction>();
        }
        _transactionHistory[accountNumber].Add(transaction);
    }
    public static List<Transaction> GetTransactionHistory(int accountNumber)
    {
        return _transactionHistory[accountNumber];
    }
}