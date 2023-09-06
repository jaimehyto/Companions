using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Uduino;

public class OrangeTilt3 : MonoBehaviour
{
    UduinoManager manager;

    [SerializeField] private GameObject orange3;


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

        var orange3NewPosX = math.remap(a, b, -10.09f, -12.79f, analogValueA5);
        var orange3NewPosY = math.remap(a, b, -2.45f, -1.8f, analogValueA5);
        var orange3NewPosZ = math.remap(a, b, -2.68f, -5.14f, analogValueA5);

        var orange3NewRotX = math.remap(a, b, 54.89f, 21.1f, analogValueA5);
        var orange3NewRotY = math.remap(a, b, 99.36f, 71.4f, analogValueA5);
        var orange3NewRotZ = math.remap(a, b, -19.41f, 0f, analogValueA5);

        Vector3 orange2NewPos = new Vector3(orange3NewPosX, orange3NewPosY += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude, orange3NewPosZ);

        Vector3 orange2NewRot = new Vector3(orange3NewRotX, orange3NewRotY, orange3NewRotZ);


        orange3.transform.position = orange2NewPos;

        orange3.transform.rotation = Quaternion.Euler(orange2NewRot);
    }
}
