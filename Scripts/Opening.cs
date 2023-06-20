using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Opening : MonoBehaviour
{
    private float chars_per_second = 0.1f;//打字间隔时间
    private string words;//文本缓存
    private float time_count;//计时器
    public TMP_Text plots_text;//剧情文本
    public Button game_start;//游戏开始选项
    public Button game_exit;//游戏结束选项
    private int curr_pos = 0;//打字光标位置
    private const int PLOTS_NUM = 13;//剧情段落数量
    private string[] plots_arr = new string[PLOTS_NUM];//储存剧情文本的数组
    public Button next_button;//翻页按钮
    public Button game_info;//游戏信息页面按钮
    private bool isActive = false;//标志位，表示文本是否在显示
    private int plots_arr_index = 0;//文本数组索引
    public Image black_background;//黑色背景
    public Image opening_image;//开场图片
    public Player player;//玩家对象
    public TMP_Text InfoText1;//信息文本1
    public TMP_Text InfoText2;//信息文本2
    public Image InfoBackground;//显示信息页面的背景
    public Button return_button;

    // Start is called before the first frame update
    void Start()
    {
        time_count = 0;
        // chars_per_second = Mathf.Max(0.2f, chars_per_second);
        plots_arr[0] = "我乃民间一作家，专记各地奇闻轶事。\n";
        plots_arr[1] = "象棋名手李仲隐晚年自传中提到，其年少时常与棋友访天虞山一石姓棋士。\n";
        plots_arr[2] = "“彼之天资卓颖，气质举止，非凡人之矣。吾年老之际闻邻县又出一天才少年，一招一式竟与吾所识石兄异曲同工。亦或石兄诚为仙人所在，言之未可知也。”\n";
        plots_arr[3] = "除了李仲隐，还有数十位朝代不同的名手，或多或少都曾提及天虞山的天才棋士，对其描述也如出一辙。";
        plots_arr[4] = "神秘若仙人的石姓棋士？我自然不能错过这绝佳素材。";
        plots_arr[5] = "我在天虞山探寻数日，但一无所获。沮丧之时，却偶入云深处一庭院——";
        plots_arr[6] = "怪石：何人来此扰吾清净？";
        plots_arr[7] = "我：（竟然是会说话的石头？也许我找对了地方，此处正有仙人之迹。）";
        plots_arr[8] = "我：晚辈听闻此山中有一石姓棋士，特来寻访讨教，冒昧闯入实属无心。";
        plots_arr[9] = "怪石：呵，此地无有下棋之人，汝误来之处，宜速行返。";
        plots_arr[10] = "我：前辈在此山中已久，想来对这棋手也有所耳闻，不知您可否指引一二？";
        plots_arr[11] = "怪石：……";
        plots_arr[12] = "怪石：吾在此寂寥百年，已不记人间事。也许知晓，也许不知。汝果真欲知，助吾寻回往事则可。";

        //初始化文本内容和缓存，设置显示模式
        plots_text.text = plots_arr[0];
        words = plots_text.text;
        plots_text.text = "";
        isActive = true;

        //将与剧情文本显示无关的项取消显示
        next_button.onClick.AddListener(NextPage);
        next_button.gameObject.SetActive(false);

        game_start.onClick.AddListener(GameStart);
        game_start.gameObject.SetActive(false);

        game_exit.onClick.AddListener(GameExit);
        game_exit.gameObject.SetActive(false);

        game_info.onClick.AddListener(ShowGameInfo);
        game_info.gameObject.SetActive(false);

        return_button.onClick.AddListener(ReturnToTitle);
        return_button.gameObject.SetActive(false);

        black_background.gameObject.SetActive(true);
        opening_image.gameObject.SetActive(false);
        InfoBackground.gameObject.SetActive(false);

        InfoText1.gameObject.SetActive(false);
        InfoText2.gameObject.SetActive(false);

        player.gameObject.SetActive(false);
        
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
                    //显示完成,初始化
                    isActive = false;
                    time_count = 0;
                    curr_pos = 0;
                    plots_text.text = words;
                    next_button.gameObject.SetActive(true);
                }
            }
        }
        
    }

    private void NextPage() 
    {
        plots_arr_index++;
        if (plots_arr_index > PLOTS_NUM - 1) {
            plots_arr_index = 0;
            isActive = false;
            //文本显示完成
            plots_text.gameObject.SetActive(false);
            next_button.gameObject.SetActive(false);
            game_start.gameObject.SetActive(true);
            game_exit.gameObject.SetActive(true);
            game_info.gameObject.SetActive(true);
            black_background.gameObject.SetActive(false);
            opening_image.gameObject.SetActive(true);
        }
        else {
            plots_text.text = plots_arr[plots_arr_index];
            words = plots_text.text;
            plots_text.text = "";
            isActive = true;
            curr_pos = 0;
            time_count = 0;
        }

    }

    private void GameStart()
    {
        gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }

    private void GameExit()
    {
        Application.Quit();
    }

    private void ShowGameInfo()
    {
        InfoBackground.gameObject.SetActive(true);
        InfoText1.gameObject.SetActive(true);
        InfoText2.gameObject.SetActive(true);
        return_button.gameObject.SetActive(true);
    }

    private void ReturnToTitle()
    {
        InfoBackground.gameObject.SetActive(false);
        InfoText1.gameObject.SetActive(false);
        InfoText2.gameObject.SetActive(false);
        return_button.gameObject.SetActive(false);
    }

}
