namespace FurnitureFactory
{
    internal class VictorianChair : AbstractChair
    {
    }

    internal class VictorianSofa : AbstractSofa
    {
    }

    internal class VictorianCoffeeTable : AbstractCoffeeTable
    {
    }

    internal class VictorianFactory : AbstractFactory
    {
        public override VictorianChair CreateCheair()
        {
            return new VictorianChair();
        }

        public override VictorianCoffeeTable CreateCoffeeTable()
        {
            return new VictorianCoffeeTable();
        }

        public override VictorianSofa CreateSofa()
        {
            return new VictorianSofa();
        }

    }
}
