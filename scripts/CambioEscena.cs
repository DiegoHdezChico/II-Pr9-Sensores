using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string nuevaEscena;

    public void CargarEscena()
    {
        SceneManager.LoadScene(nuevaEscena);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // nuevaEscena = "EscenaSoldado";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
