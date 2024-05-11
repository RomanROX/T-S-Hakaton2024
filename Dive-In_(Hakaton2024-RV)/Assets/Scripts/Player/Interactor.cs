using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dodavanje interface kako bi mogli dodati metodu za svaki objekt koji naslijedi ovaj interface
interface IInteractable
{
    public void OnInteract();
}

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] float interactRange;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interObj))
                {
                    interObj.OnInteract();
                }
            }
        }
    }
}
