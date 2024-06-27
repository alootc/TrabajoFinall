using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //
    public static Inventario instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    //


    public int capacity;
    public string[] items;

    public event Action<string> onAddInventario;
    public event Action<string> onRemoveInventario;
    public event Action<string> onFullInventario;

    private void Start()
    {
        
        items = new string[capacity];
    }

    public bool AddInventario(string item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (string.IsNullOrEmpty(items[i]))
            {
                items[i] = item;
                onAddInventario?.Invoke(item);
                return true;
            }
        }
        Debug.Log("Inventario lleno");
        onFullInventario?.Invoke(item);
        return false;
    }

    public void RemoveInventorio(string item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = "";
                onRemoveInventario?.Invoke(item);
                return;
            }
        }
        Debug.LogWarning("Item no encontrado");
    }

}
