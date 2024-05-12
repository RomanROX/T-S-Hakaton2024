using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndExpedition : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        FinishExpedition();
    }

    [SerializeField] float transitionDuration;
    [SerializeField] string sceneName;

    public void FinishExpedition()
    {
        StartCoroutine(GoToSurface());
    }

    public IEnumerator GoToSurface()
    {
        yield return new WaitForSeconds(transitionDuration);
        GameManager.Instance.coins += GameManager.Instance.trashCollected;
        GameManager.Instance.trashCollected = 0;
        SceneManager.LoadScene(sceneName);
    }
    
}
