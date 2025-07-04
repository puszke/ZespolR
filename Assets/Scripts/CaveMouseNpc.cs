using System.Collections;
using UnityEngine;

public class CaveMouseNpc : MonoBehaviour
{

    public float speed = 1;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Think());
    }
    IEnumerator Think()
    {
        //Zrobione by nie zawiesza³ siê czasami na œciankach!!!
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
        StartCoroutine(Think());
    }
    private void FixedUpdate()
    {
        rb2d.linearVelocityX = speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            PlayerPrefs.SetInt("MOUSES", PlayerPrefs.GetInt("MOUSES")+1);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            speed = -speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
