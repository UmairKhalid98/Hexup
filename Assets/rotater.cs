using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotater : MonoBehaviour
{
    private Color32 ballColor;
    private Color32 selfColor;
    public Text score;
    float points = 0;
    private void Update()
    {
        score.text = points.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        points++;
        ballColor = (Color32)(other.gameObject.transform.GetComponent<Renderer>().material.color);
        GetComponent<SpriteRenderer>().color = new Color32(ballColor.r,ballColor.g,ballColor.b,50);
        Destroy(other.gameObject);
    }
}
