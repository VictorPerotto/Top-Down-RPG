using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private int totalWood;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private ParticleSystem leafs;
    private bool isCut;


    void Start()
    {
        totalWood = Random.Range(2, 5);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        health --;

        anim.SetTrigger("onHit");
        leafs.Play();

        if(health <= 0)
        {
            //cria o toco e dropa os objetos
            anim.SetTrigger("cut");
            isCut = true;

            for(int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
