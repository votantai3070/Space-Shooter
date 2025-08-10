using System.Collections;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float blinkDuration = 0.5f;
    public float blinkInterval = 0.1f;
    public static BlinkEffect instance;
    [HideInInspector] public bool isBlinking = false;

    private void Awake()
    {
        instance = this;
    }

    public void StartBlinkEffect()
    {
        if (!isBlinking)
            StartCoroutine(BlinkPlayerEffect());
    }

    private IEnumerator BlinkPlayerEffect()
    {
        isBlinking = true;
        float timer = 0f;

        while (timer < blinkDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSecondsRealtime(blinkInterval);
            timer += blinkInterval;
        }

        spriteRenderer.enabled = true;
        isBlinking = false;
    }
}
