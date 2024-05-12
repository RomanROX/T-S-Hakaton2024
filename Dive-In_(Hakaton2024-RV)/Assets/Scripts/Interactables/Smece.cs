using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smece : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        PickUp();
    }

    [SerializeField] public GameObject bubbleVFX;

    public void PickUp()
    {
        GameManager.Instance.trashCollected++;

        Debug.Log("!TRASH PICKED UP!");
        Destroy(gameObject);
    }
}
