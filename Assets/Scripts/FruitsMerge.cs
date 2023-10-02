using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
public class FruitsMerge : MonoBehaviour
{
    //public Rigidbody2D rd;
    private string myTagName;
    public GameObject nextFruitObjects;
    public GameObject particleObject;
    private static int once = 1;
    private GameManager gm;
    private GameObject wm;
    // Update is called once per frame
    void Start()
    {
        //rd = this.GetComponent<Rigidbody2D>();
        myTagName = this.gameObject.tag;
        once = 1;
        gameObject.GetComponent<Animation>().Play();
        wm = GameObject.FindGameObjectWithTag("spawner");
        gm = wm.GetComponent<GameManager>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("OnCollisionEnter2D");
        if (col.gameObject.CompareTag(myTagName))
        {
            if (once == 1)
            {
                gm.sumPoints += GetMyPoints(myTagName);
                Debug.Log(gm.sumPoints);
                Instantiate(particleObject, col.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                // 新しいマージされたオブジェクトを生成します。
                Vector2 pre = (transform.position + col.transform.position) / 2f;
                GameObject mergedObject = Instantiate(nextFruitObjects, pre, Quaternion.identity);
                Destroy(mergedObject.transform.GetComponent<FruitsMove>());
                //Debug.Log(mergedObject);
                mergedObject.GetComponent<Animation>().Play();
                mergedObject.GetComponent<Rigidbody2D>().simulated = true;
                mergedObject.GetComponent<AudioSource>().Play();
                once = 0;
            }
            Destroy(transform.gameObject);
            Destroy(col.transform.gameObject);
        }
    }
    int GetMyPoints(string tag)
    {
        int pt = 0;
        if (tag == "0")
        {
            pt = 1;
        }
        else if (tag == "1")
        {
            pt = 2;
        }
        else if (tag == "2")
        {
            pt = 4;
        }
        else if (tag == "3")
        {
            pt = 8;
        }
        else if (tag == "4")
        {
            pt = 16;
        }
        else if (tag == "5")
        {
            pt = 32;
        }
        else if (tag == "6")
        {
            pt = 64;
        }
        else if (tag == "7")
        {
            pt = 128;
        }
        else if (tag == "8")
        {
            pt = 256;
        }
        else if (tag == "9")
        {
            pt = 512;
        }
        else if (tag == "10")
        {
            pt = 1024;
        }
        else
        {
            pt = 0;
        }
        return pt;
    }
}