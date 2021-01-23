namespace OOP1.Abstract
{
    public enum Jobs
    {
        Student,
        Officer,
        Farmer,
        Trader
    }

    public interface ICustomer
    {
        public int Id { get; set; }

        public string CustomerNumber { get; set; }

        public Jobs Job { get; set; }

        public void Add();
    }
}
