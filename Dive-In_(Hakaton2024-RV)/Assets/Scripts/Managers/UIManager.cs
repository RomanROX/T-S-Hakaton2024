using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Boat Distance")]
    [SerializeField] GameObject boatObject;
    [SerializeField] GameObject playerObject;
    [Space]
    [SerializeField] TMP_Text distanceText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoatDistance();
    }

    public void BoatDistance()
    {
        int distance = (int)Vector3.Distance(boatObject.transform.position, playerObject.transform.position);
        distanceText.text = distance.ToString() + "m";
    }
}
