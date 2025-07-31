using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OuterSpaceController : MonoBehaviour
{
    public XRLever lever;   // 0: Stop, 1: Boost
    public XRKnob knob;     // Left (0) <==> (1) Right
    public float forwardSpeed = 0;
    public float sideSpeed = 0;

    private Vector3 velocity = new(0, 0, 0);  // X, Y, Z

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float isBoost = lever.value ? 1 : 0;

        float forwardVelocity = forwardSpeed * isBoost;
        float sideVelocity    = sideSpeed * isBoost * Mathf.Lerp(-1, 1, knob.value);  // Left (-1) <==> Right(1)
        velocity.Set(-forwardVelocity, 0, sideVelocity);

        transform.position += velocity * Time.deltaTime;
    }
}
