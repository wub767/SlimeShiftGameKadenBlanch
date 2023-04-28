using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    ///variables
    
    //player
    public GameObject player;


    //set lateral and virtical movement speed
    public float horizontalInput;

    public bool verticalInput;

    public bool shiftInput;

    //player health
    public int health = 3;

    //bool if player is shifted or not
    public bool shifted;

    //set rigidbody and speed
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 5.0f;

    //set default jump ablility
    bool canJump = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
    //check if player is able to jump or not
        float yLevel = collision.GetContact(0).normal.y;
        if (yLevel > .45)
        {
            canJump = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player falls off the map deathBox logic
        if (collision.tag == "death")
        {
            SceneManager.LoadScene("background_and_forest_platform");
            Debug.Log("Player Respawned!");
            health -= 1;
        }

        //bonfire logic
        if (collision.tag == "bonfireLit" || health < 3)
        {
            Debug.Log("Bonfire Lit, Health restored!");
            health = 3;
        }

        //if player reaches the god statue/end of game
        if (collision.tag == "GodStatue")
        {
            Debug.Log("Player cured the curse!");
        }

        if (collision.tag == "touchDemon")
        {
            Debug.Log("Player was killed by a demon!");
        }
    }



    //movement
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    //set fixed update rate
    private void FixedUpdate()
    {

        //if player hits jump button do this
        if (canJump && verticalInput)
        {
            rb.AddForce(new Vector2(0, 500));
            canJump = false;
            Debug.Log("Player jumped!");
        }

        //lateral movement
        rb.AddForce(new Vector2(horizontalInput * speed, 0));

        //dimention shift logic
        if (shifted)
        {
            Debug.Log("Player GreyShifted");
        }
    }

    // Update is called once per frame
    void Update()
    {

        //set jump button to spaceBar
        verticalInput = Input.GetKey(KeyCode.W);

        //set horizontal movement speed based on input
        //gives movement direction
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //player warping controller
        shiftInput = Input.GetKeyDown(KeyCode.Space);
        if(shiftInput)
        {
            shifted = !shifted;
        }

        //get playerPosition for energyDemon to track towards
        Transform playerTransform = player.transform;
        // Move to player position
        Vector2 playerPosition = playerTransform.position;
    }
}
