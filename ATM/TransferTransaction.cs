namespace ATM;

public class TransferTransaction : Transaction
{
    private int _amount;
    private int _fromAccountNumber;
    private int _toAccountNumber;

    public TransferTransaction(string type, DateTime dateTime, int amount, int id, int fromAccountNumber, int toAccountNumber) 
        : base(type, dateTime, id)
    {
        _amount = amount;
        _fromAccountNumber = fromAccountNumber;
        _toAccountNumber = toAccountNumber;
    }
    public override string ToString()
    {
        return $"{base.ToString()}, Amount: {_amount}, From: {_fromAccountNumber}, To: {_toAccountNumber} " ;
    }
}