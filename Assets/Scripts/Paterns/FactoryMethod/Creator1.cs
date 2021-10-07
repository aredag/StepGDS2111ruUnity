public class Creator1 : AbstractCreator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct1();
    }
}