using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        shopInteract();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shopInteract()
    {
        Debug.Log("!SHOP OPENED!");
    }
}
