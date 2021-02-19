using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
    private Rigidbody2D rb;

    //public GameObject Player;
    public Transform target;
    public GameObject player;
    public float movementSpeed = 5;
    public float minDistance = 10;
    private float range;
    public bool moving = false;
    public bool jumping = false;
    public bool jumpable = true;
    public float restTime;
    public float jumpTime;
    public bool midJump = false;
    public bool rested = false;
    public bool noRepeat = false;

    public GameObject spit;
    public bool web = false;
    public bool webAble = true;
    public float webTime;
    public bool noRepeatWeb = false;

    public BugsLeft bugsLeft;
    public GameObject text;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
        text = GameObject.Find("Text");
        bugsLeft = text.GetComponent<BugsLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform;

        range = Vector2.Distance(transform.position, target.position);

        if (range < minDistance)
        {
            if (jumping == false && web == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
                moving = true;
            }

            //Jumping Bug

            if (jumping == true && jumpable == true)
            {

                midJump = true;
                jumpTime = Time.time;
                jumpable = false;
                
                
            }
            if (midJump == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * 3 * Time.deltaTime);
            }

            if (jumpTime + .25f < Time.time && rested == false)
            {
                midJump = false;
                restTime = Time.time;
                rested = true;
                noRepeat = false;
            }
            if (restTime + 2 < Time.time && noRepeat == false)
            {
                jumpable = true;
                rested = false;
                noRepeat = true;
            }

            //Web Spider
            if (web == true && webAble == true)
            {
                Instantiate(spit, transform.position, transform.rotation);
                webTime = Time.time;
                webAble = false;
                noRepeatWeb = false;
            }
            if (webTime + 4 < Time.time && noRepeatWeb == false)
            {
                webAble = true;
                noRepeatWeb = true;
            }
            if (web == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed/2 * Time.deltaTime);
            }
        }
        else moving = false;


        

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        

       

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gas"))
        {
            bugsLeft.bugsLeft -= 1;
            Destroy(gameObject);
        }
    }

}

