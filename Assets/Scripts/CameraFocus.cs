using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.Networking.Types;
using Unity.Mathematics;
using UnityEngine.Rendering.PostProcessing;

public class CameraFocus : MonoBehaviour
{
    UduinoManager manager;

    private int a = 0;
    private int b = 1024;
    private int c = 1;
    private int d = 80;

    PostProcessVolume volume;

    [SerializeField] UI ui;


    void Awake()
    {
        manager = UduinoManager.Instance;

        manager.pinMode(AnalogPin.A4, PinMode.Input); //which analog pin it is connected to
    }

    void Start()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
        DepthOfField depthOfField;
        volume.profile.TryGetSettings(out depthOfField);
        depthOfField.focalLength.value = 1;
    }

    void Update()
    {
        //A4
        int analogValueA4 = manager.analogRead(AnalogPin.A4); //value between 0-1024 for A4 pin

        var remappedValueA4 = math.remap(a, b, c, d, analogValueA4); //remapping 0-1024 to 0-150

        //Debug.Log(remappedValueA4); //printing the value

        DepthOfField depthOfField;
        volume.profile.TryGetSettings(out depthOfField);
        depthOfField.focalLength.value = remappedValueA4;

        if (remappedValueA4 > 72 && remappedValueA4 < 80)
        {
            ui.Insanity1();
        }

        if (remappedValueA4 > 64 && remappedValueA4 < 72)
        {
            ui.Insanity2();
        }

        if (remappedValueA4 > 56 && remappedValueA4 < 64)
        {
            ui.Insanity3();
        }

        if (remappedValueA4 > 48 && remappedValueA4 < 56)
        {
            ui.Insanity4();
        }

        if (remappedValueA4 > 40 && remappedValueA4 < 48)
        {
            ui.Insanity5();
        }

        if (remappedValueA4 > 32 && remappedValueA4 < 40)
        {
            ui.Insanity6();
        }

        if (remappedValueA4 > 24 && remappedValueA4 < 32)
        {
            ui.Insanity7();
        }

        if (remappedValueA4 > 16 && remappedValueA4 < 24)
        {
            ui.Insanity8();
        }

        if (remappedValueA4 > 8 && remappedValueA4 < 16)
        {
            ui.Insanity9();
        }

        if (remappedValueA4 > 0 && remappedValueA4 < 8)
        {
            ui.Insanity10();
        }
    }

}
