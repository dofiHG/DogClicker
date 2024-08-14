using UnityEngine;
using UnityEngine.UI;
using YG;

public class Advertising : MonoBehaviour
{
    public Button adButton;
    private float advetrisingTimmer = 60f;

    private void Update()
    {
        advetrisingTimmer += Time.deltaTime;
        if (advetrisingTimmer > 60f)
        {
            adButton.gameObject.SetActive(true);
        }
    }

    private void Del()
    {
        if (YandexGame.savesData.bonesPerClick % 2 != 0) { YandexGame.savesData.bonesPerClick += 1; }
        YandexGame.savesData.bonesPerClick /= 2;
    }

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    public void Rewarded(int id)
    {
        YandexGame.savesData.bonesPerClick *= 2;
        adButton.gameObject.SetActive(false);
        advetrisingTimmer = 0;
        Invoke("Del", 60);
    }
}
