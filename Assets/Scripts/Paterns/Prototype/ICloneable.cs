using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICloneable<T>
{
    public T ShallowCopy();
    public T DeepCopy();
}
