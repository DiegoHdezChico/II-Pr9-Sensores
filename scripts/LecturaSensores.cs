using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class LecturaSensores : MonoBehaviour
{
    private TextMeshProUGUI texto_salida;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto_salida = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadOnlyArray<InputDevice> devices = InputSystem.devices;
        foreach(InputDevice device in devices)
        {
            if (device is Accelerometer accelerometer)
            {
                var accel = accelerometer.acceleration.ReadValue();
                texto_salida.text = $"Acelerómetro:\n  X:{accel.x:F2}  Y:{accel.y:F2}  Z:{accel.z:F2}\n\n";
            }
            if (device is UnityEngine.InputSystem.Gyroscope gyroscope)
            {
                var gyro = gyroscope.angularVelocity.ReadValue();
                texto_salida.text += $"Giroscopio:\n  X:{gyro.x:F2}  Y:{gyro.y:F2}  Z:{gyro.z:F2}\n\n";
            }
            if (device is GravitySensor gravitySensor)
            {
                var grav = gravitySensor.gravity.ReadValue();
                texto_salida.text += $"Gravedad:\n  X:{grav.x:F2}  Y:{grav.y:F2}  Z:{grav.z:F2}\n\n";
            } 
            if (device is AttitudeSensor attitudeSensor)
            {
                var att = attitudeSensor.attitude.ReadValue(); // Quaternion
                texto_salida.text += $"Actitud (Quaternion):\n  X:{att.x:F2} Y:{att.y:F2} Z:{att.z:F2} W:{att.w:F2}\n\n";
            }
            if (device is LinearAccelerationSensor linearAccelerationSensor)
            {
                var lin = linearAccelerationSensor.acceleration.ReadValue();
                texto_salida.text += $"Acel. Lineal:\n  X:{lin.x:F2}  Y:{lin.y:F2}  Z:{lin.z:F2}\n\n";
            }
            if (device is MagneticFieldSensor magneticFieldSensor)
            {
                var mag = magneticFieldSensor.magneticField.ReadValue();
                texto_salida.text += $"Magnetómetro:\n  X:{mag.x:F2}  Y:{mag.y:F2}  Z:{mag.z:F2}\n\n";
            }
            if (device is LightSensor lightSensor)
            {
                float light = lightSensor.lightLevel.ReadValue();
                texto_salida.text += $"Luz: {light:F2} lux\n\n";
            }
            if (device is PressureSensor pressureSensor)
            {
                float press = pressureSensor.atmosphericPressure.ReadValue();
                texto_salida.text += $"Presión: {press:F2} hPa\n\n";
            }
            if (device is ProximitySensor proximitySensor)
            {
                float prox = proximitySensor.distance.ReadValue();
                texto_salida.text += $"Proximidad: {prox:F2} cm\n\n"; 
            }
            if (device is HumiditySensor humiditySensor)
            {
                float hum = humiditySensor.relativeHumidity.ReadValue();
                texto_salida.text += $"Humedad: {hum:F2} %\n\n";
            }
            if (device is AmbientTemperatureSensor ambientTemperatureSensor)
            {
                float temp = ambientTemperatureSensor.ambientTemperature.ReadValue();
                texto_salida.text += $"Temp ambiente: {temp:F2} °C\n\n";
            }
            if (device is StepCounter stepCounter)
            {
                int steps = stepCounter.stepCounter.ReadValue();
                texto_salida.text += $"Contador de pasos: {steps}\n\n";   
            }
        }
    }
}
