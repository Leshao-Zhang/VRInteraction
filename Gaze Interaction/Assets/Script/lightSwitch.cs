using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    Light lamp;
    // Start is called before the first frame update
    void Start()
    {
        lamp = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            lamp.enabled = !lamp.enabled;
        }
    }
}
