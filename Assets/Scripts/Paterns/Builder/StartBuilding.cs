using System;
using UnityEngine;

public class StartBuilding : MonoBehaviour
{
    Director _director = new Director();
    ConcreteBuilder _concreteBuilder = new ConcreteBuilder(); 
    private void Start()
    {
        _director.Builder = _concreteBuilder;
        
        _director.BuildMinimumProduct();
        
        Debug.LogError(_concreteBuilder.GetProduct().ListParts());
        
        _director.BuildMaximumProduct();
        
        Debug.LogError(_concreteBuilder.GetProduct().ListParts());
        
        
        _concreteBuilder.BuildPartA();
        _concreteBuilder.BuildPartC();
        
        Debug.LogError(_concreteBuilder.GetProduct().ListParts());
    }
}