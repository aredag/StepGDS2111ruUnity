public class Creator2 : AbstractCreator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct2();
    }
}
