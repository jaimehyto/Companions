using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Uduino;

public class OrangeTilt4 : MonoBehaviour
{
    UduinoManager manager;

    [SerializeField] private GameObject orange4;


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

        var orange4NewPosX = math.remap(a, b, -8.19f, -12.79f, analogValueA5);
        var orange4NewPosY = math.remap(a, b, 1.32f, -1.8f, analogValueA5);
        var orange4NewPosZ = math.remap(a, b, -4.57f, -5.14f, analogValueA5);

        var orange4NewRotX = math.remap(a, b, 70.23f, 21.1f, analogValueA5);
        var orange4NewRotY = math.remap(a, b, 43.8f, 71.4f, analogValueA5);
        var orange4NewRotZ = math.remap(a, b,  -47.77f, 0f, analogValueA5);

        Vector3 orange4NewPos = new Vector3(orange4NewPosX, orange4NewPosY += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude, orange4NewPosZ);

        Vector3 orange4NewRot = new Vector3(orange4NewRotX, orange4NewRotY, orange4NewRotZ);


        orange4.transform.position = orange4NewPos;

        orange4.transform.rotation = Quaternion.Euler(orange4NewRot);
    }
}
