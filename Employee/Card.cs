public class Card
{
    public string id;
    private string userName;
    public string name;
    private string expDate;
    public decimal balance;

    public Card(string name)
    {
        id = GenerateId();
        this.name = name;
        expDate = DateTime.Now.ToString();
        balance = 0;
    }

    public string Id
    {
        get { return id; }
    }

    public decimal Balance
    {
        get { return balance; }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > balance)
        {
            throw new Exception("Insufficient funds");
        }

        balance -= amount;
    }

    private string GenerateId()
    {
        Guid guid = Guid.NewGuid();
        return guid.ToString().ToUpper();
    }
}