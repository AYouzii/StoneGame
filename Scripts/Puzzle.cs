using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    // Puzzle: 管理六块拼图碎片的类
    public GameObject[] puzzles; //拼图数组
    private const int PUZZLE_NUM = 6;//拼图数量
    private const float RATIO_X_Y = 1.185f;//每块拼图长宽比
    private const float RATIO_X_Z = 10.667f;//每块拼图的长度与高度之比

    // Start is called before the first frame update
    void Start()
    {
        puzzles[0].name = "puzzle1";

        puzzles[1].name = "puzzle2";

        puzzles[2].name = "puzzle3";

        puzzles[3].name = "puzzle4";

        puzzles[4].name = "puzzle5";

        puzzles[5].name = "puzzle6";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
