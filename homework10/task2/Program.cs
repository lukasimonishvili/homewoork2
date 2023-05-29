namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            var microFinance = new MicroFinance();

            bank.requestLoad(5, 1500);
            microFinance.requestLoad(3, 1200);
        }
    }
}
