using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class AddBonesAnyWay : MonoBehaviour
{
    public TMP_Text bonesCount;
    public TMP_Text bonesPerClick;
    public TMP_Text bonesPerSecond;
    public GameObject textPrefab;

    private void Start()
    {
        YandexGame.savesData.bonesPerClick = 1;
        YandexGame.savesData.bonesPerSecond = 1;
        InvokeRepeating("PlusBonePerSecond", 0, 1);
    }

    private void Update()
    {
        bonesCount.text = YandexGame.savesData.bonesCount.ToString();
        bonesPerClick.text = YandexGame.savesData.bonesPerClick.ToString();
        bonesPerSecond.text = YandexGame.savesData.bonesPerSecond.ToString();
    }

    public void ClickToImage()
    {
        YandexGame.savesData.bonesCount += YandexGame.savesData.bonesPerClick;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = Input.mousePosition;
        RectTransform canvasRectTransform = GameObject.Find("UI").GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, mousePos, null, out Vector2 localPoint);
        GameObject spawnedText = Instantiate(textPrefab, localPoint, Quaternion.identity, GameObject.Find("UI").transform);
        RectTransform rectTransform = spawnedText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = localPoint;
        Destroy(spawnedText, 1.2f);
    }

    private void PlusBonePerSecond() => YandexGame.savesData.bonesCount += YandexGame.savesData.bonesPerSecond;
}
