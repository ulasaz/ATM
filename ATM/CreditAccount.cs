namespace ATM;

public class CreditAccount: Account
{
    public double CreditLimit { get; }
    public CreditAccount(int accountNumber, double amountOfMoney, double creditLimit) : base(accountNumber, amountOfMoney)
    {
        CreditLimit = creditLimit;
    }
    public override double Balance
    {
        set
        {
            if (balance >= CreditLimit)
                balance = value;
        }
    }
}