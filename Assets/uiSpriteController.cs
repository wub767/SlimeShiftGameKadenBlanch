using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiSpriteController : MonoBehaviour
{

    //variables

    //skybox materals
    public Material daySky;
    public Material nightSky;

    //ui sprite renderer
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    //ui texture images
    public Sprite green_eye_mat;
    public Sprite night_sky_eye_mat;

    //referece gameObjects from PlayerController
    public playerController playerController;
    public GameObject player;

    //see if player is shifted or not
    public bool shifted;

    // Start is called before the first frame update
    void Start()
    {
        //sprite renderer setup
        spriteRenderer = GetComponent<SpriteRenderer>();

        //get info from playerController
        playerController = playerController.GetComponent<playerController>();

        //set player as object for enemy to track
        player = playerController.player;
    }

    void ChangeSprite(Sprite newSprite)
    {
        //UI sprite change logic
        //sprite renderer setup
        spriteRenderer.sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //change shift ui based on player input
        shifted = playerController.shifted;
        if (shifted == true)
        {
            Debug.Log("Player UI shows player is SHIFTED");
            //change skybox to shift sky
            RenderSettings.skybox = nightSky;
            //change shiftIndicator sprite to show player is shifted
            newSprite = night_sky_eye_mat;
            ChangeSprite(newSprite);
        }
        if (shifted == false)
        {
            Debug.Log("Player UI shows player is NOT SHIFTED");
            //change skybox to normal
            RenderSettings.skybox = daySky;
            //change shiftIndicator sprite to show player is de-shifted
            newSprite = green_eye_mat;
            ChangeSprite(newSprite);
        }

        //change superjumpText based on player input
    }
}
