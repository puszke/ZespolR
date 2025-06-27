using UnityEngine;

public class LookAtMouse2D : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    void Update()
    {
        // Pozycja myszy na ekranie
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Zamiana na pozycj� w �wiecie
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // Oblicz kierunek
        Vector2 direction = mouseWorldPosition - transform.position;

        // Oblicz k�t (z radian�w na stopnie)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Obr�� obiekt
        transform.rotation = Quaternion.Euler(0, 0, angle);

      
        spr.flipY = angle < -90 || angle > 90;
   
    }
}
