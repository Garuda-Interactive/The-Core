using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PLYRUltimatePointBarUI : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPointUltimate(int MaxPointUltimate)
    {
        slider.maxValue = MaxPointUltimate;
    }

    public void SetPointUltimate(int PointUltimate)
    {
        slider.value = PointUltimate;
    }
}