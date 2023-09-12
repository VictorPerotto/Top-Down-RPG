using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;
    [SerializeField] private int random;

    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount < timeMove)
        {
            transform.Translate(new Vector2(random, 0f) * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().Woods ++;
            Destroy(gameObject);
        }
    }
}
