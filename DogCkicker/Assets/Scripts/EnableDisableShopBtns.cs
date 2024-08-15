using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class EnableDisableShopBtns : MonoBehaviour
{
    private Button button;
    private ConvertorToNormal convertor;

    public TMP_Text price;
    public Image image;
    public TMP_Text caption;
    public TMP_Text description;
    public TMP_Text priceInt;
    public TMP_Text descriptionInt;

    private void Start()
    {
        button = GetComponent<Button>();
        convertor = GameObject.Find("ConvertorToNormal").GetComponent<ConvertorToNormal>();
    }

    private void Update()
    {
        if (YandexGame.savesData.bonesCount < convertor.ReversConvertor(priceInt.text))
        {
            button.image.color = new Color32(179, 179, 179, 255);
            image.color = new Color32(179, 179, 179, 255);
            caption.color = new Color32(100, 100, 100, 255);
            price.color = new Color32(118, 105, 0, 255);
            description.color = new Color32(0, 100, 16, 255);
            priceInt.color = new Color32(118, 105, 0, 255);
            descriptionInt.color = new Color32(0, 100, 16, 255);
            button.enabled = false;
        }

        else
        {
            button.image.color = new Color32(255, 255, 255, 255);
            image.color = new Color32(255, 255, 255, 255);
            caption.color = new Color32(255, 255, 255, 255);
            price.color = new Color32(255, 225, 0, 255);
            priceInt.color = new Color32(255, 225, 0, 255);
            descriptionInt.color = new Color32(11, 255, 41, 255);
            description.color = new Color32(11, 255, 41, 255);
            button.enabled = true;
        }
    }
}
