using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFlutuante : MonoBehaviour{
    
    public GameObject[] rotas;
    private int inicio = 0;
    private int localAtual;
    private float distancia;
    public float Maxspeed;
    float speed;


    // Start is called before the first frame update
    void Start(){
        localAtual = inicio;
        speed = Maxspeed;
    }

    // Update is called once per frame
    void Update(){
        //calcula a distancia entre a plataforma e o objeto da rota
        distancia = Vector2.Distance(transform.position, rotas[localAtual].transform.position);
        if(distancia < 0.1f){
            localAtual++;
            speed = Maxspeed;
        }

        //para ele ir diminuindo a velocidade de vagarinho
        if(distancia < 0.7f) {
            speed -= 0.1f;
        }

        if(localAtual > rotas.Length - 1){
            localAtual = inicio;
        }
        
        //move a plataforma de um ponto a outro em uma determinada velocidade
        transform.position = Vector2.MoveTowards(transform.position, rotas[localAtual].transform.position, Mathf.Abs(speed)*Time.deltaTime);
    }

    //fazer o player ficar em cima da plataforma mesmo ela se mexendo
    //aqui ta dizendo que o pai do objeto que entrou em colisao com a plataforma vai ser a proproa plataforma

    void OnCollisionEnter2D(Collision2D other){
        if(other.transform.tag == "Player"){
            other.transform.parent = transform;
        }
    }

    //aqui vai tirar a platafomea que estava como pai do objeto que estava em collisao 
    void OnCollisionExit2D(Collision2D other){
        if(other.transform.tag == "Player"){
            other.transform.parent = null;
        }
    }
}
