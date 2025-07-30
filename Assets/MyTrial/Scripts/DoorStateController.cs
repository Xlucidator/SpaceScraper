using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorStateController : MonoBehaviour
{
    public Animator animator;
    public string boolName = "open";

    // Start is called before the first frame update
    void Start()
    {
        var interactor = GetComponent<XRSimpleInteractable>();
        interactor.selectEntered.AddListener(args => ToggleDoorOpen());
    }

    public void ToggleDoorOpen()
    {
        bool isOpen = animator.GetBool(boolName);
        animator.SetBool(boolName, !isOpen);
    }
}
