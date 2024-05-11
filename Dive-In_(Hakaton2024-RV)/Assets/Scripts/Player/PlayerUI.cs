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

    [Header("Coins")]
    [SerializeField] TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        interactSlider.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "COINS: " + GameManager.Instance.coins;
    }

    public void SetCursorImage(Sprite sprite, float uISize)
    {
        cursorImage.sprite = sprite;
        cursorImage.rectTransform.sizeDelta = new Vector2 (uISize, uISize);
    }
}
