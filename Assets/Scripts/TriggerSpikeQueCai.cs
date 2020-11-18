using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TriggerSpikeQueCai : MonoBehaviour {

    public GameObject spike;
    public Transform tr2d;
    bool podeContaTempo = false;
    float yInicial;
    public float time = 1.5f;
    // Start is called before the first frame update
    void Start() {
        yInicial = tr2d.position.y;
    }

    void Update() {
        if (podeContaTempo) {
            time -= Time.deltaTime;
            spike.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        if (time <= 0.0f) {
            spike.transform.position = new Vector2 (tr2d.position.x, yInicial);
            spike.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            time = 1.5f;
            podeContaTempo = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            podeContaTempo = true;
            //spike.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
