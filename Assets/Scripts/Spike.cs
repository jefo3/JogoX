using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
    
    Player player;
    
    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();    
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") ){
            player.life = 0;
        }
    }
}
