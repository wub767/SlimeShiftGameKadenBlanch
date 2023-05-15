using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------TODO: make energyDemom and HK invisible to player when not in their dimentions!

public class enemyController : MonoBehaviour
{
    //variables
    //Greyshift enemies
    private Rigidbody2D demonRb;
    [SerializeField]


    //movement
    //movement speed
    private float enemySpeed = 3.8f;

    //referece gameObjects from PlayerController
    public playerController playerController;
    public GameObject player;

    //see if player is in shadowrelm or not
    public bool shifted;

    //enemy (able to interact with player/objects) if player is shifted
    public bool enemyVisible;

    // Start is called before the first frame update
    void Start()
    {
        //set rigidbody for energyDemon
        demonRb = GetComponent<Rigidbody2D>();

        //get info from playerController
        playerController = playerController.GetComponent<playerController>();

        //set player as object for enemy to track
        player = playerController.player;

        //get player position
        GameObject.Find("player");

    }

    // Update is called once per frame
    void Update()
    {
            //make enemy invisible, and turn of hitboxes, when player shifts out of that enemies dimention
            enemyVisible = true;    
    }
    //------------------------------TODO: make energyDemom and HK invisible to player when not in their dimentions!
    private void FixedUpdate()
    {
        //get shifted variable from playercontroller
        shifted = playerController.shifted;
        if (shifted == true)
        {
            //move enemy towards player location if player is shifted
            demonRb.AddForce((player.transform.position - transform.position).normalized * enemySpeed);
            Debug.Log("Energy Demon is tracking player!");
        }
    }
}
