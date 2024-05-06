using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Controller_Player._Player.gameObject.SetActive(true);
            Controller_Player._Player.gameObject.transform.position = new Vector3(-8,6,0);
            Controller_Player._Player.powerUpCount = 0;
            Controller_Player._Player.doubleShoot = false;
            Controller_Player._Player.missiles = false;
            Controller_Player._Player.forceField = false;
            Controller_Player._Player.laserOn = false;
            Controller_Player._Player.options.Clear();
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
