using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rb;
    private PlayerInventory playerInventory;

    private int handlingObject;

    private Vector2 direction;
    private float initialSpeed;
    private bool isRunning;
    private bool isRolling;
    private bool isCutting;
    private bool isDigging;
    private bool isWatering;

    public bool IsDigging {get => isDigging; set => isDigging = value;}
    public bool IsCutting {get => isCutting; set => isCutting = value;}
    public bool IsRunning {get => isRunning; set => isRunning = value;}
    public bool IsRolling {get => isRolling; set => isRolling = value;}
    public bool IsWatering {get => isWatering; set => isWatering = value;}
    public Vector2 Direction {get => direction; set => direction = value;}

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        rb = GetComponent<Rigidbody2D>();    
        initialSpeed = speed;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObject = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObject = 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObject = 2;
        }

        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDig();
        OnWatering();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void OnMove()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    void OnRolling() //pesquisar como fazer isso com corrotina para aprimoramentos
    {
        if(Input.GetMouseButtonDown(1))
        {
            //speed = runSpeed;
            isRolling = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            isRolling = false;
            //speed = initialSpeed;
        }
    }
    #endregion

    #region Actions

    void OnCutting()
    {
        if(handlingObject == 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isCutting = true; 
                speed = 0;
            }

            if(Input.GetMouseButtonUp(0))
            {
                isCutting = false; 
                speed = initialSpeed;
            }
        }
    }

    void OnDig()
    {
        if(handlingObject == 1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isDigging = true; 
                speed = 0;
            }

            if(Input.GetMouseButtonUp(0))
            {
                isDigging = false; 
                speed = initialSpeed;
            }
        }  
    }

    void OnWatering()
    {
        if(handlingObject == 2)
        {
            if(Input.GetMouseButtonDown(0)  && playerInventory.CurrentWater > 0)
            {
                isWatering = true; 
                speed = 0;
            }

            if(Input.GetMouseButtonUp(0) || playerInventory.CurrentWater <= 0)
            {
                isWatering = false; 
                speed = initialSpeed;
            }

            if(isWatering)
            {
                playerInventory.CurrentWater -= 1 * Time.deltaTime;
            }
        }  
    }

    #endregion
}
