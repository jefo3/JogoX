using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {
    // Start is called before the first frame update

    public Transform player;

    bool isMoving = false;
    public float distanceAttack;
    public float speed;
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        float distance = Vector2.Distance(player.position, transform.position); ;

        isMoving = (distance <= distanceAttack);

        if(isMoving){
            if((player.position.x > transform.position.x && transform.localScale.x < 0) ||
                (player.position.x < transform.position.x && transform.localScale.x > 0)) {


                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            
            }
        }

        if(isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Mathf.Abs(speed) * Time.deltaTime);
        }

    }

}
