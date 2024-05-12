using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BankruptScene : MonoBehaviour
{
    public float delay;
    public string SceneName;
    private void Start()
    {
        StartCoroutine(GoToNextScene());
    }

    public IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
    }
}
