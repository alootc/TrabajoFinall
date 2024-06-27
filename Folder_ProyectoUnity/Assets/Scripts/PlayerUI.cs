using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Text[] texto;
    private Inventario inventario;

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI puntos;

    void Start()
    {
        inventario = GetComponent<Inventario>();
        inventario.onAddInventario += AddInvenarioUI;


        Player3D.onUpdateHealth += UpdateSliderHealth;
        Player3D.onUpdatePoints += UpdateTextPoints;
    }

    private void OnDestroy()
    {
        inventario.onAddInventario -= AddInvenarioUI;


        Player3D.onUpdateHealth -= UpdateSliderHealth;
        Player3D.onUpdatePoints -= UpdateTextPoints;
    }

    private void AddInvenarioUI(string id)
    {
        for (int i = 0; i < texto.Length; i++)
        {
            if (string.IsNullOrEmpty(texto[i].text))
            {
                texto[i].text = id;
                return;
            }
        }
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
