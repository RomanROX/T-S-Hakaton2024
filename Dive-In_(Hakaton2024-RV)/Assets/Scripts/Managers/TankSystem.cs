using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TankSystem : MonoBehaviour
{
    [SerializeField] float tankDuration;
    float maxTankDuration;
    float currentTankState;

    [SerializeField] UIManager UIman;
    [Header("Death")]
    [SerializeField] float deathDuration;
    [SerializeField] string SceneName;
    [SerializeField] GameObject deathCanvas;
    [Space]
    [SerializeField] GameObject playerCanvas;
    [SerializeField] GameObject ExpeditionCanvas;
    [SerializeField] GameObject player;
    [Space]
    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile deathVolumeProfile;


    // Start is called before the first frame update
    void Start()
    {
        maxTankDuration = tankDuration * GameManager.Instance.tankSizeMultiplier;
        currentTankState = maxTankDuration;
        Debug.Log(currentTankState);
    }

    // Update is called once per frame
    void Update()
    {
        TankUsage();
    }

    public void TankUsage()
    {

        if (currentTankState > 0)
        {
            currentTankState -= Time.deltaTime;
            UIman.TankStatus(currentTankState, maxTankDuration);
        }
        else OnDeath();

    }

    public void OnDeath()
    {
        Debug.Log("DEAD");

        player.GetComponent<PlayerMovement>().enabled = false;

        volume.profile = deathVolumeProfile;

        playerCanvas.SetActive(false);
        ExpeditionCanvas.SetActive(false);

        deathCanvas.SetActive(true);

        GameManager.Instance.trashCollected = 0;

        StartCoroutine(respawn());
    }

    public IEnumerator respawn()
    {
        yield return new WaitForSeconds(deathDuration);
        SceneManager.LoadScene(SceneName);
    }
}
