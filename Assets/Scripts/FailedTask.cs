using System.Collections;
using UnityEngine;

public class FailedTask : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(b());
    }
    IEnumerator b()
    {
        yield return new WaitForSeconds(8);
        ResetPlayerStats(0);
        SceneChanger.instance.SceneChange("SampleScene");
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
  
}
