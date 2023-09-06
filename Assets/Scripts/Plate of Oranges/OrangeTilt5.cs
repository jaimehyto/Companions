using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Uduino;

public class OrangeTilt5 : MonoBehaviour
{
    UduinoManager manager;

    [SerializeField] private GameObject orange5;


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

        var orange5NewPosX = math.remap(a, b, -10.12f, -12.79f, analogValueA5);
        var orange5NewPosY = math.remap(a, b, -5.05f, -1.8f, analogValueA5);
        var orange5NewPosZ = math.remap(a, b, -5.14f, -5.14f, analogValueA5);

        var orange5NewRotX = math.remap(a, b, 71.27f, 21.1f, analogValueA5);
        var orange5NewRotY = math.remap(a, b, 22.03f, 71.4f, analogValueA5);
        var orange5NewRotZ = math.remap(a, b, -59.94f, 0f, analogValueA5);

        Vector3 orange5NewPos = new Vector3(orange5NewPosX, orange5NewPosY += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude, orange5NewPosZ);

        Vector3 orange5NewRot = new Vector3(orange5NewRotX, orange5NewRotY, orange5NewRotZ);


        orange5.transform.position = orange5NewPos;

        orange5.transform.rotation = Quaternion.Euler(orange5NewRot);
    }
}
