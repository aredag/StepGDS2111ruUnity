using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Uicontrol : MonoBehaviour
{
    public GameObject Cube;
    public Toggle toggle;
    public Slider slider;

    public void Update()
    {
        
        if (toggle.isOn)
            Cube.transform.Rotate(Vector3.one * 360 * Time.deltaTime, Space.Self);
        Cube.transform.position = Vector3.up *(4* slider.value);
        
    }

}
