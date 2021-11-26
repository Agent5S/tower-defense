using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchTimer : MonoBehaviour
{
    public TextMeshProUGUI timerLabel;
    public int matchDuration;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Tick", 1, 1);
    }

    void Tick()
    {
        this.matchDuration -= 1;

        if (matchDuration >= 0)
        {
            //TODO: End match
        }

        //Cheap formatting because I'm sleepy
        var seconds = 0;
        var minutes = System.Math.DivRem(matchDuration, 60, out seconds);
        var secondsString = seconds < 10 ? $"0{seconds}" : $"{seconds}";
        timerLabel.text = $"{minutes}:{secondsString}";
    }
}
