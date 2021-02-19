using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float horizontalInput;
    public float verticalInput;
    public float speed = 5;
    public float mapRange = 19;
    public float speedStart;
    public float slow = 1;
    public float slowTime;
    


    //Potion

    public float invincibleStartTime;
    public float invincibleDuration = 5;
    public bool invincible = false;
    public SpriteRenderer spriteRenderer;



    //Weapon
    public float smokeCooldown = 3;
    public float smokeTime;
    public float cooldownCountdown;
    public GameObject gas;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed * slow);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed * slow);

        if (slowTime + 2 < Time.time)
        {
            slow = 1;
        }

        //Out of bounds

        if(transform.position.y < -mapRange)
        {
            transform.position = new Vector3(transform.position.x, -mapRange);
        }

        if(transform.position.y > mapRange)
        {

            transform.position = new Vector3(transform.position.x, mapRange);
        }
        if(transform.position.x < -mapRange)
        {
            transform.position = new Vector3(-mapRange, transform.position.y);
        }
        if(transform.position.x > mapRange)
        {
            transform.position = new Vector3(mapRange, transform.position.y);
        }



        //Weapons

        if(invincibleStartTime + invincibleDuration < Time.time)
        {
            invincible = false;
            spriteRenderer.color = Color.white;
        }
        if(Input.GetKeyDown(KeyCode.Space) && smokeTime < Time.time)
        {
            Instantiate(gas, transform.position, transform.rotation);
            smokeTime = Time.time + smokeCooldown;
        }
        cooldownCountdown = smokeTime - Time.time;
        if (cooldownCountdown < 0)
        {
            cooldownCountdown = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Speed"))
        {
            speed += 10;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("SmokeBuff"))
        {
            smokeCooldown -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Invincible"))
        {
            invincibleStartTime = Time.time;
            invincible = true;
            spriteRenderer.color = Color.red;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("web"))
        {
            slow = .5f;
            slowTime = Time.time;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Harmful") && invincible == false)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

}

