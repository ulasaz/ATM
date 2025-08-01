namespace ATM;

public class GetBalanceTransaction : Transaction
{
    public GetBalanceTransaction(string type, DateTime dateTime, int id):base(type, dateTime, id)
    {
    }
}