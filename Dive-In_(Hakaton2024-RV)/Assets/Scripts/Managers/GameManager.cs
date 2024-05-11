using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public int numberOfExpedition = 0;

    [Header("Player")]
    public int coins = 0;

    [Header("Player Upgrades")]
    public int u_Peraje = 0;
    public int u_Rukavice = 0;
    public int u_Spremnik = 0;
    public int u_Naocale = 0;

    [Header("Player Stats")]
    public float speedMultiplier;
    public float pickUpSpeedMultiplier;
    public float tankSizeMultiplier;
    public float clarityMultiplier;

    void Awake()
    {
        speedMultiplier = 1f + (0.05f * u_Peraje);
        pickUpSpeedMultiplier = 1f + (0.1f * u_Rukavice);
        tankSizeMultiplier = 1f + (0.05f * u_Spremnik);
        clarityMultiplier = 1f + (0.1f * u_Naocale);

        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Start()
    {
    }
}
