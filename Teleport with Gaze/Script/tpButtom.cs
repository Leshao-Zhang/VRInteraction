using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class tpButtom : MonoBehaviour
{
    RaycastHit hit;
    int LayerMask=1<<10;
    public Transform canvas;
    [TextArea]
    public string Notes = "Using SPACE to teleport to where you are looking at";

    // Start is called before the first frame update
    void Start()
    {
        canvas.Rotate(90, 0, 0);
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
            canvas.position = new Vector3(hit.point.x, hit.point.y + 0.01f, hit.point.z);
            if (Input.GetKeyDown("space"))
            {
                transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }        
    }
}
