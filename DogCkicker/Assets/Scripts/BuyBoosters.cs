using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

public class BuyBoosters : MonoBehaviour
{
    private ConvertorToNormal convertor;

    private void Start() => convertor = GameObject.Find("ConvertorToNormal").GetComponent<ConvertorToNormal>();

    public void BuyBoosterPerCkick()
    {
        YandexGame.savesData.bonesPerClick += convertor.ReversConvertor(FindValue());
    }

    public void BuyBoosterPerSecond()
    {
        YandexGame.savesData.bonesPerSecond += convertor.ReversConvertor(FindValue());
    }

    private string FindValue()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        string booster = button.transform.Find("DescriptionInt").GetComponent<TMP_Text>().text;
        YandexGame.savesData.bonesCount -= convertor.ReversConvertor(button.transform.Find("PriceInt").GetComponent<TMP_Text>().text);
        return booster;
    }
}
