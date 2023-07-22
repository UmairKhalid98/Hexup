using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float shakeDuration = 2f; 
    public float shakeAmount = 0.1f; 
    public float decreaseFactor = 1.0f;

    bool shaking = false;
    float timer;
    public float frequency = 5; 


    Vector3 originalPos;
    float currentShakeDuration;
    // Update is called once per frame
    private void Awake()
    {
        originalPos = transform.localPosition;

    }
    void FixedUpdate()
    {
        if (shaking && timer < shakeDuration)
        {
            transform.position = originalPos + Random.insideUnitSphere * frequency;
            timer += Time.deltaTime;
        }
        else
        {
            shaking = false;
            transform.position = originalPos;
        }
      //  transform.Rotate(Vector3.forward * Time.deltaTime * 10);
    }

    public void CameraShake()
    {
        shaking = true;
        timer = 0f;
    }
}
