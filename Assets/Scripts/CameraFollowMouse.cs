using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public GameObject mouse;
    public float followSpeed = 10;

    public Vector2 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.transform.position.x > offset.x && mouse.transform.position.x < offset.y)
        { 
            transform.position = Vector2.Lerp(transform.position, mouse.transform.position, followSpeed*Time.deltaTime);
            transform.position = new Vector3(transform.position.x, 1, -10);
        }

    }
}
