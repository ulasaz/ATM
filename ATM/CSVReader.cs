using Microsoft.VisualBasic.FileIO;
namespace ATM;

public class CSVReader
{
    private static List<Account> Accounts = new();
    private static StreamReader parser = new StreamReader(@"/Users/wlad/Accounts/accounts.csv");
    public static List<Account> ReadCSV()
    {
        List<string> lines = new List<string>();
        while (!parser.EndOfStream)
        {
            var line = parser.ReadLine();
            lines.Add(line);
            
            var value = line.Split(',');
            int creditLimit = 0;
            
            int accountNumber = int.Parse(value[0]);
            int amountOfMoney = int.Parse(value[1]);
            
            if (!int.TryParse(value[2], out creditLimit))
                creditLimit = 0;
            
            if (creditLimit == 0)
            {
                Account account = new DebitAccount(accountNumber, amountOfMoney);
                Accounts.Add(account);
            }
            else
            {
                Account account = new CreditAccount(accountNumber, amountOfMoney, creditLimit);
                Accounts.Add(account);
            }
        }
        return Accounts;
    }

    public List<Account> GetAccounts
    {
        get { return Accounts; }
    }
}
    