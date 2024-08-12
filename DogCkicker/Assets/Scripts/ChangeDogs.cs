using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ChangeDogs : MonoBehaviour
{
    private Image currentImage;

    public Sprite[] mainImages;
    public List<long> scoresToNextLvL;
    public TMP_Text currentLvL;

    private void Start()
    {
        currentLvL.text = (YandexGame.savesData.CurrentLevel + 1).ToString();
        currentImage = GameObject.Find("MainImage").GetComponent<Image>();
    }

    private void Update()
    {
        if (YandexGame.savesData.bonesCount >= scoresToNextLvL[YandexGame.savesData.CurrentLevel])
        {
            YandexGame.savesData.CurrentLevel += 1;
            currentLvL.text = (YandexGame.savesData.CurrentLevel + 1).ToString();
            currentImage.sprite = mainImages[YandexGame.savesData.CurrentLevel];
        }
    }
}
