using System;

public class Person : ICloneable<Person>
{
    public int Age;
    public int Id;
    public string Name;
    public DateTime DateTime;

    public Person ShallowCopy()
    {
        return (Person) this.MemberwiseClone();
    }

    public Person DeepCopy()
    {
        var clone =(Person)this.MemberwiseClone();
        clone.Id = Id;
        clone.Age = Age;
        clone.Name = Name;
        clone.DateTime = DateTime;
        return clone;
    }
}
