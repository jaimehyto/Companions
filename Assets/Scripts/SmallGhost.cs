using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.Networking.Types;
using Unity.Mathematics;

public class SmallGhost : MonoBehaviour
{
    UduinoManager manager;
    [SerializeField] public Material material;


    private float getYAxis;
    private float getZAxis;

    private float a = 0.0f;
    private float b = 1024.0f;
    private float c = 8.7f;
    private float d = 5.11f;

    private float yAxis = -9.73f;

    int analogValueA3;
    float A3Value;


    void Awake()
    {
        manager = UduinoManager.Instance;

        manager.pinMode(AnalogPin.A2, PinMode.Input); //which analog pin it is connected to
        manager.pinMode(AnalogPin.A3, PinMode.Input);
    }

    void Start()
    {
        getYAxis = transform.position.y;
        getZAxis = transform.position.z;
    }

    void Update()
    {
        //A2
        int analogValueA2 = manager.analogRead(AnalogPin.A2); //value between 0-1024 for A2 pin

        var remappedValueA2X = math.remap(a, b, c, d, analogValueA2); //remapping 0-1024 to 0-4

        var remappedValueA2Y = math.remap(a, b, getYAxis, yAxis, analogValueA2);

        //Debug.Log(remappedValueA2); //printing the value

        Vector3 newPos = new Vector3(remappedValueA2X, remappedValueA2Y, getZAxis);

        gameObject.transform.position = newPos;

        //A3 for alpha value
        analogValueA3 = manager.analogRead(AnalogPin.A3);

        A3Value = ((analogValueA3 + 0.4f) / 1024);

        //Debug.Log(A3Value);

        Color color = material.color;
        color.a = A3Value;
        material.color = color;
    }

}
