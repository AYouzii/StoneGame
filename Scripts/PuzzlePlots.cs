using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzlePlots : MonoBehaviour
{
    //第一个谜题结束后的剧情文本
    private float chars_per_second = 0.13f;//打字间隔时间
    private string words;
    private float time_count;//计时器
    public TMP_Text plots_text;//文本
    private int curr_pos = 0;//打字光标位置
    private const int PLOTS_NUM = 7;
    private string[] plots_arr = new string[PLOTS_NUM];
    public Button next_button;
    public Button cross_button;
    private bool isActive = false;//标志位，表示文本是否在显示
    private int plots_arr_index = 0;//文本数组索引
    public Sprite[] background_arr;
    public Image background;
    private int[] back_index_arr = {0, 1, 0, 0, 0, 0, 1};

    public Rock rock;

    // Start is called before the first frame update
    void Start()
    {
        time_count = 0;
        // chars_per_second = Mathf.Max(0.2f, chars_per_second);

        plots_arr[0] = "……";
        plots_arr[1] = "前辈？其后又发生何事？";
        plots_arr[2] = "其后……";
        plots_arr[3] = "经年累月，往昔良友相继辞世。身边人如花谢落，更替不绝，而吾因精怪之体，不老不死。";
        plots_arr[4] = "千百年间，吾容貌姓名百变，始终孑然独自，倍加怅惘。";
        plots_arr[5] = "遂不复游历尘世，还原本来面目，独守此屋中，不觉，又已百年。";
        plots_arr[6] = "前辈……";
        background.sprite = background_arr[back_index_arr[0]];


        plots_text.text = plots_arr[0];
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
            plots_arr_index = PLOTS_NUM - 1;
            rock.gameObject.SetActive(true);
            gameObject.SetActive(false);
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
