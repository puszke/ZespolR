using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    //COAL
    //COPPER
    //IRON
    //GOLD
    //DIAMOND
    //MOUSE

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetString("FirstTimePlaying")=="")
        {
            PlayerPrefs.SetInt("COAL", 0);
            PlayerPrefs.SetInt("COPPER", 0);
            PlayerPrefs.SetInt("IRON", 0);
            PlayerPrefs.SetInt("GOLD", 0);
            PlayerPrefs.SetInt("DIAMOND", 0);
            PlayerPrefs.SetInt("MOUSE", 0);
            PlayerPrefs.SetString("FirstTimePlaying", "balls");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
