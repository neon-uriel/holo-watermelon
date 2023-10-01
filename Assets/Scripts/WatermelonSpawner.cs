using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 t_pos;
    public Vector2 spawn_pos;
    Vector3 mousePos, worldPos;

    public GameObject[] fruitObjects = new GameObject[10]; 
    [SerializeField]GameObject gameOverUI;
    private bool isGameOver = false;
    void Start()
    {
        SpawnFluits();
    }
    void Update()
    {
        isGameOver = gameOverUI.activeSelf;
        if (Input.GetMouseButtonUp(0)){
            StartCoroutine(DelayCoroutine());
        }
    }
    void SpawnFluits(){
        if (!isGameOver){
            t_pos = GetMouseWorldPos();
            Vector2 spPos = t_pos * new Vector2(1.0f,0.0f) + spawn_pos;
            int rnd = Random.Range(0, 4);
            Instantiate(fruitObjects[rnd], spPos, Quaternion.identity);
        }
    }
    private Vector2 GetMouseWorldPos()
    {
        Vector2 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private IEnumerator DelayCoroutine()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(0.5f);
        SpawnFluits();
    }
}