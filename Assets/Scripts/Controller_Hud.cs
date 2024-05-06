﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public Text gameOverText;

    public static bool gameOver;

    public static int points;

    public static float invencibilityTime;

    public Text pointsText;

    public Text powerUpText;

    public Text invencibilityText;

    private Controller_Player player;

    void Start()
    {
        invencibilityTime = 10;
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        points = 0;
        player = GameObject.Find("Player").GetComponent<Controller_Player>();
    }

    void Update()
    {
        if (player.invencibility)
        {
            invencibilityTime -= Time.deltaTime;
            invencibilityText.text = "Invencibility: " + Math.Round(invencibilityTime, 0).ToString();
        }
        else
        {
            invencibilityText.text = "";
            invencibilityTime = 10;
        }

        //Si el gameOver es true significa que el jugador perdio y se activa el texto de game over en la pantalla
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over" ;
            gameOverText.gameObject.SetActive(true);
        }
        //En este if actualizo el texto del power up para indicar cual power up posee el jugador siempre que el jugador exista
        if (player!=null)
        {
            if (player.powerUpCount <= 0)
            {
                powerUpText.text = "PowerUp: None";
            }
            else if (player.powerUpCount == 1)
            {
                powerUpText.text = "PowerUp: Speed Up";
            }
            else if (player.powerUpCount == 2)
            {
                powerUpText.text = "PowerUp: Missile";
            }
            else if (player.powerUpCount == 3)
            {
                powerUpText.text = "PowerUp: Double shoot";
            }
            else if (player.powerUpCount == 4)
            {
                powerUpText.text = "PowerUp: Laser";
            }
            else if (player.powerUpCount == 5)
            {
                powerUpText.text = "PowerUp: Option";
            }
            else if (player.powerUpCount == 6)
            {
                powerUpText.text = "PowerUp: Shield";
            }
            else if (player.powerUpCount >= 7)
            {
                powerUpText.text = "PowerUp: Invencibility";
            }
        }
        pointsText.text = "Score: " + points.ToString();
    }
}
