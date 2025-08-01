namespace ATM;

public class GenerateAccount
{
    public static void Generate()
    {
        Console.WriteLine("How much accounts do you want to generate ?");
        int count = int.Parse(Console.ReadLine());
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            if (random.Next(1, 3) == 1)
            {
                var account = new CreditAccount(random.Next(10000, 99999), random.Next(1000, 5000),
                    Math.Round(-random.Next(1000, 5000) / 5.0) * 5 );
                string Acc = $"{account.AccountNumber},{account.Balance},{account.CreditLimit}\n";
                
                File.AppendAllText(@"/Users/wlad/Accounts/accounts.csv", Acc);
            }
            else
            {
                var account = new DebitAccount(random.Next(10000, 99999), random.Next(1000, 5000));

                string Acc = $"{account.AccountNumber},{account.Balance},\n";
                
                File.AppendAllText(@"/Users/wlad/Accounts/accounts.csv", Acc);
            }
                
        }
    }
}