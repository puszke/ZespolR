using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class BlockGenerator : MonoBehaviour
{
    [Header("Generator settings")]
    [SerializeField] private int width = 200;
    [SerializeField] private int height = 200;
    [SerializeField] [Range(0f, 1f)] private float fillProb = 0.45f;
    [SerializeField] private int iterations = 5, birthLimit = 4, deathLimit = 4;

    [Header("Tile i tilemapa")]
    [SerializeField] Tilemap tilemap;
    [SerializeField] RuleTile tile;

    private int[,] map;

    private void Start()
    {
        Generate();
        DrawMap();
    }
    public void Generate()
    {
        InitMap();
        for (int i = 0; i < iterations; i++)
        {
            map = DoSimulationStep(map);
        }
    }

    private void InitMap()
    {
        map = new int [width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = (Random.value < fillProb) ? 1 : 0;
            }
        }
    }

    int[,] DoSimulationStep(int[,] oldMap)
    {
        int[,] newMap = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for(int y = 0;y < height; y++)
            {
                int neighbours = CountWallNeighbours(oldMap, x, y);

                if (oldMap[x, y] == 1)
                {
                    newMap[x, y] = (neighbours < deathLimit) ? 0 : 1;

                }
                else
                {
                    newMap[x, y] = (neighbours > birthLimit) ? 1 : 0;
                }
            }
        }
        return newMap;
    }

    private int CountWallNeighbours(int[,] map, int x, int y)
    {
        int count = 0;
        for (int xc = x-1; xc <= x + 1; xc++)
        {
            for (int yc = y-1; yc <= y + 1; yc++)
            {
                if (x == xc && y == yc) continue;
                if (xc < 0 ||  yc < 0 || xc >= width || yc >= height) count++;
                else if (map[xc, yc] == 1) count++;
            }
        }
        return count;
    }
    void DrawMap()
    {
        tilemap.ClearAllTiles();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (map[x, y] == 1) tilemap.SetTile(pos, tile);
            }
        }
    }
}
