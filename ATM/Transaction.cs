namespace ATM;

public abstract class Transaction
{
    private string _type;
    private DateTime _dateTime;
    private int _id;

    public Transaction(string type, DateTime dateTime, int id)
    {
        _type = type;
        _dateTime = dateTime;
        _id = id;
    }
    public override string ToString()
    {
        return $"{_type}, Transaction time: {_dateTime}, ATM: {_id}";
    }
}
