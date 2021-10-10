public class Director
{
    public IBuilder Builder { get; set; }
    

    public void BuildMinimumProduct()
    {
        Builder.BuildPartA();
    }
    
    public void BuildMaximumProduct()
    {
        Builder.BuildPartA();
        Builder.BuildPartB();
        Builder.BuildPartC();
    }
    
}