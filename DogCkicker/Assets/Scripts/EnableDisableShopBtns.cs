using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class EnableDisableShopBtns : MonoBehaviour
{
    private Button button;

    public TMP_Text price;
    public Image image;
    public TMP_Text caption;
    public TMP_Text description;
    public TMP_Text priceInt;

    private void Start() => button = GetComponent<Button>();

    private void Update()
    {
        if (YandexGame.savesData.bonesCount < Convert.ToInt64(priceInt.text))
        {
            button.image.color = new Color32(179, 179, 179, 255);
            image.color = new Color32(179, 179, 179, 255);
            caption.color = new Color32(100, 100, 100, 255);
            price.color = new Color32(118, 105, 0, 255);
            description.color = new Color32(0, 100, 16, 255);
            button.enabled = false;
        }

        else
        {
            button.image.color = new Color32(255, 255, 255, 255);
            image.color = new Color32(255, 255, 255, 255);
            caption.color = new Color32(255, 255, 255, 255);
            price.color = new Color32(255, 225, 0, 255);
            description.color = new Color32(11, 255, 41, 255);
            button.enabled = true;
        }
    }
}
