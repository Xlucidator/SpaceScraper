using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyzable : MonoBehaviour
{
    [ColorUsage(true, true)] public Color formerColor, latterColor;
    public string targetTag;
    public float timeToAnalyze = 2;

    private float analyzeProgress = 0;
    private bool isAnalyzed = false;
    private Material objectMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Renderer objectRenderer = GetComponent<Renderer>();
        objectMaterial = objectRenderer.material;
        if (formerColor == null) formerColor = objectMaterial.GetColor("_EmissionColor");
    }

    public void Analyze()
    {
        if (!isAnalyzed)
        {
            analyzeProgress += Time.deltaTime / timeToAnalyze;
            if (analyzeProgress > 1)
            {
                analyzeProgress = 1;
                isAnalyzed = true;
            }
            Color lerpedColor = Color.Lerp(formerColor, latterColor, analyzeProgress);
            objectMaterial.SetColor("_EmissionColor", lerpedColor);
            //Debug.Log($"Analyze: Progress = {analyzeProgress}, color = {objectMaterial.GetColor("_EmissionColor")}");
        }
    }

    public void Mutate()
    {
        if (isAnalyzed)
        {
            gameObject.tag = targetTag;
            Debug.Log($"{gameObject.name} mutate to {gameObject.tag}");
        }
    }

    public bool HasBeenAnalyzed()
    {
        return isAnalyzed;
    }
}
