using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBar : MonoBehaviour
{

    public Slider slide;

    public Gradient gradient;

    public Image fill;

    public void SetValue(float value)
    { 
        slide.value = value;

        fill.color = gradient.Evaluate(slide.normalizedValue);
    }

    public void SetMaxValue(float value)
    {
        slide.maxValue = value;
        slide.value = value;

        fill.color = gradient.Evaluate(1f);
    }
}
