using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Itens")]
    [SerializeField] private Image waterBar;
    [SerializeField] private Image woodBar;
    [SerializeField] private Image carrotBar;

    [Header("Tools")]
    [SerializeField] private List<Image> toolsUI;

    [SerializeField] private Color selectedColor;
    [SerializeField] private Color nonSelectedColor;

    private PlayerInventory playerInventory;
    private Player player;

    public static HUDController instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        playerInventory = FindObjectOfType<PlayerInventory>();
        player = playerInventory.GetComponent<Player>();
    }

    void Start()
    {
        waterBar.fillAmount = 0;
        woodBar.fillAmount = 0;
        carrotBar.fillAmount = 0;
    }

    void Update()
    {
        waterBar.fillAmount = playerInventory.CurrentWater/ playerInventory.MaxWater;
        woodBar.fillAmount = playerInventory.CurrentWoods/ playerInventory.MaxWood;
        carrotBar.fillAmount = playerInventory.CurrentCarrots/ playerInventory.MaxCarrot;
    }

    public void ChangeTool()
    {
        for (int i = 0; i < toolsUI.Count; i ++)
        {
            if(i == player.HandlingObject)
            {
                toolsUI[i].color = selectedColor;
            }
            else
            {
                toolsUI[i].color = nonSelectedColor;
            }
        }
    }
}
