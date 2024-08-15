using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class AddBonesAnyWay : MonoBehaviour
{
    public GameObject textPrefab;

    public int tempPerCkick;
    public int tempPerSec;

    private ConvertorToNormal convertor;

    private void Start()
    {
        InvokeRepeating("PlusBonePerSecond", 0, 1);
        convertor = GameObject.Find("ConvertorToNormal").GetComponent<ConvertorToNormal>();
    }


    public void ClickToImage()
    {
        YandexGame.savesData.bonesCount += YandexGame.savesData.bonesPerClick;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = Input.mousePosition;
        RectTransform canvasRectTransform = GameObject.Find("UI").GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, mousePos, null, out Vector2 localPoint);
        GameObject spawnedText = Instantiate(textPrefab, localPoint, Quaternion.identity, GameObject.Find("UI").transform);
        spawnedText.GetComponent<TMP_Text>().text = convertor.Convertor(YandexGame.savesData.bonesPerClick);
        RectTransform rectTransform = spawnedText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = localPoint;
        Destroy(spawnedText, 1.2f);
    }

    private void PlusBonePerSecond() => YandexGame.savesData.bonesCount += YandexGame.savesData.bonesPerSecond;
}
