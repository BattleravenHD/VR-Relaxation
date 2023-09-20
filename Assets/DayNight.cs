using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public GameObject Sun;
    public float speed;
    public GameObject fireflys;
    public  Material night;
    public Material day;
    private Color ogColor;


    private void Start()
    {
        ogColor = RenderSettings.fogColor;
    }

    // Update is called once per frame
    void Update()
    {
        Sun.transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));

        float modifyVal;

        if (Sun.transform.rotation.eulerAngles.x > 180)
            modifyVal = Sun.transform.rotation.eulerAngles.x - 360;
        else
            modifyVal = Sun.transform.rotation.eulerAngles.x;

        modifyVal += 72;
        modifyVal /= 144;

        Sun.GetComponent<Light>().intensity = 1 * modifyVal;
        RenderSettings.ambientIntensity = 0.5f * modifyVal;

        Color temp = ogColor;
        temp.r = ogColor.r * modifyVal;
        temp.g = ogColor.g * modifyVal;
        temp.b = ogColor.b * modifyVal;

        RenderSettings.fogColor = temp;

        if (modifyVal > 0.5f)
            fireflys.SetActive(false);
        else
            fireflys.SetActive(true);

        float temps = ((modifyVal - 0.5f) * 2);
        /*
        RenderSettings.skybox.Lerp(day, night, temps);
        DynamicGI.UpdateEnvironment();*/
    }
}
