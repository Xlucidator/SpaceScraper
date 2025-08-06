using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


[System.Serializable] 
public class Step
{
    public string name;
    public float time;
    public bool hasPlayed = false;
}

public class PlaySteps : MonoBehaviour
{
    private PlayableDirector director;
    public List<Step> steps;

    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void PlayStepIndex(int index)
    {
        Step step = steps[index];
        if (!step.hasPlayed)
        {
            director.Stop();
            director.time = step.time;
            director.Play();

            step.hasPlayed = true;
        }
    }
}
