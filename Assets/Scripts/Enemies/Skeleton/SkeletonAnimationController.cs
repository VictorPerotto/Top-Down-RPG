using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationController : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private PlayerAnim playerAnim;
    private Animator animator;


    void Start()
    {
        playerAnim = FindObjectOfType<PlayerAnim>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void PlayAnimation(int value)
    {
        animator.SetInteger("transition", value);
    }

    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

        if(hit)
        {
            playerAnim.OnHit();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
