using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Transform playerPoint;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Color startColor;
    [SerializeField] private Color finishedColor;
    [SerializeField] private float timeToBuild;
    [SerializeField] private GameObject houseCollider;


    private bool detectingPlayer;
    private float timeCount;
    private bool started;
    private Player player;
    private PlayerAnim playerAnim;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            started = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = playerPoint.position;
            player.IsPaused = true;
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
