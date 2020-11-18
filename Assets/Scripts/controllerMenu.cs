using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            telaIniciar();
        }
    }
    public void fase1() {
        SceneManager.LoadScene("fase1");
    }
    public void instruçoes() {
        SceneManager.LoadScene("TelaInicial");
    }

    public void telaIniciar() {
        SceneManager.LoadScene("TelaInicial");
    }

    public void Iniciar() {
        SceneManager.LoadScene("scenaHistoriaInicial");
    }

    public void quit() {
        Application.Quit();
    }

    public void creditos() {
        SceneManager.LoadScene("Creditos");
    }
}
