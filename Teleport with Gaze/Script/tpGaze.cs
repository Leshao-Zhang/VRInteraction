using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tpGaze : MonoBehaviour
{
    // Start is called before the first frame update
    public int layer = 10;
    RaycastHit hit;
    int LayerMask;
    public float progressSpeed = 0.5f;
    public GameObject loadingImage;
    bool staring = false;
    Image imageComp;
    bool triggered = false;
    public GameObject canvas;
    //above do not change
    [TextArea]
    public string Notes = "Stare at the blue teleport point to teleport.";


    // Start is called before the first frame update
    void Start()
    {
        LayerMask = 1 << layer;
        loadingImage.SetActive(false);
        imageComp = loadingImage.GetComponent<Image>();
        //above do not change
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, LayerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            Debug.Log("Did Hit");
            staring = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);
            Debug.Log("Did not Hit");
            staring = false;
            imageComp.fillAmount = 0;
            triggered = false;
        }
        if (staring && imageComp.fillAmount < 1)
        {
            imageComp.fillAmount += progressSpeed * Time.deltaTime;
            loadingImage.SetActive(true);
            canvas.transform.position = Vector3.Lerp(transform.position, hit.point, 0.9f); //put the indicator in front of the object
            canvas.transform.rotation = transform.rotation;
        }
        if (imageComp.fillAmount >= 1)
        {
            loadingImage.SetActive(false);
            if (!triggered)
            {
                //here we can set different rule for different object.
                if (hit.transform.gameObject.tag.Equals("tpoint"))
                {
                    transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                }
                /**
                 * For example:
                 * 
                 * if (hit.transform.gameObject.Equals(someOtherSwitcher))
                 * {
                 *      Do something;
                 * }    
                 * 
                 */
                //Add more rules above. Do not change below.
                triggered = true;
            }
        }
    }
}