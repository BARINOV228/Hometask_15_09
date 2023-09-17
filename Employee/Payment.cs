public class Payment
{
    public string id;
    private decimal amount;
    public string date;

    public Payment(decimal amount)
    {
        this.amount = amount;
        id = GenerateId();
        date = DateTime.Now.ToString();
    }

    public decimal Amount
    {
        get { return amount; }
    }

    private string GenerateId()
    {
        Guid guid = Guid.NewGuid();
        return guid.ToString().ToUpper();
    }
}