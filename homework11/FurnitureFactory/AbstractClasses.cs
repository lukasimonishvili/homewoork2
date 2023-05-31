namespace FurnitureFactory
{
    internal abstract class AbstractFurniture { }
    internal abstract class AbstractSofa : AbstractFurniture
    {
    }

    internal abstract class AbstractChair : AbstractFurniture
    {
    }

    internal abstract class AbstractCoffeeTable : AbstractFurniture
    {
    }

    internal abstract class AbstractFactory
    {
        public abstract AbstractChair CreateCheair();
        public abstract AbstractCoffeeTable CreateCoffeeTable();
        public abstract AbstractSofa CreateSofa();
    }
}