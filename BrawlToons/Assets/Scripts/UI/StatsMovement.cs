using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMovement : MonoBehaviour
{
    public float amplitude = 10f; // La distancia máxima de oscilación
    public float frequency = 2f;  // La velocidad de oscilación

    private RectTransform rectTransform;
    private Vector3 startPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        rectTransform.anchoredPosition = new Vector2(startPos.x, startPos.y + offset);
    }
}
