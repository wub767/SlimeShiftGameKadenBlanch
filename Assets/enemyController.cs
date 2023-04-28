using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    //variables
    //Greyshift enemies
    private Rigidbody2D demonRb;
    [SerializeField]

    //movement
    //movement speed
    private float enemySpeed = 0.5f;

    //referece gameObjects from PlayerController
    public playerController playerController;
    public GameObject player;

    //see if player is in shadowrelm or not
    public bool shifted;

    //enemy (able to interact with player/objects) if player is shifted
    public bool enemyTangeble;

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
        //move enemy towards player location
        demonRb.AddForce((player.transform.position - transform.position).normalized * enemySpeed);

        //see if player is greyshifted (AKA 'visable' to energyDemon)
        if (shifted == true)
        {
            //make enemy invisible, and turn of hitboxes, when player shifts out of that enemies dimention
            enemyTangeble = false;
        }
    }
}
