using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class FruitsMove : MonoBehaviour
{
    private Vector2 t_pos;
    private Vector2 spawn_pos = new Vector2(0.0f,4.0f);
    public Rigidbody2D rd;
    [SerializeField]GameObject gameOverUI;
    public bool isClick = false;
    // Update is called once per frame
    void Start(){
        rd = this.GetComponent<Rigidbody2D>();
        rd.gravityScale = 1.0f;
    }
    void Update()
    {
        if(!isClick){
            t_pos = GetMouseWorldPos();
            transform.position = t_pos * new Vector2(1.0f,0.0f) + spawn_pos;
            rd.simulated = false;
        }
        if (Input.GetMouseButtonUp(0)){
            rd.simulated = true;
            isClick = true;
            Destroy(GetComponent<FruitsMove>());
        }

    }
    private Vector2 GetMouseWorldPos()
    {
        Vector2 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
