
using System.Collections.Generic;
using UnityEngine;

public class PickaxeSkin : MonoBehaviour
{
    public List<Sprite> spr;
    [SerializeField] private SpriteRenderer rnd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rnd.sprite = spr[PlayerPrefs.GetInt("Workshop")];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
