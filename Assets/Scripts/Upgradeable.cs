using Unity.VisualScripting;
using UnityEngine;

public class Upgradeable : MonoBehaviour
{
    public int level=0;
    [SerializeField] private GameObject MatsNeededSpace;
    private GameObject CanvasObj;

    private bool isActive=false;
    void Awake()
    {
        CanvasObj = MatsNeededSpace.transform.root.Find("Canvas").gameObject;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    // Update is called once per frame
    void Update()
    {
        CanvasObj.SetActive(isActive);
    }
}
