using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Sprite[] sprites;
    private Image image;

    private void Start() => image = GameObject.Find("SoundImg").GetComponent<Image>();

    public void ChangeSound()
    {
        AudioListener.volume = AudioListener.volume == 1 ? 0 : 1;

        if (image.sprite == sprites[1]) { image.sprite = sprites[0]; }
        else { image.sprite = sprites[1]; }
    }
}
