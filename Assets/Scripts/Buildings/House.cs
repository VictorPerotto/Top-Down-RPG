using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Sprite houseSprite;
    [SerializeField] private Color startColor;
    [SerializeField] private Color finishedColor;
    [SerializeField] private float timeToBuild;


    private bool detectingPlayer;
    private float timeCount;
    private bool started;
    private PlayerInventory playerInventory;
    private PlayerAnim playerAnim;

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        playerAnim = playerInventory.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            started = true;
        }

        if(started)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= timeToBuild)
            {
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
