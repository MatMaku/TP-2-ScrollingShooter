using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float xLimit = 30;
    public float yLimit = 20;
    
    virtual public void Update()
    {
        //Constantemente estoy chequeando los limites
        CheckLimits();
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        //Si el proyectil entra en colisión con algo con el tag de Wall o Floor es destruido
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
    }

    internal virtual void CheckLimits()
    {
        //Si el proyectil supera cualquiera de los limites es destruido
        if (this.transform.position.x > xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.x < -xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.y > yLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.y < -yLimit)
        {
            Destroy(this.gameObject);
        }

    }

}
