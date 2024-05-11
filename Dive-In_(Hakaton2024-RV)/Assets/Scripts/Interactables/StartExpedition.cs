using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartExpedition : MonoBehaviour, IInteractable
{
    //interact interface metoda
    public void OnInteract()
    {
        startExpedition();
    }

    [SerializeField] string imeScene;
    
    void startExpedition()
    {
        Debug.Log("!EXPEDITION STARTED!");
        //SceneManager.LoadScene(imeScene);
    }    
}
