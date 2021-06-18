using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public Animation runAnim;

    private float score;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            score += 0.1f;
            runAnim.Play();
        }

        scoreText.text = "Distance: " + score.ToString("F1") + "M";
    }
}
