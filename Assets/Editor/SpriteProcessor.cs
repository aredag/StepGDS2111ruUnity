using System;
using UnityEditor;
using UnityEngine;

public class SpriteProcessor : AssetPostprocessor 
{
    void OnPostprocessTexture(Texture2D texture)
    {
        var lowerCaseAssetPath = assetPath.ToLower(); 
        
        var isInSpriteDirectory = lowerCaseAssetPath.IndexOf("/sprites/") != -1;

        if (isInSpriteDirectory)
        {
            var textureImporter = (TextureImporter) assetImporter;

            textureImporter.textureType = TextureImporterType.Sprite;
        }
        
    }
}
