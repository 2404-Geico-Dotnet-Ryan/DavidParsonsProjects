class Accounts
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Type { get; set; }


    public Accounts()
    {
        Name = "";
        Type = "";
    }

    public Accounts(int id, string name, double balance, string type)
    {
        Id = id;
        Name = name;
        Balance = balance;
        Type = type;
    }



    public override string ToString()
    {
        return $"id: {Id}; name: {Name}; balance: {Balance}; type: {Type}";
    }

}