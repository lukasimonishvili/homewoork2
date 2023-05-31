namespace FurnitureFactory
{
    internal class DecoChair : AbstractChair
    {
    }

    internal class DecoSofa : AbstractSofa
    {
    }

    internal class DecoCoffeeTable : AbstractCoffeeTable
    {
    }

    internal class DecoFactory : AbstractFactory
    {
        public override DecoChair CreateCheair()
        {
            return new DecoChair();
        }

        public override DecoCoffeeTable CreateCoffeeTable()
        {
            return new DecoCoffeeTable();
        }

        public override DecoSofa CreateSofa()
        {
            return new DecoSofa();
        }

    }
}
