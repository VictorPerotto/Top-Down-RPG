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
    private int initialDigAmount;

    void Start()
    {
        initialDigAmount = digAmount;
    }

    void Update()
    {
        if(detecting)
        {
            currentWater += waterMultiplier * Time.deltaTime;
        }

        if(currentWater >= waterAmount)
        {
            spriteRenderer.sprite = carrot;
        }
    }

    public void OnHit()
    {
        digAmount --;

        if(digAmount <= initialDigAmount / 2)
        {
            //cavar o buraco
            spriteRenderer.sprite = hole;
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
