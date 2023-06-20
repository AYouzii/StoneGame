using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseCanvas : MonoBehaviour
{
    public Button quit_button;//退出游戏按钮
    public Button continue_button;//继续游戏按钮
    
    // Start is called before the first frame update
    void Start()
    {
        //为按钮添加事件函数
        quit_button.onClick.AddListener(QuitButtonClick);
        continue_button.onClick.AddListener(ContinueButtonClick);
        //画布初始不可见
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void QuitButtonClick()
    {
        Application.Quit();//按下退出游戏按钮时，程序关闭
    }

    private void ContinueButtonClick()
    {
        gameObject.SetActive(false);//继续游戏则关闭画布
    }
}
