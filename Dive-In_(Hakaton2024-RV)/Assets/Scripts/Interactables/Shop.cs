using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        ShopEnter();
    }

    [SerializeField] GameObject player;
    [SerializeField] GameObject playerUI;
    [Space]
    [SerializeField] GameObject shopUI;

    // Start is called before the first frame update
    void Start()
    {
        shopUI.SetActive(false);
    }

    void ShopEnter()
    {
        player.SetActive(false);
        playerUI.SetActive(false);

        shopUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShopQuit()
    {
        player.SetActive(true);
        playerUI.SetActive(true);

        shopUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
