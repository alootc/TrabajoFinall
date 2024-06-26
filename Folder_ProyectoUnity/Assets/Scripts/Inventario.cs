using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public int capacity;
    public string[] items;

    public event Action<string> onAddInventario;
    public event Action<string> onRemoveInventario;
    public event Action<string> onFullInventario;

    private void Start()
    {
        
        items = new string[capacity];
    }

    public void AddInventario(string item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] == "")
            {
                items[i] = item;
                onAddInventario?.Invoke(item);
                return;
            }
        }
        Debug.Log("Inventario lleno");
        onFullInventario?.Invoke(item);

    }

    public void RemoveInventorio(string item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = "";
                onAddInventario?.Invoke(item);
                return;
            }
        }
        Debug.LogWarning("Item no encontrado");
    }

}
