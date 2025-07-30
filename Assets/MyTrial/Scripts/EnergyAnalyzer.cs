using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnergyAnalyzer : MonoBehaviour
{
    private Analyzable workingObject;
    private Coroutine analyzeCoroutine = null;

    [SerializeField] private XRSocketTagInteractor socketInteractor;

    // Start is called before the first frame update
    void Start()
    {
        socketInteractor.selectEntered.AddListener(StartAnalyzing);
        socketInteractor.selectExited.AddListener(args => StopAnalyzing());
    }

    public void StartAnalyzing(SelectEnterEventArgs args)
    {
        workingObject = args.interactableObject.transform.GetComponent<Analyzable>();
        if (workingObject)
        {
            Debug.Log($"Start Coroutine, working to {workingObject.name}");
            analyzeCoroutine = StartCoroutine(AnalyzeCoroutine(workingObject));
        }
    }

    public void StopAnalyzing()
    {
        if (analyzeCoroutine != null)
        {
            StopCoroutine(analyzeCoroutine);
            Debug.Log("Coroutine stopped.");
        }
        workingObject.Mutate();
    }

    // Use Coroutine instead of Update function
    IEnumerator AnalyzeCoroutine(Analyzable objects)
    {
        while (!objects.HasBeenAnalyzed())
        {
            objects.Analyze();
            yield return null;
        }
        analyzeCoroutine = null;
    }
}
