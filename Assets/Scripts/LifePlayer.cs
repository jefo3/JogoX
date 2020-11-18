using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LifePlayer : MonoBehaviour
{

    public int life = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 0) {
            ReloadScene();
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene("fase1");
    }
    
}
