using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;


public class Illustrations : MonoBehaviour
{

    UduinoManager manager;
    SpriteRenderer spriteRenderer;

    Color color;

    private void Awake()
    {
        manager = UduinoManager.Instance;
        //manager.pinMode(AnalogPin.A4, PinMode.Input_pullup);
        manager.pinMode(4, PinMode.Input_pullup);

    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
    }

    void Update()
    {
        //int pin4 = manager.analogRead(AnalogPin.A4);
        int pin4 = manager.digitalRead(4);

        Debug.Log(pin4);

        if (pin4 == 1)
        {
            color.a = 0;
            spriteRenderer.color = color;
        }
        else
        {
            color.a = 1;
            spriteRenderer.color = color;
        }
    }
}

