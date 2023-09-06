using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Uduino;

public class PlateTilt : MonoBehaviour
{
    UduinoManager manager;

    [SerializeField] private GameObject plate;

    private int a = 0;
    private int b = 1024;
    private float c = 47f;
    private float d = 21.1f;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Awake()
    {
        manager = UduinoManager.Instance;

        manager.pinMode(AnalogPin.A5, PinMode.Input);
    }

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        //A5
        int analogValueA5 = manager.analogRead(AnalogPin.A5);

        var plateRot = math.remap(a, b, c, d, analogValueA5);

        Vector3 plateNewRot = new Vector3(plateRot, 71.4f, 0);

        plate.transform.rotation = Quaternion.Euler(plateNewRot);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

        //Debug.Log(plateRot);

    }
}
