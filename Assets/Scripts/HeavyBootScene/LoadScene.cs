using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static void LoadSceneAsyncWithIndex(int sceneIndex)
    {
       if(sceneIndex < 0) return;

       SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    }
    
    public static void UnloadSceneAsyncWithIndex(int sceneIndex)
    {
       if(sceneIndex < 0) return;

       SceneManager.UnloadSceneAsync(sceneIndex);
    }
}
