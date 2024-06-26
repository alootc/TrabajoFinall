using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string id;
    public string prompt_message;

   public void BaseInteract()
   {

        Interact();
   }

    protected virtual void Interact()
    {

    }

}

public interface Icollectionable
{

    void Grab();
}
