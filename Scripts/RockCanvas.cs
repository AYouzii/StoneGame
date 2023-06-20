using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockCanvas: MonoBehaviour
{
    //第一个谜题结束后的剧情文本
    private float chars_per_second = 0.13f;//打字间隔时间
    private string words;
    private float time_count;//计时器
    public TMP_Text plots_text;//文本
    private int curr_pos = 0;//打字光标位置
    private const int PLOTS_NUM = 11;
    private string[] plots_arr = new string[PLOTS_NUM];
    public Button next_button;
    public Button cross_button;
    private bool isActive = false;//标志位，表示文本是否在显示
    private int plots_arr_index = 0;//文本数组索引
    public Sprite[] background_arr;
    public Image background;
    private int[] back_index_arr = {0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0};

    // Start is called before the first frame update
    void Start()
    {
        time_count = 0;
        // chars_per_second = Mathf.Max(0.2f, chars_per_second);

        plots_arr[0] = "……";
        plots_arr[1] = "吾，即尔所求之棋士也。";
        plots_arr[2] = "吾虛度多岁月，然凡人寿命有限，知己之情终将断绝。迨至终局，吾竟一无所获。";
        plots_arr[3] = "前辈……此言差矣。";
        plots_arr[4] = "汝何出此言？";
        plots_arr[5] = "前辈不知，指引我来此的正是名手李仲隐在其自传中提及您的文字。";
        plots_arr[6] = "此段情谊，于前辈而言，不过漫长岁月之区区数十年。于李仲隐之辈凡人而言，却是烟花般灿烂的时光。";
        plots_arr[7] = "（沉默不语，似在思考）";
        plots_arr[8] = "身为精怪，于前辈而言，凡人的寿命的确太短。但是，因为相遇而产生的缘分并不会就此断绝，而是以新的方式传承下去。";
        plots_arr[9] = "前辈您看，不正是因为李仲隐前辈和您的情谊，我才来到了天虞山，才有了现在这段前辈与我的缘分吗？";
        plots_arr[10] = "（释然而笑）亦甚有理。";

        background.sprite = background_arr[back_index_arr[0]];


        plots_text.text = plots_arr[0];
        words = plots_text.text;
        plots_text.text = "";
        isActive = true;
        next_button.onClick.AddListener(NextPage);
        cross_button.onClick.AddListener(CrossButtonClick);
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
