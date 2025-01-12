using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabCabinet : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Animator anim;
    private bool ClosedOpened = false;
    public GrabCabinet neighbgourCabinet;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        
    }

    public void Grabbed()
    {
        if (!neighbgourCabinet.ClosedOpened)
        {
            ClosedOpened = !ClosedOpened;
            anim.SetBool("Opened", ClosedOpened);
        }
        ForceRelease();
    }

    public void ForceRelease()
    {
        if (grabInteractable.interactorsSelecting.Count > 0) // Check if there is an interactor
        {
            // Get the first interactor
            IXRSelectInteractor interactor = grabInteractable.interactorsSelecting[0];

            // Use the interaction manager to force deselect
            grabInteractable.interactionManager.SelectExit(interactor, grabInteractable);

            Debug.Log($"{gameObject.name} was force released!");
        }
        else
        {
            Debug.Log($"{gameObject.name} is not currently grabbed.");
        }
    }
}