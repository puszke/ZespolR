using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnMousesNpc : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector2Int mapSize = new Vector2Int(200, 200); // Zakres od (0,0) do (10,10)

    public GameObject mouse;

    void Start()
    {
        //CheckRandomTile();
        for(int i = 0; i<10*PlayerPrefs.GetInt("Obs"); i++)
        {
            CheckRandomTile();
        }
    }

    bool CheckRandomTile()
    {
        Vector3Int randomPos = new Vector3Int(
            Random.Range(0, mapSize.x),
            Random.Range(0, mapSize.y),
            0
        );

        TileBase tile = tilemap.GetTile(randomPos);

        if (tile == null)
        {
            Debug.Log($"Znalaz³em pusty tile na pozycji {randomPos}");
            GameObject newMouse = Instantiate(mouse);
            newMouse.transform.position = tilemap.CellToWorld(randomPos);
            return true;
        }
        else
        {
            Debug.Log($"Tile na pozycji {randomPos} NIE jest pusty");
            return false;
        }
    }


}
