using UnityEngine;
using YG;

public class Saver : MonoBehaviour
{
    private void Start() => InvokeRepeating("Save", 0, 3);

    private void Save() => YandexGame.SaveProgress();
}
