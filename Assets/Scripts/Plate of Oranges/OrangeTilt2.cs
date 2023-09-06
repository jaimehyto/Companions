using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Uduino;

public class OrangeTilt2 : MonoBehaviour
{
    UduinoManager manager;

    [SerializeField] private GameObject orange2;


    private int a = 0;
    private int b = 1024;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    private void Awake()
    {
        manager = UduinoManager.Instance;

        manager.pinMode(AnalogPin.A5, PinMode.Input);
    }

    void Start()
    {


    }

    void Update()
    {
        //A5
        int analogValueA5 = manager.analogRead(AnalogPin.A5);

        var orange2NewPosX = math.remap(a, b,  -7.02f, -12.79f, analogValueA5);
        var orange2NewPosY = math.remap(a, b,  -1.54f, -1.8f, analogValueA5);
        var orange2NewPosZ = math.remap(a, b,  -5.65f, -5.14f, analogValueA5);

        var orange2NewRotX = math.remap(a, b,  47.71f, 21.1f, analogValueA5);
        var orange2NewRotY = math.remap(a, b,  55.29f, 71.4f, analogValueA5);
        var orange2NewRotZ = math.remap(a, b,  -13.13f, 0f, analogValueA5);

        Vector3 orange2NewPos = new Vector3(orange2NewPosX, orange2NewPosY += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude, orange2NewPosZ);

        Vector3 orange2NewRot = new Vector3(orange2NewRotX, orange2NewRotY, orange2NewRotZ);


        orange2.transform.position = orange2NewPos;

        orange2.transform.rotation = Quaternion.Euler(orange2NewRot);

    }
}
