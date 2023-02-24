using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace SecondTask.Tileset
{
    public class SurfaceTile: Tile
    {
        private static readonly int[,] Delta = new int[,]
        {
            {1, 1},
            {1, 0},
            {1, -1},
            {0, -1},
            {-1, -1},
            {-1, 0},
            {-1, 1}
        };

        public Sprite[] sprites;
        public Sprite preview;

        public override void RefreshTile(Vector3Int position, ITilemap tilemap)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    Vector3Int neighbour = new Vector3Int(position.x + dx, position.y + dy, position.z);
                    if (HasSurfaceTile(tilemap, neighbour))
                    {
                        tilemap.RefreshTile(neighbour);
                    }
                }
            }
        }

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            int mask = 0;
            for (int i = 0; i < Delta.Length; i++)
            {
                mask += HasSurfaceTile(tilemap,
                    new Vector3Int(
                        position.x + Delta[i, 0],
                        position.y + Delta[i, 1],
                        position.z))
                    ? (1 << i)
                    : 0;
            }

            int index = GetSpriteIndex((byte)mask);
            // Тут должно быть установление нового значения к тайлу
        }

        private bool HasSurfaceTile(ITilemap tilemap, Vector3Int position) => tilemap.GetTile(position) == this;

        private int GetSpriteIndex(byte mask)
        {
            // It's hard to think...
            // So do this now on my own
            // Для хорошей тайловой сетки потребуется что-то порядка 256 разных спрайтов,
            // Но вообще, если ограничится только 4-я соседями, то нужно будет всего 16 спрайтов, вот
            // Думать не хочется, поэтому я не стал дореализовывать этот класс
            return 0;
        }
        
#if UNITY_EDITOR
        [MenuItem("Assets/Create/SurfaceTile")]
        public static void CreateSurfaceTile()
        {
            var path = EditorUtility.SaveFilePanelInProject("Save Surface Tile",
                "New Surface Tile",
                "Asset",
                "Save Surface Tile",
                "Assets");
            if (path == "")
            {
                return;
            }
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SurfaceTile>(), path);
        }
        #endif
    }
}