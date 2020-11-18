using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBalaInimigo : MonoBehaviour
{
    public LayerMask layer;
    public GameObject bala;
    public float fireRate = 0;
    float proximoTiro = 0;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        bool podeAtacar = VisaoDeAtaque();

        if (podeAtacar && Time.time > proximoTiro) {
            Fire();
        }
    }

    bool VisaoDeAtaque() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 100f, layer);
        if (hit.collider.transform.CompareTag("Player")) {
            return true;
        }

        return false;
    }

    void Fire() {
        GameObject CloneBala = Instantiate(bala, transform.position, transform.rotation);

        proximoTiro = Time.time + fireRate;

        if (transform.localScale.x == -1) {
            CloneBala.transform.eulerAngles = new Vector3(0, 0, 180);
        } else if (transform.localScale.x == 1) {
            CloneBala.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
