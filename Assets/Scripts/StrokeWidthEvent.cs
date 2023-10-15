using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeWidthEvent : MonoBehaviour
{
    public StrokeWidthPicker picker;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(OnSlide);
    }

    void OnSlide(float value)
    {
        picker.width = value;
    }
}
