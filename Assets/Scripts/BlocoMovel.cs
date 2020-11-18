using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BlocoMovel : MonoBehaviour {
    
    private Rigidbody2D body;
    private float massaOriginal;

    //private Transform;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

   void OnCollisionStay2D(Collision2D other){
        if(other.transform.tag == "Player"){   
            if(Input.GetKey(KeyCode.X)){
                body.bodyType = RigidbodyType2D.Dynamic;
            } else{
                body.bodyType = RigidbodyType2D.Static;
            }
        }
    }


    void OnCollisionExit2D(Collision2D other){
        if(other.transform.tag == "Player"){
            body.bodyType = RigidbodyType2D.Static;
        }
    }

}
