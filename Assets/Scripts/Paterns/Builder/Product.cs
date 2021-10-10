using System.Collections.Generic;

public class Product
{
   List<object> _parts = new List<object>();

   public void Add(string part)
   {
      _parts.Add(part);
   }

   public string ListParts()
   {
      string str = string.Empty;

      for (int i = 0; i < _parts.Count; i++)
      {
         str += _parts[i] + ", ";
      }

      return $"Product parts: {str}";
   }
}