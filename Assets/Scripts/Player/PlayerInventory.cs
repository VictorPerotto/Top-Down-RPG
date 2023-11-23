using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{   
    [Header("Amounts")]
    [SerializeField] private int currentWoods;
    [SerializeField] private int currentCarrots;
    [SerializeField] private float currentWater;
    [SerializeField] private float currentFishes;

    [Header("Limits")]
    [SerializeField] private float maxWater;
    [SerializeField] private float maxWood;
    [SerializeField] private float maxCarrot;
    [SerializeField] private float maxFishes;

    public int CurrentWoods {get => currentWoods; set => currentWoods = value;}
    public int CurrentCarrots {get => currentCarrots; set => currentCarrots = value;}
    public float CurrentWater {get => currentWater; set => currentWater = value;}
    public float CurrentFishes {get => currentFishes; set => currentFishes = value;}
    public float MaxWater { get => maxWater; set => maxWater = value; }
    public float MaxWood { get => maxWood; set => maxWood = value; }
    public float MaxCarrot { get => maxCarrot; set => maxCarrot = value; }
    public float MaxFishes { get => maxFishes; set => maxFishes = value; }

    public void AddWater(float water)
    {
        if(currentWater < maxWater)
        {
            currentWater += water;
        }
    }

    public void AddWood(int wood)
    {
        if(currentWoods < maxWood)
        {
            currentWoods += wood;
        }
    }

    
    public void AddCarrot(int carrot)
    {
        if(currentCarrots < maxCarrot)
        {
            currentCarrots += carrot;
        }
    }

    public void AddFishes(float fishes)
    {
        if(currentFishes < maxFishes)
        {
            currentFishes += fishes;
        }
    }
    
}
