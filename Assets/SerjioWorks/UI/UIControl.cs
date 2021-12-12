using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIControl : MonoBehaviour
{
    public GameObject Cube;

    public TMP_InputField FromField;
    public TMP_Text ToText;
    public Toggle toggle;
    public Slider slider;
    
    public void OnMoveButtonPress()
    {
        Cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void Update()
    {
        ToText.text = FromField.text;
        if (toggle.isOn)
            Cube.transform.Rotate(Vector3.one * 360 * Time.deltaTime, Space.Self);
        Cube.transform.position = Vector3.up * slider.value;
    }
}