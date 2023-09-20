using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton : MonoBehaviour
{
    public GameObject buttonMain;
    public float offset;
    public Material Green;
    public Material Red;
    public bool On_OFF;
    public GameObject enabledItem;
    public GameObject descritiontext;

    private bool recentToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonMain.transform.position.y < (transform.position.y + offset/4) && !recentToggle)
        {
            On_OFF = !On_OFF;
            recentToggle = true;
            Material[] matArray = buttonMain.GetComponent<MeshRenderer>().materials;

            if (On_OFF)
                matArray[1] = Red;
            else
                matArray[1] = Green;

            buttonMain.GetComponent<MeshRenderer>().materials = matArray;
        }
        if (recentToggle && buttonMain.transform.position.y > (transform.position.y + offset / 1.2f))
            recentToggle = false;

        enabledItem.SetActive(!On_OFF);
    }

    private void FixedUpdate()
    {
        buttonGravity();
    }

    void buttonGravity()
    {
        if (buttonMain.transform.position.y > transform.position.y + offset)
        {
            buttonMain.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }else
        {
            buttonMain.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        descritiontext.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        descritiontext.SetActive(true);
    }
}
