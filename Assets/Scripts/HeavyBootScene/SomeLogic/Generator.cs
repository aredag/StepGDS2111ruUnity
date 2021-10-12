using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private Texture2D[] textures;

    private void Start()
    {
        StartCoroutine(GenerateTextures());
    }

    public void OnDestroy()
    {
        StopAllCoroutines();
        for (int i = 0; i < textures.Length; i++)
            DestroyImmediate(textures[i]);
        textures = System.Array.Empty<Texture2D>();
    }

    private System.Collections.IEnumerator GenerateTextures(int x = 1024, int y = 1024, int amountToGenerate = 100)
    {
        textures = new Texture2D[amountToGenerate];
        for (var i = 0; i < amountToGenerate; i++)
        {
            textures[i] = new Texture2D(x, y, TextureFormat.RGBA4444, false)
            {
                name = $"ScriptCreatedTexture-{i}"
            };
            yield return null;
        }
    }
}