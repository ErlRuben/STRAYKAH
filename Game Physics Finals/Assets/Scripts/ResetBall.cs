using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResetBall: MonoBehaviour
{
    public Transform reset;
    public GameObject ball;
    public GameObject button;
    public Text tryText;
    private float tries = 10;
    private bool isEnable = true;
    public bool collidecheck = true;
    public Rigidbody rb;
    public GameObject BallObject;
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update(){
        
    }
    public void Clicked(){
        button.SetActive(false);  
    }
    public void OnTriggerEnter(Collider other){

        if(collidecheck == true){
            if (tries == 0 && isEnable == true){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(2);
            }
            StartCoroutine(BallReset()); 
            collidecheck = false;
        }
        else if (collidecheck == false){
            if (tries == 1 && isEnable == true){
                tries -= 1;
                tryText.text = tries.ToString("0");
            }
            else{
                collidecheck = true;
            }
        }
    }
    IEnumerator BallReset()
    {
        
        if(tries > 1){
            if (collidecheck == true){
                yield return new WaitForSeconds(1);
                button.SetActive(true);
                tries -= 1;
                tryText.text = tries.ToString("0");
                ball.transform.position = reset.position;
                ball.transform.rotation = reset.rotation;
            }      
        } 
    }   


    // public override bool Equals(object obj){
    //     return obj is ResetBall ball &&
    //     base.Equals(obj) &&
    //     /EqualityComparer<void>.Default.Equals(Updatbody, ball.Updatbody);
    // }
}
