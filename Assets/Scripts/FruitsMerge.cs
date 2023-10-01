using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class FruitsMerge : MonoBehaviour
{
    //public Rigidbody2D rd;
    private string myTagName;
    public GameObject nextFruitObjects;
    public GameObject particleObject;
    private static int once = 1;
    // Update is called once per frame
    void Start(){
        //rd = this.GetComponent<Rigidbody2D>();
        myTagName = this.gameObject.tag;
        once = 1;
        gameObject.GetComponent<Animation>().Play();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("OnCollisionEnter2D");
        if (col.gameObject.CompareTag(myTagName))
        {
            if (once == 1)
            {
                Instantiate(particleObject, col.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                // 新しいマージされたオブジェクトを生成します。
                GameObject mergedObject = Instantiate(nextFruitObjects, col.transform.position, Quaternion.identity);
                Debug.Log(mergedObject);
                mergedObject.GetComponent<Animation>().Play();
                Vector2 pre = (transform.position + col.transform.position) / 2f;
                Destroy(mergedObject.transform.GetComponent<FruitsMove>());
                mergedObject.GetComponent<AudioSource>().Play();
                once = 0;
            }
            Destroy(transform.gameObject);
            Destroy(col.transform.gameObject);
        }
    }
}
