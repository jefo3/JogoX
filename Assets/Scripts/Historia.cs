using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Historia : MonoBehaviour
{
    // Start is called before the first frame update
    public Text[] textos;
    Text t;
    int i = 0;
    public bool fim = false;
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(i >= textos.Length) {
            if(fim == true) {
                SceneManager.LoadScene("TelaInicial");
            } else {

                SceneManager.LoadScene("instruçoes");
            }
        } else {
            t.text = textos[i].text;
        }
    }

    public void Avançar() {
        i++;
    }

}
