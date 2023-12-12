using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int woodAmount;
    [SerializeField] private Color startColor;
    [SerializeField] private Color finishedColor;
    [SerializeField] private float timeToBuild;

    [Header("Components")]
    [SerializeField] private GameObject houseCollider;
    [SerializeField] private Transform playerPoint;
    [SerializeField] private SpriteRenderer houseSprite;

    private bool detectingPlayer;
    private float timeCount;
    private bool started;
    private Player player;
    private PlayerAnim playerAnim;
    private PlayerInventory playerInventory;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerInventory.CurrentWoods >= woodAmount)
        {
            started = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = playerPoint.position;
            player.IsPaused = true;
            playerInventory.CurrentWoods -= woodAmount;
        }

        if(started)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= timeToBuild)
            {
                playerAnim.OnHammeringEnded();
                houseSprite.color = finishedColor;  
                player.IsPaused = false;
                houseCollider.SetActive(true);
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