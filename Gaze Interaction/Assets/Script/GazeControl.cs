using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeControl : MonoBehaviour
{
    RaycastHit hit;
    int LayerMask=1<<9;
    public float intensity = 1f;
    int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward,out hit, Mathf.Infinity,LayerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

        if (hit.transform != null)
        {
            float shake = intensity * direction * Time.deltaTime;
            hit.transform.Translate(shake,shake,shake);
            direction = direction * -1;
        }        
    }
}
