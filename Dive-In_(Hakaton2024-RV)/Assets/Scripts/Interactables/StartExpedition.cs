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

    [SerializeField] ExpeditionPaySystem paySystem;

    void startExpedition()
    {
        paySystem.ExpeditionPayEnter();
    }    
}
