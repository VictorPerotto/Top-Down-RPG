using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private bool detecting;
    [SerializeField] private int digAmount; //quantidade de cavadas 
    [SerializeField] private float waterAmount; //quantidade de agua necessaria para plantar
    [SerializeField] private float waterMultiplier;
    private float currentWater;
    private int currentDig;
    private bool hasHole;

    private PlayerInventory playerInventory;

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    void Update()
    {
        if(hasHole)
        {
            if(detecting)
            {
                currentWater += waterMultiplier * Time.deltaTime;
            }

            if(currentWater >= waterAmount)
            {
                spriteRenderer.sprite = carrot;

                if(Input.GetKeyDown(KeyCode.E))
                {
                    spriteRenderer.sprite = hole;
                    playerInventory.CurrentCarrots ++;
                    currentWater = 0;
                }
            }
        }
        
    }

    public void OnHit()
    {
        currentDig ++;

        if(currentDig >= digAmount)
        {
            //cavar o buraco
            spriteRenderer.sprite = hole;
            hasHole = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Dig"))
        {
            OnHit();
        }

        if(other.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Water"))
        {
            detecting = false;
        }
    }
}
