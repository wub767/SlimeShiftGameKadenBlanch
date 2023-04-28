using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    //set camera offsett to give good FOV
    private Vector3 offset = new Vector3(-0f, -0, -30);
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        //make camera follow bound player
        transform.position = player.transform.position + offset;
    }
}
