using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Vector2 t_pos;
    public Vector2 spawn_pos;
    Vector3 mousePos, worldPos;
    public int sumPoints;
    public GameObject[] fruitObjects = new GameObject[10];
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject scoreUI;
    public TextMeshProUGUI PointsText;
    private bool isGameOver = false;
    public int nextFruit;
    private GameObject currentFruits;
    private int waiting = 0;
    //private int durCoroutine = 0;
    void Start()
    {
        sumPoints = 0;
        SpawnFluits(0);
        nextFruit = Random.Range(0, 3);
    }
    void Update()
    {
        if(isGameOver){
            Destroy(scoreUI);
        }
        if (currentFruits == null)
        {
            SpawnFluits(nextFruit);
            nextFruit = Random.Range(0, 5);
        }
        PointsText.text = "" + sumPoints;
        isGameOver = gameOverUI.activeSelf;
        if (Input.GetMouseButtonUp(0) && waiting == 0 && !isGameOver)
        {   
            waiting++;
            //StartCoroutine(DelayCoroutine());
            // SpawnFluits(nextFruit);
            // nextFruit = Random.Range(0, 5);
            StartCoroutine(DelayCoroutine());
        }
    }
    void SpawnFluits(int fruit)
    {
        if (!isGameOver)
        {
            t_pos = GetMouseWorldPos();
            Vector2 spPos = t_pos * new Vector2(1.0f, 0.0f) + spawn_pos;
            currentFruits = Instantiate(fruitObjects[fruit], spPos, Quaternion.identity);
        }
    }
    private Vector2 GetMouseWorldPos()
    {
        Vector2 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnFluits(nextFruit);
        nextFruit = Random.Range(0, 5);
        waiting = 0;
    }
}