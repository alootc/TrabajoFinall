using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Vida : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI puntos;

    //private SpriteRenderer sprite;

    void Start()
    {
       // sprite = GetComponent<SpriteRenderer>();

        Player3D.onUpdateHealth += UpdateSliderHealth;
        Player3D.onUpdatePoints += UpdateTextPoints;
    }

    private void OnDestroy()
    {
        Player3D.onUpdateHealth -= UpdateSliderHealth;
        Player3D.onUpdatePoints -= UpdateTextPoints;

    }
    
    
    void Update()
    {
        
    }
    private void UpdateSliderHealth(float value)
    {
        slider.value = value;
    }

    private void UpdateTextPoints(int points)
    {
        puntos.text = $"Puntos; {points}";
    }
}
