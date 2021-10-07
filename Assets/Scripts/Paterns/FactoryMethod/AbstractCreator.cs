using UnityEngine;

public abstract class AbstractCreator 
{
    public abstract IProduct FactoryMethod();

    public string SomeOperation()
    {
        var product = FactoryMethod();

        var result = product.Operation();

        return result;
    }
}
