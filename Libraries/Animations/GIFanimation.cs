using FirUnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GIFanimation : MonoBehaviour
{
    [SerializeField, NullCheck]
    private Image image;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private float framePerSecond = 60f;
    [SerializeField]
    private float vanishingRate = 5f;

    private bool isAnimationEnabled = false;
    private float timer;
    private float frameIndex = 0;

    public void OnEnable()
    {
        timer = 0;
        isAnimationEnabled = true;

        image.canvasRenderer.SetAlpha(alpha: 0f);
        image.CrossFadeAlpha(alpha: 1f, vanishingRate, ignoreTimeScale: false);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 / framePerSecond)
        {
            timer -= 1 / framePerSecond;
            frameIndex++;
            frameIndex = frameIndex % sprites.Length;
        }

        image.sprite = sprites[(int)frameIndex];

        if (!isAnimationEnabled)
        {
            image.canvasRenderer.SetAlpha(alpha: 1f);
            image.CrossFadeAlpha(alpha: 0f, vanishingRate, ignoreTimeScale: false);
            enabled = false;
        }
    }

    public void SetGIF(Sprite[] sprites)
    {
        this.sprites = sprites;
    }

    public void StopAmim()
    {
        isAnimationEnabled = false;
    }
}