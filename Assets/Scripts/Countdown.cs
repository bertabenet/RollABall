using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    private float timeLeft;
    public Text countdownText;
    public Text finalText;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 30.0f;
        countdownText.text = "Countdown: " + timeLeft.ToString("0.0");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0.0 & finalText.text.CompareTo("You Win!") != 0)
        {
            timeLeft -= Time.deltaTime;
            countdownText.text = "Countdown " + timeLeft.ToString("0.0");
        }
    }
}
