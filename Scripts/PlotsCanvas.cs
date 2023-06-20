using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlotsCanvas : MonoBehaviour
{
    //第一个谜题结束后的剧情文本
    private float chars_per_second = 0.13f;//打字间隔时间
    private string words;
    private float time_count;//计时器
    public TMP_Text plots_text;//文本
    private int curr_pos = 0;//打字光标位置
    public string[] plots_arr;
    private const int PLOTS_NUM = 7;
    private int[] back_index_arr = {0, 1, 0, 0, 1, 0, 0};
    public Button next_button;
    public Button cross_button;
    private bool isActive = false;//标志位，表示文本是否在显示
    private int plots_arr_index = 0;//文本数组索引
    public Sprite[] background_arr; 
    public Image background;

    // Start is called before the first frame update
    void Start()
    {
        time_count = 0;

        plots_text.text = plots_arr[0];
        background.sprite = background_arr[back_index_arr[0]];
        words = plots_text.text;
        plots_text.text = "";
        isActive = true;
        next_button.onClick.AddListener(NextPage);
        cross_button.onClick.AddListener(CrossButtonClick);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //文字逐个显示
        if (isActive) {
            time_count += Time.deltaTime;
            if (time_count > chars_per_second) {
                time_count = 0;
                curr_pos++;
                plots_text.text = words.Substring(0, curr_pos);

                if (curr_pos >= words.Length) {
                    //显示完成
                    isActive = false;
                    time_count = 0;
                    curr_pos = 0;
                    plots_text.text = words;
                }
            }
        }
        
    }

    private void NextPage() 
    {
        plots_arr_index++;
        if (plots_arr_index > PLOTS_NUM - 1) {
            plots_arr_index = 0;
            Close();
        }
        else {
            plots_text.text = plots_arr[plots_arr_index];
            background.sprite = background_arr[back_index_arr[plots_arr_index]];
            words = plots_text.text;
            plots_text.text = "";
            isActive = true;
            time_count = 0;
            curr_pos = 0;
        }

    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void Open() {
        gameObject.SetActive(true);
    }

    private void CrossButtonClick()
    {
        gameObject.SetActive(false);
    }
}
