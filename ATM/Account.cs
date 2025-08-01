namespace ATM;

public abstract class Account
{
    public int AccountNumber { get; }
    protected double balance;
    public Account(int accountNumber, double amountOfMoney)
    {
        AccountNumber = accountNumber;
        balance = amountOfMoney;
    }
    public virtual double Balance
    {
        get { return balance;}
        set { balance = value;  }
    }

}