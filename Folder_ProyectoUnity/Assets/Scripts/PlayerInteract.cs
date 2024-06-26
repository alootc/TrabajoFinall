using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public float distance = 1.5f;
    public LayerMask mask;

    //private StarterAssetsInputs input;

    private Camera cam;
    private Interactable interactable = null;

    //private bool is_interact;

    public Text text_message;

    private Inventario inventario;

    void Start()
    {
        //input = GetComponent<StarterAssetsInputs>();
        cam = Camera.main;
        inventario = GetComponent<Inventario>();
    }

    private void OnEnable()
    {
        StarterAssetsInputs.onInteract += Interact;
    }

    private void OnDestroy()
    {
        StarterAssetsInputs.onInteract -= Interact;
    }

    void Update()
    {
        text_message.text = string.Empty;
        interactable = null;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        if (Physics.Raycast(ray, out RaycastHit  hit, distance, mask)) //hitInf
        {
            if (hit.collider.TryGetComponent(out Interactable o))
            {
                text_message.text = o.prompt_message;
                interactable = o;
            }
            //Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            //if(interactable != null)
            //{
            //    text_message.text = interactable.prompt_message;

            //    if (input.interact && !is_interact)
            //    {
            //        is_interact = true;
            //        interactable.BaseInteract();

            //    }
            //}
            
        }
        //if(!input.interact) is_interact = false;

    }
    private void Interact()
    {
        if (!interactable) return;
        interactable.BaseInteract();

        if (interactable.TryGetComponent(out Icollectionable collection))
        {
            inventario.AddInventario(interactable.id);
        }
    }
}
