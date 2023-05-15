using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerAnimator : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    

    //player
    public GameObject player;

    //movement inputs
    public float horizontalInput;
    public bool verticalInput;

    //old player position for reference
    Vector2 lastPos() { return transform.position; }

    //players present position
    Vector2 presentPos() { return transform.position; }

    //player remainingSuperJump
    public int health = 3;

    //animation refrence
    public Animator anim;

    //animation state (check if animation is finished before playing the next one)
    AnimatorStateInfo animatorStateInfo;
    public float NTime;
    public bool animationFinished = false;


    //player movement logic boolians (say if player is doing that animation or not)
    public bool playerJumping = false;
    public bool playerMove = false;

    
    /// <summary>
    /// ANIMATION LOGIC AND UPDATES
    /// </summary>
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //update player animations
    private void FixedUpdate()
    {
        //check if animation finished
        animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        NTime = animatorStateInfo.normalizedTime;

        if (NTime > 1.0f) animationFinished = true;

        //if player is jumping use player_jump animation
        if (Input.GetKey(KeyCode.W))
        {
            Debug.ClearDeveloperConsole();
            //Debug.Log("Player is in a jumping animation!");
            //anim.Play("player_jump");
            //playerJumping = true;
        }

        //if player is moving use player_move animation
        if (Input.GetKey(KeyCode.A) ||  Input.GetKey(KeyCode.D) && animationFinished == true)
        {
            Debug.ClearDeveloperConsole();
            Debug.Log("Player is in a moving animation!");
            anim.Play("player_move");
            playerMove = true;
            
        }

        //set idle as default animation
        else if (animationFinished == true)
        {
           playerJumping = false;
           playerMove = false;
           anim.Play("player_idle");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
