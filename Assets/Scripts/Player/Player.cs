using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private float initialSpeed;
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool isRunning;
    private bool isRolling;
    private bool isCutting;

    public bool IsCutting {get => isCutting; set => isCutting = value;}
    public bool IsRunning {get => isRunning; set => isRunning = value;}
    public bool IsRolling {get => isRolling; set => isRolling = value;}
    public Vector2 Direction {get => direction; set => direction = value;}

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
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
    
    void OnCutting()
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


    #endregion
}
