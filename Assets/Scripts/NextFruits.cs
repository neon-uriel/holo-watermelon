using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextFruits : MonoBehaviour
{
    public Sprite[] fruitSprites = new Sprite[10];
    private Image image;
    private GameManager gm;
    private GameObject wm;
    void Start()
    {
        wm = GameObject.FindGameObjectWithTag("spawner");
        gm = wm.GetComponent<GameManager>();
        image = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        image.sprite = fruitSprites[gm.nextFruit];
    }
}
