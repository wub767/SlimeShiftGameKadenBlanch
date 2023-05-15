using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HKEnemyController : MonoBehaviour
{
    //variables
    //Greyshift enemies
    private Rigidbody2D hunterRb;
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
    public bool hunterVisible;

    // Start is called before the first frame update
    void Start()
    {
        //set rigidbody for energyDemon
        hunterRb = GetComponent<Rigidbody2D>();

        //get info from playerController
        playerController = playerController.GetComponent<playerController>();

        //set player as object for enemy to track
        player = playerController.player;

        //get player position
        GameObject.Find("player");

        hunterVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //make enemy invisible when player shifts out of that enemies dimention

    }

    private void FixedUpdate()
    {
        //get shifted variable from playercontroller
        shifted = playerController.shifted;
        if (shifted == false)
        {
            //move enemy towards player location if player is NOT shifted
            hunterRb.AddForce((player.transform.position - transform.position).normalized * enemySpeed);
            Debug.Log("Hunter Killer is tracking player!");
        }
    }
}
