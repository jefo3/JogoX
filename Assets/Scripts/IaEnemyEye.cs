using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaEnemyEye : MonoBehaviour
{
    public GameObject[] rotas;
    private int inicio = 0;
    private int localAtual;
    private float distancia;
    public float Maxspeed;
    float speed;


    public Player player;
    // Start is called before the first frame update
    void Start() {
        localAtual = inicio;
        speed = Maxspeed;
    }

    // Update is called once per frame
    void Update() {
        //calcula a distancia entre a eye e o objeto da rota
        distancia = Vector2.Distance(transform.position, rotas[localAtual].transform.position);
        if (distancia < 0.1f) {
            localAtual++;
            speed = Maxspeed;
        }

        //para ele ir diminuindo a velocidade de vagarinho
        if (distancia < 0.7f) {
            speed -= 0.1f;
        }

        if (localAtual > rotas.Length - 1) {
            localAtual = inicio;
        }

        //move a eye(enemy) de um ponto a outro em uma determinada velocidade
        transform.position = Vector2.MoveTowards(transform.position, rotas[localAtual].transform.position, Mathf.Abs(speed) * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player") {

            player.Life();
        }
        
    }
}
