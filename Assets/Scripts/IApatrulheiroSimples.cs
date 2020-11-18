using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IApatrulheiroSimples : MonoBehaviour{
    
    public Transform groundCheck;
    public LayerMask ground;
    public float raio;
    Rigidbody2D rb2d;

    public float speed = 1f;

    bool isOnGround;
    // Start is called before the first frame update
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, raio, ground);
    }

    void FixedUpdate() {
        if (isOnGround) {
            rb2d.velocity = new Vector2( speed * Time.deltaTime, rb2d.velocity.y);

            
        } else {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;
        }
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, raio);
    }
}
