using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{

    ///variables

    //player gameObject
    public GameObject player;

    //player sound effects
    private AudioSource playerShiftAudio;


    //set lateral and virtical movement speed
    public float horizontalInput;

    public bool verticalInput;

    public bool shiftInput;

    public bool superJumpInput;

    //player remainingSuperJump
    public int remainingSuperJump = 0;

    //bool if player is shifted or not
    public bool shifted;


    //set rigidbody and speed
    public Rigidbody2D rb;
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
        }

        //bonfire powerup logic
        if (collision.tag == "bonfireLit")
        {
            Debug.Log("Bonfire lit, super jumps doubled!");
            remainingSuperJump += 6;
        }

        //if player reaches the god statue/end of game
        if (collision.tag == "GodStatue")
        {
            Debug.Log("Player cured the curse!");
        }

        //------------Enemy Collision Logic-------------
        //if player touches energyDemon when not shifted
        if (collision.tag == "touchDemon" && shifted == true)
        {
            Debug.Log("Player was killed by a Demon!");
            SceneManager.LoadScene("background_and_forest_platform");
        }

        if (collision.tag == "touchHunter" && shifted == false){
            Debug.Log("Player was killed by a Hunter Killer");
            SceneManager.LoadScene("background_and_forest_platform");
        }
    }



    //movement
    // Start is called before the first frame update
    void Start()
    {
        //get player's rigidbody
        rb = GetComponent<Rigidbody2D>();

        //set audio file for player shift sfx
        playerShiftAudio = GetComponent<AudioSource>();
       
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

        //if player holds jump button do SuperJump
        if (superJumpInput && remainingSuperJump > 0)
        {
            Debug.Log("Player can SuperJump!");
            rb.AddForce(new Vector2(0, 650));
            remainingSuperJump -= 1;
        }

        //lateral movement
        rb.AddForce(new Vector2(horizontalInput * speed, 0));

        //dimention shift logic and Player UI
        if (shifted)
        {
            Debug.Log("Player Shifted");
        }
    }

    // Update is called once per frame
    void Update()
    {

        //player jump controller
        verticalInput = Input.GetKey(KeyCode.W);

        superJumpInput = Input.GetKeyDown(KeyCode.LeftShift);


        //set horizontal movement speed based on input
        //gives movement direction
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //player shifting controller
        shiftInput = Input.GetKeyDown(KeyCode.Space);
        if(shiftInput)
        {
            shifted = !shifted;
            
            //play shift audio sfx
            playerShiftAudio.Play();
        }

        //--------Enemy Tracking-------------
        //get playerPosition for energyDemon to track towards

        Transform playerTransform = player.transform;
        // Move to player position
        Vector2 playerPosition = playerTransform.position;

    }
}
