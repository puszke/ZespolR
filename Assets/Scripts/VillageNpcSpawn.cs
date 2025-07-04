using UnityEngine;

public class VillageNpcSpawn : MonoBehaviour
{
    public GameObject backgroundCharacter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i =0; i<PlayerPrefs.GetInt("MOUSES");  i++)
        {
            GameObject b = Instantiate(backgroundCharacter);
            b.transform.position = new Vector2(Random.Range(-8, 8), -1.61f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
