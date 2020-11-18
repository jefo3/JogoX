using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoBlocoMovel : MonoBehaviour
{

    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X)) {
            texto.enabled = false;

            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {
            texto.enabled = true;
        }
    }
}
