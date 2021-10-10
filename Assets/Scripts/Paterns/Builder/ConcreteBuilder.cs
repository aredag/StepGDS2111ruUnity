
public class ConcreteBuilder : IBuilder
{
    private Product _product = new Product();
        
    public void BuildPartA()
    {
        _product.Add("Some Part A");
    }

    public void BuildPartB()
    {
        _product.Add("Some Part B");
    }

    public void BuildPartC()
    {
        _product.Add("Some Part C");
    }

    public void Reset()
    {
        _product = new Product();
    }

    public Product GetProduct()
    {
        Product result = _product;
        
        Reset();

        return result;
    }
}