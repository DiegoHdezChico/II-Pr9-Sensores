using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoSoldado : MonoBehaviour
{
    private float velocidad = 10f;
    private Rigidbody rb;
    private float latitudMinima = 28.503969f;
    private float latitudMaxima = 28.503971f;
    private float longitudMinima = -16.306160f;
    private float longitudMaxima = -16.306157f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Input.location.Start(1f, 1f);
        Accelerometer acelerometro = Accelerometer.current;
        Vector3 inclinacion = new Vector3(0, 0, -acelerometro.acceleration.ReadValue().z);
        Vector3 movimientoLocal = transform.TransformDirection(inclinacion);
        rb.MovePosition(rb.position + movimientoLocal * velocidad * Time.fixedDeltaTime);
        float latitudActual = Input.location.lastData.latitude;
        float longitudActual = Input.location.lastData.longitude;
        if (latitudActual >= latitudMinima && latitudActual <= latitudMaxima && longitudActual >= longitudMinima && longitudActual <= longitudMaxima)
        {
            if (inclinacion.z >= 0.3f || inclinacion.z <= -0.3f)
            {
                rb.AddForce(movimientoLocal * velocidad * Time.fixedDeltaTime);
            }   
        }
    }
}
