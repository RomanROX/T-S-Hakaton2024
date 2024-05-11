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

    void Start()
    {
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
}
