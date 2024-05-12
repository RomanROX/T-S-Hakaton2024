using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    [Space]
    [SerializeField] Button upgradeGloves;
    [SerializeField] Button upgradeMask;
    [SerializeField] Button upgradeTank;
    [SerializeField] Button upgradeFins;

    [Header("Start Price")]
    [SerializeField] int glovePrice;
    [SerializeField] int maskPrice;
    [SerializeField] int TankePrice;
    [SerializeField] int FinsPrice;

    public AudioClip buySound;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "COINS: " + GameManager.Instance.coins.ToString();
        UpdatePrices();
    }

    public void UpdatePrices()
    {
        upgradeGloves.transform.GetChild(0).GetComponent<TMP_Text>().text = Mathf.Pow(glovePrice, GameManager.Instance.u_Rukavice).ToString();
        upgradeMask.transform.GetChild(0).GetComponent<TMP_Text>().text = Mathf.Pow(glovePrice, GameManager.Instance.u_Naocale).ToString();
        upgradeTank.transform.GetChild(0).GetComponent<TMP_Text>().text = Mathf.Pow(glovePrice, GameManager.Instance.u_Spremnik).ToString();
        upgradeFins.transform.GetChild(0).GetComponent<TMP_Text>().text = Mathf.Pow(glovePrice, GameManager.Instance.u_Peraje).ToString();
    }

    public void BuyGloveUpgrade()
    {
        if(GameManager.Instance.coins >= Mathf.Pow(glovePrice, GameManager.Instance.u_Rukavice))
        {
            Debug.Log("Bought glove upgrade");
            GameManager.Instance.coins -= (int)Mathf.Pow(glovePrice, GameManager.Instance.u_Rukavice);
            GameManager.Instance.u_Rukavice++;
            audio.PlayOneShot(buySound);
        }
    }
    public void BuyMaskUpgrade()
    {
        if (GameManager.Instance.coins >= Mathf.Pow(maskPrice, GameManager.Instance.u_Naocale))
        {
            Debug.Log("Bought mask upgrade");
            GameManager.Instance.coins -= (int)Mathf.Pow(maskPrice, GameManager.Instance.u_Naocale);
            GameManager.Instance.u_Naocale++;
            audio.PlayOneShot(buySound);

        }
    }
    public void BuyTankUpgrade()
    {
        if (GameManager.Instance.coins >= Mathf.Pow(TankePrice, GameManager.Instance.u_Spremnik))
        {
            Debug.Log("Bough tank upgrade");
            GameManager.Instance.coins -= (int)Mathf.Pow(TankePrice, GameManager.Instance.u_Spremnik);
            GameManager.Instance.u_Spremnik++;
            audio.PlayOneShot(buySound);

        }
    }
    public void BuyFinsUpgrade()
    {
        if (GameManager.Instance.coins >= Mathf.Pow(FinsPrice, GameManager.Instance.u_Peraje))
        {
            Debug.Log("Bough Fins upgrade");
            GameManager.Instance.coins -= (int)Mathf.Pow(FinsPrice, GameManager.Instance.u_Peraje);
            GameManager.Instance.u_Peraje++;
            audio.PlayOneShot(buySound);

        }
    }
}
