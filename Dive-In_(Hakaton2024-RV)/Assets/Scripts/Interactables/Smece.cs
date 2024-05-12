using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smece : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        PickUp();
    }

    //[SerializeField] public GameObject bubbleVFX;
    [SerializeField] AudioClip trashPickup;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void PickUp()
    {
        GameManager.Instance.trashCollected++;
        audioSource.PlayOneShot(trashPickup);

        Debug.Log("!TRASH PICKED UP!");
        Destroy(gameObject);
    }
}
