using UnityEngine;
using UnityEngine.UI;
using YG;

public class ChangeDogs : MonoBehaviour
{
    private Sprite currentImage;

    public Sprite[] mainImages;
    public int[] scoresToNextLvL;

    private void Start() => currentImage = GameObject.Find("MainImage").GetComponent<Image>().sprite;

    private void Update()
    {
        if (YandexGame.savesData.bonesCount >= scoresToNextLvL[YandexGame.savesData.CurrentLevel])
        {
            YandexGame.savesData.CurrentLevel += 1;
            currentImage = mainImages[YandexGame.savesData.CurrentLevel];
        }
    }
}
