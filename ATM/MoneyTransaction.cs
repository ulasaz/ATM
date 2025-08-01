namespace ATM;

public class MoneyTransaction : Transaction
{
    private int _amount;

    public MoneyTransaction(string type, DateTime dateTime, int amount, int id) : base(type, dateTime, id)
    {
        _amount = amount;
    }
    public override string ToString()
    {
        return $"{base.ToString()}, Amount: {_amount} " ;
    }
}