using FMOD.Studio;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mining : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap tilemapMaterials;
    public float radius = 1.5f;

    float miningProgress = 0;
    float breakingProgress = 0;
    [SerializeField] private string EventPath0 = "event:/Pickup";
    [SerializeField] private GameObject breaking, pix;
    [SerializeField] private string EventPath1 = "event:/Destroy";

    Dictionary<string, string> oreMeaning = new Dictionary<string, string>();


    public GameObject moonParticle;
    public List<GameObject> particles;
    private int particleInd = 0;
    private int particleCount = 10;

    private Vector3 last;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for(int i = 0; i < particleCount; i++)
        {
            GameObject b = Instantiate(moonParticle);
            b.SetActive(false);
            particles.Add(b);
        }

        oreMeaning.Add("Ore 2", "COAL");
        oreMeaning.Add("Ore 1", "COPPER");
        oreMeaning.Add("Ore 3", "IRON");
        oreMeaning.Add("Ore 4", "GOLD");
        oreMeaning.Add("Ore 5", "DIAMONDS");
        oreMeaning.Add("Ore 6", "EMERALDS");
    }

    void PlayOreBreakEvent()
    {
        EventInstance OreBreak = RuntimeManager.CreateInstance(EventPath0);
        RuntimeManager.AttachInstanceToGameObject(OreBreak, gameObject, GetComponent<Rigidbody2D>());
        OreBreak.start();
        OreBreak.release();
    }

    void PlayBreakEvent()
    {
        EventInstance Break = RuntimeManager.CreateInstance(EventPath1);
        RuntimeManager.AttachInstanceToGameObject(Break, gameObject, GetComponent<Rigidbody2D>());
        Break.start();
        Break.release();
    }
    void SpawnParticle(Vector3 pos)
    {
        particles[particleInd].SetActive(false);
        particles[particleInd].SetActive(true);
        particles[particleInd].transform.position = pos;
        particleInd++;
        if(particleInd >= particles.Count )
        {
            particleInd = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        pix.GetComponent<Animator>().SetBool("Mining", Input.GetMouseButton(0));
       
        // Przyk�ad: usuwanie kafelka pod kursorem myszy
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

                    // Liczymy dystans od �rodka do tego pola
                    float dist = Vector2.Distance(new Vector2(center.x, center.y), new Vector2(pos.x, pos.y));


                    
                    if (dist <= radius)
                    {
                        TileBase tile = tilemap.GetTile(pos);
                        TileBase oreTile = tilemapMaterials.GetTile(pos);

                       

                        if (tile != null)
                        {
                            if (last == tilemap.CellToWorld(pos))
                            {
                                float miningTime = 2 - PlayerPrefs.GetInt("Workshop") / 2;
                                float nextBreak = miningTime / 5;

                                breakingProgress += Time.deltaTime;
                                miningProgress += Time.deltaTime;


                                breaking.transform.position = tilemap.CellToWorld(pos) + new Vector3(0.4f, 0.4f, 0);


                                if (breakingProgress >= nextBreak)
                                {
                                    breaking.GetComponent<CaveBreaking>().ChangeSprite();
                                    breakingProgress = 0;
                                }

                                if (miningProgress > miningTime)
                                {
                                    if (oreTile != null)
                                    {
                                        Debug.Log("Wykopano " + oreTile.name + " na pozycji " + pos);
                                        PlayerPrefs.SetInt(oreMeaning[oreTile.name], PlayerPrefs.GetInt(oreMeaning[oreTile.name]) + (1+1*PlayerPrefs.GetInt("Ores")));
                                        //PlayOreBreakEvent();
                                    }
                                    SpawnParticle(tilemap.CellToWorld(pos) + new Vector3(0.4f, 0.4f, 0));
                                    breaking.GetComponent<CaveBreaking>().ResetBreaking();
                                    tilemapMaterials.SetTile(pos, null);
                                    tilemap.SetTile(pos, null);
                                    PlayBreakEvent();
                                    miningProgress = 0;
                                }
                            }
                            else
                            {
                                miningProgress = 0;
                                breaking.GetComponent<CaveBreaking>().ResetBreaking();
                                last = tilemap.CellToWorld(pos);
                            }
                        }
                    }
                }
            }
        }
    }
}
