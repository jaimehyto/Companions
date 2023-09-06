using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Uduino;

public class OrangeTilt1 : MonoBehaviour
{
    UduinoManager manager;


    [SerializeField] private GameObject orange1;

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

        var orange1NewPosX = math.remap(a, b, -8.67f, -12.79f, analogValueA5);
        var orange1NewPosY = math.remap(a, b, 0.57f, -1.8f, analogValueA5);
        var orange1NewPosZ = math.remap(a, b, -5.14f, -5.14f, analogValueA5);

        var orange1NewRotX = math.remap(a, b, 43.98f, 21.1f, analogValueA5);
        var orange1NewRotY = math.remap(a, b, 65.57f, 71.4f, analogValueA5);
        var orange1NewRotZ = math.remap(a, b, -10.6f, 0f, analogValueA5);


        Vector3 orange1NewPos = new Vector3(orange1NewPosX, orange1NewPosY += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude, orange1NewPosZ);

        Vector3 orange1NewRot = new Vector3(orange1NewRotX, orange1NewRotY, orange1NewRotZ);


        orange1.transform.position = orange1NewPos;

        orange1.transform.rotation = Quaternion.Euler(orange1NewRot);


    }
}
