using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public int maxHealth = 100;
    public int health;
    private float lerpSpeed = 0.01f;
    public Character character;

    private void Start()
    {
        maxHealth = character.maxHealth;
        health = character.health;
    }
    private void Update()
    {
        health = character.health;
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
    }

}
