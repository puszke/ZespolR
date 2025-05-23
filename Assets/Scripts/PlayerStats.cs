using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //COPPER
    //COAL
    //IRON
    //GOLD
    //EMERALDS
    //DIAMONDS

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetInt("StartedTheGame")==0)
            ResetPlayerStats();
    }

    void ResetPlayerStats()
    {
        PlayerPrefs.SetInt("COPPER", 0);
        PlayerPrefs.SetInt("COAL", 0);
        PlayerPrefs.SetInt("IRON", 0);
        PlayerPrefs.SetInt("GOLD", 0);
        PlayerPrefs.SetInt("EMERALDS", 0);
        PlayerPrefs.SetInt("DIAMONDS", 0);

        PlayerPrefs.SetInt("StartedTheGame", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
