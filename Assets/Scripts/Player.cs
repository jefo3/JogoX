using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{

    public AudioSource[] audios;
    
    public bool isJump = false;
    public float jumpForce;
    public float speed;
    public int life = 6;

    public ParticleSystem sangue;

    float move;

    Rigidbody2D rb2d;
    Transform tr2d;
    Animator anim;
    SpriteRenderer sprite;
    

    public bool isOnGround;
    public LayerMask ground;
    public Transform groundCheck;
    public float raio;

    //variaveis da bala
    public Transform spawnBala;
    public GameObject bala;
    public float fireRate = 0;
    float proximoTiro = 0;

    
    // Start is called before the first frame update
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        tr2d = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, raio, ground);

        if(isOnGround && Input.GetButtonDown("Jump")) {
            isJump = false;
        }


        if (life == 0) {
            sprite.enabled = false;
            rb2d.bodyType = RigidbodyType2D.Static;
            Instantiate(sangue, transform.position, transform.rotation);
            Invoke("ReloadScene", 1f);
            

        }

        if (Input.GetButton("Fire1") && Time.time > proximoTiro) {
            Fire();
        }
       

        mudaLado();

        

    }

    void FixedUpdate() {
        

        move = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(move * speed * Time.deltaTime, rb2d.velocity.y);

        

        if (!isJump) {
            rb2d.AddForce(new Vector2(0f, jumpForce * Time.deltaTime));
            isJump = true;
            audios[0].Play();
        }



        //para ativar as animaçoes
        anim.SetFloat("moveX", Mathf.Abs( move));
        //colocando o isOnGround Negado pq enquando ele ta no chao ele nao pode exibir a enimação do pulo
        anim.SetBool("jump", !isOnGround);

        
        
    }

    void mudaLado() {
        if ((move > 0 && tr2d.localScale.x < 0) || (move < 0 && tr2d.localScale.x > 0)) {

            tr2d.localScale = new Vector2(tr2d.localScale.x * -1, tr2d.localScale.y);

        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Fire() {
        anim.SetTrigger("atirando");

        GameObject CloneBala = Instantiate(bala, spawnBala.position, spawnBala.rotation);

        proximoTiro = Time.time + fireRate;

        if (transform.localScale.x == -1) {
            CloneBala.transform.eulerAngles = new Vector3(0, 0, 180);
        }else if (transform.localScale.x == 1) {
            CloneBala.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        audios[1].Play();
        
    }

    public void Life() {
        StartCoroutine(Damage());
        life -= 1;
        audios[2].Play();
    }

    IEnumerator Damage() {
        for (float i = 0; i < 0.2; i += 0.1f) {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

        void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, raio);
    }
}
