using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public ColorPicker colorPicker;
    public StrokeWidthPicker strokeWidthPicker;
    private int order = 0;

    Line activeLine;

    [SerializeField] public float _leftBoundary;
    [SerializeField] public float _bottomBoundary;
    [SerializeField] public float _rightBoundary;
    [SerializeField] public float _topBoundary;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            newLine.GetComponent<Renderer>().material.color = colorPicker.color;
            newLine.GetComponent<LineRenderer>().startWidth = strokeWidthPicker.width;
            newLine.GetComponent<LineRenderer>().sortingOrder = order;
            order++;
            activeLine = newLine.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (Input.mousePosition.x >= _leftBoundary && Input.mousePosition.y >= _bottomBoundary
                && Input.mousePosition.x <= Screen.width - _rightBoundary && Input.mousePosition.y <= Screen.height - _topBoundary)
            {
                activeLine.UpdateLine(mousePos);
            }
        }
    }
}
