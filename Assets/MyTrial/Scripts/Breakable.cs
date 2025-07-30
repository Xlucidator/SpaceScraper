using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakablePieces;
    public float timeToBreak = 2;
    private float timer = 0;
    private XRGrabInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in breakablePieces)
        {
            item.SetActive(false);
            //Debug.Log($"inactive son pieces: {item.name}");
        }
        // Check whether there's any collider registered in parent node
        grabInteractable = GetComponent<XRGrabInteractable>();
        foreach (var col in grabInteractable.colliders)
        {
            Debug.Log($"Registered collider: {col.name}");
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;
        if (timer > timeToBreak)
        {
            // 1. Detach each piece from parent first
            foreach (var piece in breakablePieces)
            {
                piece.transform.parent = null;
            }
            // 2. Unregister parent collider (double check to avoid multiple registration)
            if (grabInteractable) grabInteractable.enabled = false;
            gameObject.SetActive(false);
            // 3. Now activate each pieces
            foreach (var piece in breakablePieces)
            {
                piece.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
