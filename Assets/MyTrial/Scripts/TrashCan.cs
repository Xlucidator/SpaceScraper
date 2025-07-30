using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TriggerZone>().onEnterEvent.AddListener(InsideTrash);
    }

    public void InsideTrash(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}