using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI metersText;
    public Animation runAnim;

    private float score;
    private float lastTime;
    private float cpm;
    private float inputTimer = 0;


    private void Start()
    {
        cpm = 0f;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            float currentTime = Time.time;
            float diff = currentTime - lastTime;
            lastTime = currentTime;
            cpm = 1 / diff;
            cpm.ToString();

            score += 0.1f;
            runAnim.Play();
        }

        if (!Input.GetButtonDown("Fire1"))
        {
            inputTimer = inputTimer + 1;
        }
        else
        {
            inputTimer = 0;
        }

        if(inputTimer == 50)
        {
            Debug.Log("No Input Detected");
            cpm = 0;
        }

        metersText.text = "m/s: " + cpm.ToString("F1");
        scoreText.text = "Distance: " + score.ToString("F1") + "M";

    }
}
