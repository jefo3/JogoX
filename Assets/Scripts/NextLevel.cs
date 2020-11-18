using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour{
    
   AudioSource soundFx;
    // Start is called before the first frame update
    void Start() {
        soundFx = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Invoke("Next", 2f);
            soundFx.Play();
        }
    }

    void Next() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
