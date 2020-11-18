using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour{
    // Start is called before the first frame update
    public int life;
    public Player player;

    SpriteRenderer sprite;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();    
    }

    public void damage(int dano) {
        life -= dano;
        
        StartCoroutine(repreDano());
        
        if (life <= 0) {
            Destroy(gameObject);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player") {
            player.Life();
        }
    }

    IEnumerator repreDano() {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;

    }

}
