using System;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeable : MonoBehaviour
{
    public int level=0;
    [SerializeField] private GameObject MatsNeededSpace;
    private GameObject CanvasObj;

    private bool isActive=false;

    public List<LevelReq> levels;

    [Serializable]
    public class MatNeeded
    {
        public string name = "COPPER";
        public int amount = 99;
    }

    [Serializable]
    public class LevelReq
    {
        public List<MatNeeded> requiredOres;
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
    }
}
