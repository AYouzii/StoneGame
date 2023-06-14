using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public BoardCanvas board_canvas;
    // Start is called before the first frame update
    void Start()
    {
        board_canvas.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
