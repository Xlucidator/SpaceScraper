using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInteractorTagChanger : MonoBehaviour
{
    public string targetOldTag;
    public string newTag;
    private XRBaseInteractor interactor;
    private bool hasEntered = false;

    private void Awake()
    {
        interactor = GetComponent<XRBaseInteractor>();
        interactor.selectEntered.AddListener(args => hasEntered = true);
        interactor.selectExited.AddListener(OnSelectExited);
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        if (hasEntered && args.interactableObject != null)
        {
            GameObject gameObject = args.interactableObject.transform.gameObject;
            if (gameObject.CompareTag(targetOldTag))
            {
                gameObject.tag = newTag;
                Debug.Log($"Change {gameObject.name}'s tag from '{targetOldTag}' to '{newTag}'");
            }
        }
    }
}
