using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Controller_Enemy
{
    private GameObject player;

    private Rigidbody rb;

    private Vector3 direction;

    void Start()
    {
        //Defino player como el jugador, para despues poder tomar su posición
        if (Controller_Player._Player != null)
        {
            player = Controller_Player._Player.gameObject;
        }
        else
        {
            player = GameObject.Find("Player");
        }
        rb = GetComponent<Rigidbody>();
    }

    public override void Update()
    {
        //Si el jugador existe tomo su posición en direction
        if (player != null)
        {
            direction = -(this.transform.localPosition - player.transform.localPosition).normalized;
        }
        base.Update();
    }

    void FixedUpdate()
    {
        //Le agrego fuerza al enemigo en dirección a la posición que tomamos antes
        if (player != null)
            rb.AddForce(direction * enemySpeed);
    }
}
