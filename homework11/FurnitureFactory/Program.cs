namespace FurnitureFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var modernFactory = new ModernnFactory();
            var victorianFactory = new VictorianFactory();
            var decoFactory = new DecoFactory();

            var client = new Client(decoFactory);
            client.Order();
        }
    }
}
