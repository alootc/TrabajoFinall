using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomMaterial", menuName = "Materials/CustomMaterial")]
public class Material : ScriptableObject
{
    private Material ballMaterial;
    public Color[] emissionColors;
    public float metallic;
    public float smoothness;


    //public void ChangeEmissionColor(MaterialChange typeChange)
    //{
    //    switch(typeChange)
    //    {
    //        case MaterialChange.OnLaunch:
    //        ballMaterial.SetColor("_emissionColor", emissionColors[0]);
    //        break;
    //    }
    //}
}
