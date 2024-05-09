using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ENMYHealthBarUI : MonoBehaviour
{
    public Slider healthSlider;

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    private Coroutine smoothTransitionCoroutine;

    public void SetHealth(int health)
    {
        if (smoothTransitionCoroutine != null)
        {
            StopCoroutine(smoothTransitionCoroutine);
        }

        smoothTransitionCoroutine = StartCoroutine(SmoothTransition(health));
    }

    private IEnumerator SmoothTransition(int targetHealth)
    {
        float startTime = Time.time;
        float startValue = healthSlider.value;
        float endTime = startTime + 0.5f;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / (endTime - startTime);
            healthSlider.value = Mathf.Lerp(startValue, targetHealth, t);
            yield return null;
        }

        healthSlider.value = targetHealth;
        smoothTransitionCoroutine = null;
    }
}