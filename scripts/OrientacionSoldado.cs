 
using UnityEngine; 
using UnityEngine.InputSystem; 

public class OrientacionSoldado : MonoBehaviour { 
    private float velocidadGiro = 5f; 
    void Start() 
    { 

    } 
    void Update() { 
        var magnetometro = MagneticFieldSensor.current; 
        var gravimetro = GravitySensor.current; 
        Vector3 vectorMagnetico = magnetometro.magneticField.ReadValue().normalized; 
        Vector3 vectorGravedad = gravimetro.gravity.ReadValue().normalized; 
        Vector3 este = Vector3.Cross(vectorMagnetico, vectorGravedad).normalized;
        Vector3 norte = Vector3.Cross(vectorGravedad, este).normalized; 
        Vector3 northPlano = new Vector3(norte.x, 0f, norte.z).normalized; 
        // Corrección del eje z invertido 
        northPlano.z = -northPlano.z; 
        Quaternion objetivo = Quaternion.LookRotation(northPlano, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, objetivo, Time.deltaTime * velocidadGiro); 
    } 
}