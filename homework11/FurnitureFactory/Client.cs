namespace FurnitureFactory
{
    internal class Client
    {
        private AbstractChair chair { get; set; }
        private AbstractCoffeeTable coffeeTable { get; set; }
        private AbstractSofa sofa { get; set; }

        public Client(AbstractFactory factory)
        {
            chair = factory.CreateCheair();
            coffeeTable = factory.CreateCoffeeTable();
            sofa = factory.CreateSofa();
        }

        public AbstractFurniture[] Order()
        {
            AbstractFurniture[] furnitures = { chair, sofa, coffeeTable };
            return furnitures;
        }
    }
}
