using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLYRHealthBarUI : MonoBehaviour
{
public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
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
        float startValue = slider.value;
        float endTime = startTime + 0.5f; // Adjust the duration of the transition as needed

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / (endTime - startTime);
            slider.value = Mathf.Lerp(startValue, targetHealth, t);
            yield return null;
        }

        slider.value = targetHealth;
        smoothTransitionCoroutine = null;
    }
}
