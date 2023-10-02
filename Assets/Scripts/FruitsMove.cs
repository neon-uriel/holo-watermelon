using System.Collections;
using System.Collections.Generic;
using System.Threading;

//using System.Numerics;
using UnityEngine;

public class FruitsMove : MonoBehaviour
{
    private Vector2 t_pos;
    private Vector2 spawn_pos;
    public Rigidbody2D rd;
    //[SerializeField]GameObject gameOverUI;
    public bool isClick = false;
    private float fruitRad;
    // Update is called once per frame
    void Start()
    {
        rd = this.GetComponent<Rigidbody2D>();
        rd.gravityScale = 1.0f;
        spawn_pos = GameObject.FindGameObjectWithTag("spawner").GetComponent<GameManager>().spawn_pos;
        fruitRad = GetComponent<CircleCollider2D>().radius;
    }
    void Update()
    {
        if (!isClick)
        {
            float adjust = 2.88f;
            t_pos = GetMouseWorldPos();
            Vector2 targetPos = t_pos * new Vector2(1.0f, 0.0f) + spawn_pos;
            if (targetPos.x > adjust - fruitRad)
            {
                targetPos = new Vector2(adjust - fruitRad, 0f) + spawn_pos;
            }
            else if (targetPos.x < adjust * -1 + fruitRad)
            {
                targetPos = new Vector2(adjust * -1 + fruitRad, 0f) + spawn_pos;
            }
            transform.position = targetPos;
        }
        if (Input.GetMouseButtonUp(0))
        {
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
    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     Destroy(this);
    // }
}
