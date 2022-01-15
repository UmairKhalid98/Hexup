using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    public float mass = 1f;
    private Rigidbody rb;
    private Color32[] ballColor = {
        new Color32(255,0,0,255), //red
        new Color32(0, 255, 255, 255), //Cyan
        new Color32(255, 0, 255, 255), //Pink
        new Color32(0, 255, 0, 255), //Green
        new Color32(255, 255, 0, 255), //Yellow
        new Color32(64, 0, 239, 255) }; //Purple 
    void Awake()
    {
        target = GameObject.Find("Rotater");
       rb = GetComponent<Rigidbody>();
        //Random.Range(0,7)
        gameObject.GetComponent<Renderer>().material.color = ballColor[Random.Range(0,6)];
    }
    private void Start()
    {
        if (rb.mass >= 2)
        {
            rb.mass -= mass;
        }
        StartCoroutine("move");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
       
        if(transform.position == target.transform.position)
        {
            Destroy(gameObject);
        }

       
    }

    IEnumerator move()
    {
        yield return new WaitForSeconds(1f);
        Vector3 direction = target.transform.position - transform.position;
        rb.AddForce(direction, ForceMode.Impulse);
        StopCoroutine("move");
    }


}
