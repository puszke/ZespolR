using System.Collections;
using UnityEngine;

public class LoadingSceneMockup : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ChangeScene());
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);

        SceneChanger.instance.SceneChange(PlayerPrefs.GetString("SceneChange"));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
