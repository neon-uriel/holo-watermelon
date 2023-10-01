using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]GameObject gameOverUI;
    private bool isStillTriggering = false; 
    void OnTriggerStay2D(Collider2D collision){
        Debug.Log(collision.GetComponent<Rigidbody2D>().velocity.y);
        if(collision.GetComponent<Rigidbody2D>().velocity.y >= 0.0f){
            if(isStillTriggering){
                gameOverUI.SetActive(true);
            }
            StartCoroutine(DelayCoroutine());
        }else{
            isStillTriggering = false;
        }
    }
    private IEnumerator DelayCoroutine(){
        yield return new WaitForSeconds(0.5f);
        isStillTriggering = true;
    }
}
