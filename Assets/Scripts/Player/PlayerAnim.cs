using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
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
    #endregion
}
