using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keydoor : Collectionable
{
   protected override void Interact()
   {
        
        Destroy(gameObject);
   }

}
