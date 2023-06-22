using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public BoardCanvas board_canvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenBoardCanvas()
    {
        //棋盘调用UI的开启函数
        board_canvas.Open();
    }
}
