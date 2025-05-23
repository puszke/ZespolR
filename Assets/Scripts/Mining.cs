using UnityEngine;
using UnityEngine.Tilemaps;

public class Mining : MonoBehaviour
{
    public Tilemap tilemap;
    public float radius = 1.5f;

    float miningProgress = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Przyk³ad: usuwanie kafelka pod kursorem myszy
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int center = tilemap.WorldToCell(worldPos);

            int rCeil = Mathf.CeilToInt(radius);

            for (int x = -rCeil; x <= rCeil; x++)
            {
                for (int y = -rCeil; y <= rCeil; y++)
                {
                    Vector3Int pos = new Vector3Int(center.x + x, center.y + y, center.z);

                    // Liczymy dystans od œrodka do tego pola
                    float dist = Vector2.Distance(new Vector2(center.x, center.y), new Vector2(pos.x, pos.y));

                    if (dist <= radius)
                    {
                        TileBase tile = tilemap.GetTile(pos);
                        if (tile != null)
                        {
                            miningProgress += Time.deltaTime;
                            if (miningProgress > 2)
                            {
                                Debug.Log("Wykopano " + tile.name + " na pozycji " + pos);
                                tilemap.SetTile(pos, null);
                                miningProgress = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
