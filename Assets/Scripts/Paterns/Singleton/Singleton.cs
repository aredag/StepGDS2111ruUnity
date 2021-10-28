using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T: Component
{
   static T instance;

   static bool _applicationIsQuiting = false;

   public static T GetInstance()
   {
      if (_applicationIsQuiting)
      {
         return null;
      }

      if (instance == null)
      {
         instance = FindObjectOfType<T>();

         if (instance == null)
         {
            GameObject obj = new GameObject();
            obj.name = typeof(T).Name;
            instance = obj.AddComponent<T>();
         }
      }

      return instance;
   }


   protected virtual void Awake()
   {
      if (instance == null)
      {
         instance = this as T;
         DontDestroyOnLoad(gameObject);
      }
      else if (instance != this as T)
      {
         Destroy(gameObject);    
      }
   }

   void OnApplicationQuit()
   {
      _applicationIsQuiting = true;
   }
}
