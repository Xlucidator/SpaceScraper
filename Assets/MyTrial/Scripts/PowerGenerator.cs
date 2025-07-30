using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private XRSocketTagInteractor socketInteractor;
    public Animator animator;
    public string animatorPowerBoolName = "powered";

    // Start is called before the first frame update
    void Start()
    {
        socketInteractor.selectEntered.AddListener(args => Supply());
        socketInteractor.selectExited.AddListener(args => Stop());
    }

    public void Supply()
    {
        animator.SetBool(animatorPowerBoolName, true);
        particles.Play();
    }

    public void Stop()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        animator.SetBool(animatorPowerBoolName, false);
    }
}
