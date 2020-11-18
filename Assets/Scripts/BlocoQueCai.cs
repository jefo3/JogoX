using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlocoQueCai : MonoBehaviour {
    TilemapRenderer tileRenderer;
    TilemapCollider2D box;

    public float time = 1.5f;
    float Novoalfa = 1;
    public float qntMenos = 0.0039f;
    public bool podeContaTempo = false;

    // Start is called before the first frame update
    void Start() {
        tileRenderer = GetComponent<TilemapRenderer>();
        box = GetComponent<TilemapCollider2D>();

    }

    // Update is called once per frame
    void Update() {
        if (podeContaTempo) {
            time -= Time.deltaTime;
            Novoalfa -= qntMenos;
            tileRenderer.material.color = new Color(1, 1, 1, Novoalfa);
        }

        if (time <= 0.5f) {
            box.enabled = false;
        }

        //tempo para se recompor
        if(time <= -0.5f) {
            tileRenderer.material.color = new Color(1, 1, 1, 1);
            box.enabled = true;

            time = 1.5f;
            podeContaTempo = false;
            Novoalfa = 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.transform.tag.Equals("pe")){
            podeContaTempo = true;
        }
    }

}
