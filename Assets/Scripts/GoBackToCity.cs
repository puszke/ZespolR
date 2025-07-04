using UnityEngine;

public class GoBackToCity : MonoBehaviour
{
    public GameObject panel;
   
    void Update()
    {
        panel.SetActive(transform.position.y > 159f);

        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetString("SceneChange", "SampleScene");
            SceneChanger.instance.SceneChange("Loading");
        }
    }
}
