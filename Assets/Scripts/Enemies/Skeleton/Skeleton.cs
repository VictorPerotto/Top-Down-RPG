using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent; // referencia do NavMeshAgent
    [SerializeField] private SkeletonAnimationController skeletonAnimator;

    private Player player; // referencia do player

    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false; // para impedir a rotação no eixo Z
        agent.updateUpAxis = false; // para impedir a movimentação no eixo Z
    }

    void Update()
    {
        agent.SetDestination(player.transform.position); // recebe um Vector3 de alvo

        // se a distancia entre os 2 objetos é menor do que o stopping distance, ele esta parado
        if(Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            skeletonAnimator.PlayAnimation(2);
        }

        else
        {
            skeletonAnimator.PlayAnimation(1);
        }

        float posX = player.transform.position.x - transform.position.x;

        if(posX >= 0)
        {
            transform.eulerAngles = new Vector2 (0, 0);
        }

        else
        {
            transform.eulerAngles = new Vector2 (0, 180);
        }
    }
}
