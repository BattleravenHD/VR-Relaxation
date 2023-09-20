using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightSounds : MonoBehaviour
{
    public GameObject Sun;

    public AudioSource day1;
    public AudioSource day2;

    public AudioSource night1;
    public AudioSource night2;

    private float day1Vol;
    private float day2Vol;

    private float night1Vol;
    private float night2Vol;

    private void Start()
    {
        day1Vol = day1.volume;
        day2Vol = day2.volume;

        night1Vol = night1.volume;
        night2Vol = night2.volume;
    }

    // Update is called once per frame
    void Update()
    {
        float modifyVal;

        if (Sun.transform.rotation.eulerAngles.x > 180)
            modifyVal = Sun.transform.rotation.eulerAngles.x - 360;
        else
            modifyVal = Sun.transform.rotation.eulerAngles.x;

        modifyVal += 72;
        modifyVal /= 144;

        day1.volume = day1Vol * ((modifyVal - 0.5f) * 2);
        day2.volume = day2Vol * ((modifyVal - 0.5f) * 2);

        night1.volume = night1Vol * (1 - modifyVal - ((modifyVal - 0.5f) * 2));
        night2.volume = night2Vol * (1 - modifyVal - ((modifyVal - 0.5f) * 2));

    }
}
