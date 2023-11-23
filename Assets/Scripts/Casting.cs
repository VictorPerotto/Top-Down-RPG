using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{ 
    [SerializeField] private int chance;
    [SerializeField] private GameObject fishPrefab;
    
    private PlayerInventory playerInventory;
    private PlayerAnim playerAnim;
    private bool detectingPlayer;

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        playerAnim = playerInventory.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int random = Random.Range(1,100);

        if(random <= chance)
        {
            Instantiate(fishPrefab, playerInventory.transform.position + new Vector3 (Random.Range(-1.5f, -1f), 0f, 0f), Quaternion.identity);
        }

        else
        {
            Debug.Log("So tem vento nessa agua");
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
