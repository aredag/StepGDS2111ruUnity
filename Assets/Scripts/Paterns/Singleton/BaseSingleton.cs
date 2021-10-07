using UnityEngine;

public class BaseSingleton : MonoBehaviour
{
    public static BaseSingleton Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            Debug.LogError("Created");
        }
        else
        {
            Destroy(this);
        }
    }
}




