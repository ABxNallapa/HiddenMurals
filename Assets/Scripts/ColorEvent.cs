using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorEvent : MonoBehaviour
{
    public ColorPicker colorPicker;
    [SerializeField] private Button button;
    [SerializeField] private Color color;

    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        colorPicker.changeColor(color);
    }
}
