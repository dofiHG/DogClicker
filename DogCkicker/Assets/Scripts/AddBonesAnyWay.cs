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


    public int tempPerCkick;
    public int tempPerSec;


    private void Start()
    {
        InvokeRepeating("PlusBonePerSecond", 0, 1);
    }

    private void Update()
    {
        bonesCount.text = YandexGame.savesData.bonesCount.ToString();
        bonesPerClick.text = YandexGame.savesData.bonesPerClick.ToString();
        bonesPerSecond.text = YandexGame.savesData.bonesPerSecond.ToString();
        YandexGame.savesData.bonesPerClick = tempPerCkick;
        YandexGame.savesData.bonesPerSecond = tempPerSec;
    }

    public void ClickToImage()
    {
        YandexGame.savesData.bonesCount += YandexGame.savesData.bonesPerClick;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = Input.mousePosition;
        RectTransform canvasRectTransform = GameObject.Find("UI").GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, mousePos, null, out Vector2 localPoint);
        GameObject spawnedText = Instantiate(textPrefab, localPoint, Quaternion.identity, GameObject.Find("UI").transform);
        spawnedText.GetComponent<TMP_Text>().text = YandexGame.savesData.bonesPerClick.ToString();
        RectTransform rectTransform = spawnedText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = localPoint;
        Destroy(spawnedText, 1.2f);
    }

    private void PlusBonePerSecond() => YandexGame.savesData.bonesCount += YandexGame.savesData.bonesPerSecond;
}
