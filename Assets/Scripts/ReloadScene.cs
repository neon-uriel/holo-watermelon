using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public CustomButton button;
    void Update(){
        button.onClickCallback = ()=> {  
            ReloadSceneFunc();  
        };  
    }
    public void ReloadSceneFunc()
        {
            // 現在のシーンの名前を取得
            string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            
            // 現在のシーンを再読み込み
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneName);
        }
}
