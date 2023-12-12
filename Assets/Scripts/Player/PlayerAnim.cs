using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;

    private Player player;
    private Animator anim;
    private Casting cast;

    private bool isHitting;

    [SerializeField] private float recoveryTime;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();

        if(isHitting)
        {   
            if(timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0;
            }

            timeCount += Time.deltaTime;
        }
        
    }

    #region Movement

    void OnMove()
    {
        if(player.Direction.sqrMagnitude > 0)
        {
            if(player.IsRolling)
            {
                anim.SetTrigger("isRoll");
            }

           else
            {
                anim.SetInteger("transition", 1);
            } 
        }

        else
        {
            anim.SetInteger("transition", 0);
        }

        if(player.Direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0,0);
        }

        if(player.Direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0,180);
        }

        if(player.IsRunning)
        {
            anim.SetInteger("transition", 2);
        }

        if(player.IsCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if(player.IsDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if(player.IsWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }

    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.IsPaused = true;
    }

    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.IsPaused = false;
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("hammering", true);
    }

    public void OnHammeringEnded()
    {
        anim.SetBool("hammering", false);
    }

    public void OnHit()
    {
        if(!isHitting)
        {
            anim.SetTrigger("hit");
            isHitting = true;
        }
    }

    #endregion

    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);

        if(hit)
        {
            Debug.Log("TOMA");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
