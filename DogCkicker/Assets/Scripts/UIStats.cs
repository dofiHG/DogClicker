using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UIStats : MonoBehaviour
{
    public TMP_Text bonesPerCkick;
    public TMP_Text bonesPerSecond;
    public TMP_Text currentBones;
    public Slider levelSlider;

    private void Update()
    {
        bonesPerCkick.text = YandexGame.savesData.bonesPerClick.ToString();
        bonesPerSecond.text = YandexGame.savesData.bonesPerClick.ToString();    
        currentBones.text = YandexGame.savesData.bonesCount.ToString();

        levelSlider.maxValue = GameObject.Find("ChangeDogs").GetComponent<ChangeDogs>().scoresToNextLvL[YandexGame.savesData.CurrentLevel];
        try { levelSlider.minValue = GameObject.Find("ChangeDogs").GetComponent<ChangeDogs>().scoresToNextLvL[YandexGame.savesData.CurrentLevel - 1]; }
        catch { levelSlider.minValue = 0; }
        levelSlider.value = YandexGame.savesData.bonesCount;

    }
}
