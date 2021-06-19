using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI metersText;
    public TMPro.TextMeshProUGUI gameTimerText;
    public TMPro.TextMeshProUGUI gameOverText;
    public Animation runAnim;
    public GameObject gameOverScreen;

    private float score;
    private float lastTime;
    private float cpm;
    private float inputTimer = 0;
    private float gameTimer;
    private bool canInput;
    private bool canTime;


    private void Start()
    {
        cpm = 0f;
        gameTimer = 30;
        canInput = true;
        canTime = true;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1") && canInput)
        {
            float currentTime = Time.time;
            float diff = currentTime - lastTime;
            lastTime = currentTime;
            cpm = 1 / diff;
            cpm.ToString();

            score += 0.1f;
            runAnim.Play();
        }

        if (!Input.GetButtonDown("Fire1") && canInput)
        {
            inputTimer = inputTimer + 1;
        }
        else
        {
            inputTimer = 0;
        }

        if(inputTimer == 50 && canInput)
        {
            Debug.Log("No Input Detected");
            cpm = 0;
        }

        metersText.text = "m/s: " + cpm.ToString("F1");
        scoreText.text = "Distance: " + score.ToString("F1") + "m";
        gameTimerText.text = "Time: " + gameTimer.ToString("F0");

        if (canTime)
        {
            gameTimer -= Time.deltaTime;
        }

        if(gameTimer <= 0.0f)
        {
            Debug.Log("Time Up");
            canTime = false;
            canInput = false;
            gameOverText.text = "Your Distance: " + score.ToString("F1") + "m";
            gameOverScreen.gameObject.SetActive(true);            
        }
    }
}
