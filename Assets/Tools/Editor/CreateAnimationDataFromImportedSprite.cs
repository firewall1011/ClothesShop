using System.IO;
using System.Linq;
using ClothesShop.Animation;
using UnityEditor;
using UnityEngine;

namespace ClothesShop.Tools
{
    public static class CreateAnimationDataFromImportedSprite
    {
        private static readonly string FolderPath = Path.Combine("Assets", "Data", "Animations");

        [MenuItem("ClothesShop/Create Animation Data From Selected Texture")]
        private static void CreateAnimationData(MenuCommand command)
        {
            var textures = Selection.GetFiltered<Texture2D>(SelectionMode.Assets);

            foreach (var texture in textures)
            {
                CreateAnimationDataFromTexture(texture);
            }
        }

        [MenuItem("ClothesShop/Create Animation Data From Selected Texture", true)]
        private static bool ValidateCreateAnimationData(MenuCommand command)
        {
            var textures = Selection.GetFiltered<Texture2D>(SelectionMode.Assets);
            return textures.Any();
        }

        private static void CreateAnimationDataFromTexture(Texture2D texture)
        {
            var texturePath = AssetDatabase.GetAssetPath(texture);
            var sprites = AssetDatabase.LoadAllAssetsAtPath(texturePath).OfType<Sprite>().ToArray();
            
            if (sprites.Length < 12)
                return;
            
            var splitName = texture.name.Split('-');
            var name = GetAssetName(splitName);
            var path = GetAssetPath(name);

            var asset = AssetDatabase.LoadAssetAtPath(path, typeof(SpriteAnimationData)) as SpriteAnimationData;
            if (asset == null)
            {
                asset = ScriptableObject.CreateInstance<SpriteAnimationData>();
                asset.name = name;
                
                AssetDatabase.CreateAsset(asset, path);
            }

            asset.SetSouthSprites(sprites[..3]);
            asset.SetWestSprites(sprites[3..6]);
            asset.SetEastSprites(sprites[6..9]);
            asset.SetNorthSprites(sprites[9..12]);
            
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssetIfDirty(asset);
        }

        private static string GetAssetName(string[] splitName)
        {
            return $"{splitName[0]}AnimationData_{splitName[1]}";
        }

        private static string GetAssetPath(string name)
        {
            return Path.Combine(FolderPath, $"{name}.asset");
        }
    }
}
