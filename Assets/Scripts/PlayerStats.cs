using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //COPPER
    //COAL
    //IRON
    //GOLD
    //EMERALDS
    //DIAMONDS

    void Awake()
    {
        PlayerPrefs.SetInt("StartedTheGame", 0);//<- USUN TO PRZED WYPUSZCZENIEM GRY BO UMRZESZ

        if (PlayerPrefs.GetInt("StartedTheGame") == 0)
        {
            PlayerPrefs.DeleteAll();
            ResetPlayerStats(1110);
        }
    }

    void ResetPlayerStats(int nums)
    {
        PlayerPrefs.SetInt("COPPER", nums);
        PlayerPrefs.SetInt("COAL", nums);
        PlayerPrefs.SetInt("IRON", nums);
        PlayerPrefs.SetInt("GOLD", nums);
        PlayerPrefs.SetInt("EMERALDS", nums);
        PlayerPrefs.SetInt("DIAMONDS", nums);
        //PlayerPrefs.SetInt("MOUSES", nums);

        PlayerPrefs.SetInt("StartedTheGame", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
