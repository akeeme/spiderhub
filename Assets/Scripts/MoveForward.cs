using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float speed = 8;
    public GameObject web;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (startTime + 1 < Time.time)
        {
            Instantiate(web, transform.position, transform.rotation);
            Destroy(gameObject);

        }


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Harmful"))
        {
            Instantiate(web, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
