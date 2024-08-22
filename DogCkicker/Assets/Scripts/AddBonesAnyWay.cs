using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class AddBonesAnyWay : MonoBehaviour
{
    public GameObject textPrefab;
    public GameObject mainImage;

    private ConvertorToNormal convertor;

    private void Start()
    {
        InvokeRepeating("PlusBonePerSecond", 0, 1);
        convertor = GameObject.Find("ConvertorToNormal").GetComponent<ConvertorToNormal>();
        if (YandexGame.savesData.bonesPerClick == 0) { YandexGame.savesData.bonesPerClick = 1; }
    }

    public void ClickToImage()
    {
        mainImage.GetComponent<Animator>().Play("ImageIdle", -1, 0.3f);
        YandexGame.savesData.bonesCount += YandexGame.savesData.bonesPerClick;
        Vector2 mousePos = Input.mousePosition;
        RectTransform canvasRectTransform = GameObject.Find("UI").GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, mousePos, null, out Vector2 localPoint);
        GameObject spawnedText = Instantiate(textPrefab, localPoint, Quaternion.identity, GameObject.Find("UI").transform);
        spawnedText.GetComponent<TMP_Text>().text = $"+{convertor.Convertor(YandexGame.savesData.bonesPerClick)}";
        RectTransform rectTransform = spawnedText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = localPoint;
        Destroy(spawnedText, 1.2f);
    }

    private void PlusBonePerSecond() => YandexGame.savesData.bonesCount += YandexGame.savesData.bonesPerSecond;
}
