using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentEnemy : Controller_Enemy
{
    public bool goingUp;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    override public void Update()
    {
        //Va hacia arriba y hacia abajo constantemente
        if (goingUp)
        {
            rb.AddForce(new Vector3(-1, 10, 0) * enemySpeed);
        }
        else
        {
            rb.AddForce(new Vector3(-1, -10, 0) * enemySpeed);
        }

        Check();

        base.Update();

    }

    private void Check()
    {
        if (this.gameObject.transform.position.y > 6.5f)
        {
            goingUp = false;
        }
        else if (this.gameObject.transform.position.y < 5.5f)
        {
            goingUp = true;
        }
    }

    internal override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
