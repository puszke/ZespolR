using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upgradeable : MonoBehaviour
{
    public int level=0;
    [SerializeField] private GameObject MatsNeededSpace;
    private GameObject CanvasObj;

    private bool isActive=false;

    public List<MaterialNeeded> materialsNeeded;


    [System.Serializable]
    public class MaterialNeeded
    {
        public string name;
        public int amount = 0;
    }
    void Awake()
    {
        CanvasObj = MatsNeededSpace.transform.root.Find("Canvas").gameObject;
    }
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag=="Player")
        {
            isActive=true;
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.tag=="Player")
        {
            isActive=false;
        }
    }
    
    void Update()
    {
        CanvasObj.SetActive(isActive);
        if(isActive)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                bool canUpgrade = false;
                foreach(MaterialNeeded mat in materialsNeeded)
                {
                    if(PlayerPrefs.GetInt(mat.name)>=mat.amount)
                    {
                        
                        //canUpgrade = true;
                    }
                }
            }
        }
    }
}
