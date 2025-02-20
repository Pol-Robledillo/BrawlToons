using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{

    public IEnumerator Phase1()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color initialColor = renderer.material.color;
        Color targetColor = new Color(197f / 255f, 87f / 255f, 245f / 255f);
        float duration = 1f; 
        float timeElapsed = 0f;

        // Cambiar el color progresivamente
        while (timeElapsed < duration)
        {
            renderer.material.color = Color.Lerp(initialColor, targetColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null; 
        }

        renderer.material.color = targetColor;
    }

    public void ReturnToInitialColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color initialColor = new Color(88f / 255f, 15f / 255f, 120f / 255f); 
        renderer.material.color = initialColor; 
    }

    public IEnumerator Phase2()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color initialColor = renderer.material.color;
        Color targetColor = new Color(230f / 255f, 130f / 255f, 255f / 255f); 
        float duration = 1f; 
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            renderer.material.color = Color.Lerp(initialColor, targetColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null; 
        }

        renderer.material.color = targetColor;

        renderer.material.SetColor("_EmissionColor", targetColor * 2f); 
        DynamicGI.SetEmissive(renderer, targetColor * 2f); 
    }
}
