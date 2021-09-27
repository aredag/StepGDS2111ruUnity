using UnityEngine;

public class Generator 
{
    public static void GenerateTextures(int x = 1024, int y = 1024, int amountToGenerate = 100)
    {
        for (var i = 0; i < amountToGenerate; i++)
        {
           var t =  new Texture2D(x, y)
           {
               name = $"ScriptCreatedTexture-{i}"
           };
        }
    }
}
