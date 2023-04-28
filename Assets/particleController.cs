using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour
{
    private Rigidbody2D rbParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if player is able to jump or not
        float yLevel = collision.GetContact(0).normal.y;
        if (yLevel > .45)
        {
            ParticleCollisionEvent particleCollisionEvent = new ParticleCollisionEvent();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
