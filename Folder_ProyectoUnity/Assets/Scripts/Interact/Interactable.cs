using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //public string id;
    public string mensaje;

   public void BaseInteract()
   {

        Interact();
   }

    protected virtual void Interact()
    {

    }

}

public class Collectionable : Interactable
{
    public string id; 

   public void Grab()
   {
        Inventario.instance.AddInventario(id);
   }

    protected override void Interact()
    {
        
    }
}
