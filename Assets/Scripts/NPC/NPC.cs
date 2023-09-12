using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //setted variables
    [SerializeField]private float speed;

    //no-setted variables
    private float initialSpeed;
    private int index;

    //components
    private Animator anim;

    //structures
    public List<Transform> paths = new List<Transform>();

    void Start()
    {
        anim = GetComponent<Animator>();
        initialSpeed = speed;
    }

    void Update()
    {
        #region Move
        //MoveTowards - calcula a posição entre 2 pontos e move eles atraves de uma velocidade, usamos o Time.deltaTime para tornar a velocidade independente do frame rate
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime); 

        //retorna a posição entre 2 pontos
        if(Vector2.Distance(transform.position, paths[index].position) <= 0.1f)
        {

            index = Random.Range(0, paths.Count); //seleciona um path aleatorio

            /*vai indo em uma ordem de paths até o final, depois volta ao primeiro
            if(index < paths.Count - 1)
            {
                index ++;
            }

            else
            {
                index = 0;
            }*/
        }
        #endregion

        #region Set Direction

        Vector2 direction = paths[index].position - transform.position;

        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2 (0, 180);
        }
        #endregion

        #region When is talking

        if(DialogueControl.instance.IsShowing)
        {
            speed = 0;
            anim.SetBool("isWalking", false);
        }

        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }
        #endregion
    }
}
