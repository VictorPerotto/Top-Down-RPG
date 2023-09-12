using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [SerializeField] private int digAmount; //quantidade de cavadas 
    private int initialDigAmount;

    void Start()
    {
        initialDigAmount = digAmount;
    }


    public void OnHit()
    {
        digAmount --;

        if(digAmount <= initialDigAmount / 2)
        {
            //cavar o buraco
            spriteRenderer.sprite = hole;
        }

        if(digAmount <= 0)
        {
            //plantar cenoura
            spriteRenderer.sprite = carrot;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Dig"))
        {
            OnHit();
        }
    }
}
