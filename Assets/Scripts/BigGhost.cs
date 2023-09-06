using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using System;
using Unity.Mathematics;

public class BigGhost : MonoBehaviour
{
    UduinoManager manager;
    [SerializeField] public Material material;


    void Awake()
    {
        manager = UduinoManager.Instance;
        manager.pinMode(AnalogPin.A1, PinMode.Input); //which analog pin it is connected to
    }

    void Start()
    {

    }

    void Update()
    {

        //Quaternion newPos = Quaternion.Euler(0, a0Value, 0);

        //gameObject.transform.rotation = newPos;

        //float a0Value = (analogValueA0 / 10.0f) + 1.0f; //remaping the value
        //transform.Rotate(0, 0 + a0Value * Time.deltaTime, 0);

        //A1 for alpha value
        int analogValueA1 = manager.analogRead(AnalogPin.A1);

        //float a1Value = ((analogValueA1 + 0.4f) / 1024); //0-1 range
        float a1ValueBust = (analogValueA1 / 600f);

        //Debug.Log(a1ValueBust);

        Color color = material.color;
        color.a = a1ValueBust;
        material.color = color;

    }
}
