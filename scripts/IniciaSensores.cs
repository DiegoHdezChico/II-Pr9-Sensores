using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class IniciaSensores : MonoBehaviour
{
    void OnEnable()
    {
        ReadOnlyArray<InputDevice> devices = InputSystem.devices;
        foreach (InputDevice device in devices)
        {
            if (device is Sensor sensor && !sensor.enabled)
            {
                InputSystem.EnableDevice(device);
                Debug.Log(device.name + " enabled.");   
            }
        }        
    }
}
