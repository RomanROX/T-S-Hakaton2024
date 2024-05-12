using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//dodavanje interface kako bi mogli dodati metodu za svaki objekt koji naslijedi ovaj interface
interface IInteractable
{
    public void OnInteract();
}

public class Interactor : MonoBehaviour
{
    enum CursorState
    {
        not_interactable,
        interactable
    }
    [Header("Cursor")]
    [SerializeField] CursorState cursorState;
    [SerializeField] Sprite normalCursor;
    [SerializeField] Sprite interactCursor;

    [Space]
    [Header("CameraRaycast")]
    [SerializeField] Transform cameraTransform;
    [SerializeField] float interactRange;
    //bool startPicking = false;
    Coroutine runningCorutine = null;

    [Header("Interacting")]
    [SerializeField] float defInteractionDuration;
    float currentInteractionDuration;

    PlayerUI playerUI;

    private void Start()
    {
        currentInteractionDuration = defInteractionDuration * GameManager.Instance.pickUpSpeedMultiplier;

        playerUI = GetComponent<PlayerUI>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Interact();
    }

    public void Interact()
    {
        bool isInteractable = false;
        

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObj))
            {
                isInteractable = true;
                IEnumerator corutine = startInteraction(currentInteractionDuration, interactableObj);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    //startPicking = true;
                    runningCorutine = StartCoroutine(corutine);
                    playerUI.updateInteractSlider(currentInteractionDuration, true);

                }
                if (Input.GetKeyUp(KeyCode.F))
                {
                    //startPicking = false;
                    StopCoroutine(runningCorutine);
                    playerUI.updateInteractSlider(currentInteractionDuration, false);
                }

            }
        }
        UpdateCursorState(isInteractable);
    }

    private IEnumerator startInteraction(float duration, IInteractable interaction)
    {
        //if (!startPicking) yield break;

            yield return new WaitForSeconds(duration);
            Debug.Log("Interaction done");
            playerUI.updateInteractSlider(currentInteractionDuration, false);
            interaction.OnInteract();
        
    }

    public void UpdateCursorState(bool isInteracatble)
    {

        if (isInteracatble) cursorState = CursorState.interactable;
        else cursorState = CursorState.not_interactable;

        if (cursorState == CursorState.interactable) playerUI.SetCursorImage(interactCursor, 15);
        else playerUI.SetCursorImage(normalCursor, 5);

    }
}
