using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public float enemySpeed;

    public float xLimit;

    private float shootingCooldown;

    public GameObject enemyProjectile;

    public GameObject powerUp;

    void Start()
    {
        //Establezco el cooldown de los disparos de una manera random cuando se crea el objeto
        shootingCooldown = UnityEngine.Random.Range(1, 10);
    }

    public virtual void Update()
    {
        //En cada update voy reduciendo el cooldown para que dispare
        shootingCooldown -= Time.deltaTime;
        CheckLimits();
        ShootPlayer();
    }

    void ShootPlayer()
    {
        //Si el jugador existe y el cooldown bajo de 0 se crea un proyectil y se reinicia el cooldown
        if (Controller_Player._Player != null)
        {
            if (shootingCooldown <= 0)
            {
                Instantiate(enemyProjectile, transform.position, Quaternion.identity);
                shootingCooldown = UnityEngine.Random.Range(1, 10);
            }
        }
    }


    private void CheckLimits()
    {
        //Aca se destruye el objeto si se pasa del limite de X establecido
        if (this.transform.position.x < xLimit)
        {
            Destroy(this.gameObject);
        }
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        //Si el enemigo entra en contacto con un proyectil se destruyen ambos, si entra en contacto con un laser se destruye solo el enemigo
        //Ademas se suman los puntos y se crea un power up
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GeneratePowerUp();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Controller_Hud.points++;
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            GeneratePowerUp();
            Destroy(this.gameObject);
            Controller_Hud.points++;
        }
    }

    private void GeneratePowerUp()
    {
        //Genera un power up cuando se destruye un enemigo de manera random
        int rnd = UnityEngine.Random.Range(0, 3);
        if (rnd == 2)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
    }
}
