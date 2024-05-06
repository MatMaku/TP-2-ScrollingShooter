using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_EnemyProjectile : Projectile
{
    private GameObject player;

    private Vector3 direction;

    private Rigidbody rb;

    public float enemyProjectileSpeed;

    void Start()
    {
        //Cuando el proyectil enemigo es creado si existe el jugador toma la posición de este en ese momento
        if (Controller_Player._Player != null)
        {
            player = Controller_Player._Player.gameObject;
            direction = -(this.transform.localPosition - player.transform.localPosition).normalized;
        }
        rb = GetComponent<Rigidbody>();
    }

    
    public override void Update()
    {
        //Hace que el proyectil se mueva hacia la dirección que tomaron antes en referencia al jugador
        rb.AddForce(direction*enemyProjectileSpeed);
        base.Update();
    }
}
