using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagEnemy : Controller_Enemy
{
    public bool goingUp;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Dependiendode goingUp viaja en diagonal hacia arriba o hacia abajo
        if (goingUp)
        {
            rb.AddForce(new Vector3(-1, 1, 0) * enemySpeed);
        }
        else
        {
            rb.AddForce(new Vector3(-1, -1, 0) * enemySpeed);
        }
    }

    internal override void OnCollisionEnter(Collision collision)
    {
        //Cuando colisiona con el techo o el piso cambia el estado de goingUp
        if (collision.gameObject.CompareTag("Floor"))
        {
            goingUp = true;
            //rb.velocity = Vector3.zero;
        }
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            goingUp = false;
            //rb.velocity = Vector3.zero;
        }
        base.OnCollisionEnter(collision);
    }
}
