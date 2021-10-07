using UnityEngine;

public class ClientCode : MonoBehaviour
{
    void Start()
    {
       ClientCode_method(new Creator1()); 
       ClientCode_method(new Creator2()); 
    }

    public void ClientCode_method(AbstractCreator creator)
    {
       Debug.LogError(creator.SomeOperation()); 
    }
}
