using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerLabel;
    public Button button;
    public int cooldownTime;

    private int remainingTime = 0;

    public void StartTicking()
    {
        this.remainingTime = cooldownTime;
        InvokeRepeating("Tick", 1, 1);
        button.interactable = false;
    }

    void Tick()
    {
        this.remainingTime -= 1;
        this.remainingTime = System.Math.Max(0, remainingTime);
        this.timerLabel.text = $"{remainingTime}";

        if (remainingTime == 0) {
            CancelInvoke();
            button.interactable = true;
        }
    }
}
