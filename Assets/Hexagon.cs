using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hexagon : MonoBehaviour
{

    bool leftTouch;
    bool rightTouch;
    public float moveSpeed = 10;
    public Text play;
    public Vector3 knob = Vector3.zero;
    float move = 0f;
    float ballSpeed = 0f;
    float radius = 10f;
    private bool started = false;
    public bool gameOver = false;
    public GameObject ball;

    //Touch Control
    private Vector3 touchPosition;
    private float center = Screen.width/2;
    private float initPos;



    private void FixedUpdate()
    {
        if (!play.enabled && !started)
        {
            StartCoroutine("Spawn");
            started = true;
        }
        if(Input.touchCount >0){
            Touch touch = Input.GetTouch(0);
            
            initPos = touch.position.x;
            touchPosition.z = 0;
            speed(initPos);
       
  
        }

        else
        {
            move = Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetMouseButton(0))
        {
            touchPosition = Input.mousePosition;
            initPos = touchPosition.x;
            speed(initPos);

            // Debug.Log("mouse down: " + touchPosition);
        }

        transform.RotateAround(knob, Vector3.forward, move * -moveSpeed * Time.fixedDeltaTime);
    }

    void speed(float initPos)
    {
        Debug.Log(initPos-center);
        if (initPos-center > 0)
        {
            move = 1;
        }
        else if (initPos- center <0)
        {
            move = -1;
        }
        else
        {
            move = 0;
        }
    }

    //Spawn the Objects
    IEnumerator Spawn()
    {
        while (!gameOver) // this just equates to "repeat forever"
        {
            yield return new WaitForSeconds(Random.Range(1f,3f));
            //generate spwan points in a circle using equation of the circle
            float x = Random.Range(knob.x - radius, knob.x + radius + 0.0001f);
            float y = knob.y + (Rand()) * Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow((x - knob.x), 2));
            //get the vector position 
            Vector3 spawnPosition = new Vector3(x, y, 0);
            GameObject ballObj = Instantiate(ball, spawnPosition, Quaternion.identity);
            ballObj.GetComponent<ball>().mass += ballSpeed;
            ballSpeed += 0.1f;
        }
    }

    private float Rand()
    {
        float x = Random.Range(-1, 1) >= 0 ? 1 : -1;
        return x;
    }



}
