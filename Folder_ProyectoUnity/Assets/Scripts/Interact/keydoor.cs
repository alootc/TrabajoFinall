using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keydoor : Interactable, Icollectionable
{
   protected override void Interact()
   {
        
        Destroy(gameObject);
   }

    public void Grab()
    {

    }
}
