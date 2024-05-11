using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Cursor")]
    [SerializeField] Image cursorImage;
    [SerializeField] Slider interactSlider;
    bool fillSlider;
    float duration = 0f;
    float sliderValue = 0f;
    float timer = 0f;

    [Header("Coins")]
    [SerializeField] TMP_Text coinText;


    void Start()
    {
        interactSlider.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "COINS: " + GameManager.Instance.coins;
        SliderUpdate();
    }

    public void SetCursorImage(Sprite sprite, float uISize)
    {
        cursorImage.sprite = sprite;
        cursorImage.rectTransform.sizeDelta = new Vector2 (uISize, uISize);
    }

    public void updateInteractSlider(float interactDuration, bool isInteracting)
    {
        if (isInteracting)
        {
            interactSlider.gameObject.SetActive(true);
            duration = interactDuration;
            fillSlider = true;
        }
        else
        {
            interactSlider.gameObject.SetActive(false);
            duration = 0;
            fillSlider = false;
        }

    }

    public void SliderUpdate()
    {
        if(fillSlider)
        {
            timer += Time.deltaTime;
            sliderValue = Mathf.Clamp01(timer/duration);
        }
        else
        {
            sliderValue = 0f;
            timer = 0f;
        }

        interactSlider.value = sliderValue;
    }
}
