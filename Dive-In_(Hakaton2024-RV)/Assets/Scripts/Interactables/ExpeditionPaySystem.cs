using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExpeditionPaySystem : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject playercanvas;
    [SerializeField] GameObject startExpeditionCanvas;
    [Space]
    [SerializeField] GameObject notEnoghCoins;
    [Space]
    [SerializeField] Button BuyExpedition;

    [Header("StartExpedition")]
    [SerializeField] string ExpeditionSceneName;
    [SerializeField] string SacrificeSceneName;

    // Start is called before the first frame update
    void Start()
    {
        startExpeditionCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        updatePrice();
    }

    public void ExpeditionPayEnter()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        player.GetComponent<PlayerMovement>().enabled = false;
        playercanvas.SetActive(false);
        startExpeditionCanvas.SetActive(true);
    }
    public void ExpeditionPayExit()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player.GetComponent<PlayerMovement>().enabled = true;
        playercanvas.SetActive(true);
        startExpeditionCanvas.SetActive(false);
    }

    public void updatePrice()
    {
        BuyExpedition.transform.GetChild(0).GetComponent<TMP_Text>().text = "Start (" + (GameManager.Instance.numberOfExpedition * 5).ToString() + ")";
    }

    public void PayExpedition()
    {
        if(GameManager.Instance.coins >= (GameManager.Instance.numberOfExpedition * 5))
        {
            GameManager.Instance.coins -= GameManager.Instance.numberOfExpedition * 5;
            SceneManager.LoadScene(ExpeditionSceneName);
            GameManager.Instance.numberOfExpedition++;
        }
        else
        {
            notEnoghCoins.SetActive(true);
        }
    }

    public void SacraficeButton()
    {
        Debug.Log("Sacrified");
        SceneManager.LoadScene(SacrificeSceneName);
    }
}
