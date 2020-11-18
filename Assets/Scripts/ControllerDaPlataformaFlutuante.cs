using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDaPlataformaFlutuante : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] frogs;
    public GameObject plataforma;

    bool podeColocar = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < frogs.Length; i++) {
            if (frogs[i] == null) {
                podeColocar = true;
            } else {
                podeColocar = false;
            }
        }

        if (podeColocar) {
            plataforma.SetActive(true);
        }
    }
}
