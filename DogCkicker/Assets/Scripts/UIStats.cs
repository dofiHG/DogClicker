using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UIStats : MonoBehaviour
{
    public GameObject boneImg;
    public TMP_Text bonesPerCkick;
    public TMP_Text bonesPerSecond;
    public TMP_Text currentBones;
    public Slider levelSlider;

    public TMP_Text[] textsToConvert;

    private ConvertorToNormal convertor;
    private void Start()
    {
        convertor = GameObject.Find("ConvertorToNormal").GetComponent<ConvertorToNormal>();
        foreach (TMP_Text text in textsToConvert) { text.text = convertor.Convertor(text.text); }
    }

    private void Update()
    {
        UIMath();
        PaddingBone();
    }

    private void UIMath()
    {
        bonesPerCkick.text = convertor.Convertor(YandexGame.savesData.bonesPerClick);
        bonesPerSecond.text = convertor.Convertor(YandexGame.savesData.bonesPerSecond);
        currentBones.text = convertor.Convertor(YandexGame.savesData.bonesCount);
        
        levelSlider.maxValue = GameObject.Find("ChangeDogs").GetComponent<ChangeDogs>().scoresToNextLvL[YandexGame.savesData.CurrentLevel];
        try { levelSlider.minValue = GameObject.Find("ChangeDogs").GetComponent<ChangeDogs>().scoresToNextLvL[YandexGame.savesData.CurrentLevel - 1]; }
        catch { levelSlider.minValue = 0; }
        levelSlider.value = Convert.ToInt64(YandexGame.savesData.bonesCount);
    }
        
    private void PaddingBone()
    {
        float textSize = Mathf.Min(427, currentBones.preferredWidth);
        RectTransform textRect = currentBones.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(textSize, textRect.sizeDelta.y);
        if (currentBones.text.Length == 1) { boneImg.transform.localPosition = new Vector2(currentBones.transform.localPosition.x + textSize + 70, currentBones.transform.localPosition.y); }
        else { boneImg.transform.localPosition = new Vector2(currentBones.transform.localPosition.x + textSize/2 + 70, currentBones.transform.localPosition.y); }
    }
}
