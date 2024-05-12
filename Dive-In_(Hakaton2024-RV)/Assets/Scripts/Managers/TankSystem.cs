using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSystem : MonoBehaviour
{
    [SerializeField] float tankDuration;
    float maxTankDuration;
    float currentTankState;

    [SerializeField] UIManager UIman;

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
    }
}
