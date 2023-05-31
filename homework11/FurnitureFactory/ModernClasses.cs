namespace FurnitureFactory
{

    internal class ModernnChair : AbstractChair
    {
    }

    internal class ModernnSofa : AbstractSofa
    {
    }

    internal class ModernnCoffeeTable : AbstractCoffeeTable
    {
    }

    internal class ModernnFactory : AbstractFactory
    {
        public override ModernnChair CreateCheair()
        {
            return new ModernnChair();
        }

        public override ModernnCoffeeTable CreateCoffeeTable()
        {
            return new ModernnCoffeeTable();
        }

        public override ModernnSofa CreateSofa()
        {
            return new ModernnSofa();
        }

    }

}
