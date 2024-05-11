using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smece : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        PickUp();
    }
      
    public void PickUp()
    {
        Debug.Log("!TRASH PICKED UP!");
        Destroy(gameObject);
    }
}
