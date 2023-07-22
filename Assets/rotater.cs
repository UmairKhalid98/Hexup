using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotater : MonoBehaviour
{
    private Color32 ballColor;
    private Color32 selfColor;
    public Material material;
    public GameObject particles, popSound;
    
    Camera mainCam;
    public Text score;
    float points = 0;

    private void Awake()
    {
        //material = particles.GetComponent<Material>();
         mainCam = Camera.main;
    }
    private void Update()
    {
        score.text = points.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        points++;
        ballColor = (Color32)(other.gameObject.transform.GetComponent<Renderer>().material.color);
        GetComponent<SpriteRenderer>().color = new Color32(ballColor.r,ballColor.g,ballColor.b,50);
        mainCam.GetComponent<CameraScript>().CameraShake();
        GameObject prefab = Instantiate(particles, transform.position, transform.rotation);       
        material.SetColor("_EmissionColor", ballColor);
        popSound.GetComponent<AudioSource>().Play();
        Destroy(other.gameObject);
        Destroy(prefab, 1);
    }

    //todo: create a soundManager to handle all that stuff
}
