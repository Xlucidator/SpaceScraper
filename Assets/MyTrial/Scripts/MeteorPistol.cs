using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;

    private bool rayActivate = false;
    public LayerMask raycastMask;
    public Transform shootSource;
    public float affectDistance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(args => StartShooting());
        grabInteractable.deactivated.AddListener(args => StopShooting());
        grabInteractable.selectExited.AddListener(args => StopShooting()); // To avoid the situation that we ungrab the gun before deactivate it!
    }

    public void StartShooting()
    {
        particles.Play();
        AudioManager.instance.Play("Pistol");
        rayActivate = true;
    }

    public void StopShooting()
    {
        rayActivate = false;
        AudioManager.instance.Stop("Pistol");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    // Update is called once per frame
    void Update()
    {
        if (rayActivate) RaycastCheck();
    }

    public void RaycastCheck()
    {
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out RaycastHit hit, affectDistance, raycastMask);
        if (hasHit)
        {
            hit.transform.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
