using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Boat Distance")]
    [SerializeField] GameObject boatObject;
    [SerializeField] GameObject playerObject;
    [Space]
    [SerializeField] TMP_Text distanceText;


    [Header("Tank")]
    [SerializeField] TMP_Text tankTimer;
    [SerializeField] Slider tankSlider;
    [SerializeField] Image tankFillImage;
    [SerializeField] Color fullColor;
    [SerializeField] Color lowColor;

    float sliderValue;

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

    public void TankStatus(float currentTankState, float maxTankCapacity)
    {
        tankTimer.text = ((int)currentTankState).ToString() + "s";

        sliderValue = Mathf.Clamp01(currentTankState / maxTankCapacity);
        tankSlider.value = sliderValue;
        tankFillImage.color = Color.Lerp(lowColor, fullColor, sliderValue);
    }
}
