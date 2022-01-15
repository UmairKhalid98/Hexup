using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HexaSide : MonoBehaviour
{
    private Color32 ballColor;
    private Color32 selfColor;



    private void OnTriggerEnter(Collider other)
    {

        // GetComponent<Collider>().enabled = false;
        ballColor = (Color32)(other.gameObject.transform.GetComponent<Renderer>().material.color);
        selfColor = (Color32)(GetComponent<Renderer>().material.color);

        if (!ballColor.Equals(selfColor))
        {
  
            Destroy(other.gameObject);
            GameObject.Find("Hexagon").GetComponent<Hexagon>().gameOver = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


        //    GetComponent<Collider>().enabled = true;
        //  Debug.Log("trigger entered" + other.material);
        // other.isTrigger = false;
        // other.attachedRigidbody.useGravity = false;
    }

}
