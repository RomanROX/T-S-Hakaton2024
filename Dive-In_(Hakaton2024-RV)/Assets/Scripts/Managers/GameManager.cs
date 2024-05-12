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
    public int u_Peraje = 1;
    public int u_Rukavice = 1;
    public int u_Spremnik = 1;
    public int u_Naocale = 1;

    [Header("Player Stats")]
    public float speedMultiplier;
    public float pickUpSpeedMultiplier;
    public float tankSizeMultiplier;
    public float clarityMultiplier;

    [Header("Player Expedition")]
    public int trashCollected = 0;

    void Awake()
    {
        speedMultiplier = 1f + (0.15f * u_Peraje);
        pickUpSpeedMultiplier = 1f + (0.15f * u_Rukavice);
        tankSizeMultiplier = 1f + (0.15f * u_Spremnik);
        clarityMultiplier = 1f + (0.5f * u_Naocale);

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
