using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    float timeDestroy = 1f;
    public float speed;
    public int dano;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeDestroy);
        dano = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Enemy") {

            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null) {

                enemy.damage(dano);
            }


        }

        Destroy(gameObject);
    }
}
