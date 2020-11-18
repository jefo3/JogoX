using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour{
    // Start is called before the first frame update
    public Sprite[] life;
    public Image lifeBarUI;

    public Player playerLive;
    void Start(){
          
    }

    // Update is called once per frame
    void Update(){
        lifeBarUI.sprite = life[playerLive.life - 1];
    }
}
