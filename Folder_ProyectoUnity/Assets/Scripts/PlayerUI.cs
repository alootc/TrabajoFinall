using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text[] texto;
    private Inventario inventario;

    void Start()
    {
        inventario = GetComponent<Inventario>();

        inventario.onAddInventario += AddInvenarioUI;
    }

    private void OnDestroy()
    {
        inventario.onAddInventario -= AddInvenarioUI;
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
}
