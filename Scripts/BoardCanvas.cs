using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardCanvas : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;
    public Button right_button;
	public Button left_button;
    public Button cross_button;
    public TMP_Text[] text_arr;

    private int m_image_index = 0;
    private int m_text_index = 0;
    private const int IMAGE_NUM = 4;
    private const int TEXT_NUM = 4;

    public TMP_Text plots; //画布上显示的文本
    public TextAsset[] plot_text_arr; //剧情文本存放在Assets文件夹下的文本文档里
    public Button next_button;
    private int plots_index;
    private const int MAX_PLOTS_INDEX = 2;
    // Start is called before the first frame update
    void Start()
    {
		image.sprite = sprites[0];
        image.gameObject.SetActive(false);
       
        right_button.onClick.AddListener(RightButtonClick);
        right_button.gameObject.SetActive(false);

		left_button.onClick.AddListener(LeftButtonClick);
        left_button.gameObject.SetActive(false);

        cross_button.onClick.AddListener(CrossButtonClick);
        cross_button.gameObject.SetActive(false);

        text_arr[0].text = "棋谱";
        text_arr[0].alpha = 0;

        text_arr[1].text = "炮二平五   <color=#000000>马</color>8进7";
        text_arr[1].alpha = 0;

        text_arr[2].text = "<color=#000000>马</color>二进三   車9平8";
        text_arr[2].alpha = 0;

        text_arr[3].text = "车一平二   <color=#000000>马</color>2进3";
        text_arr[3].alpha = 0;

        gameObject.SetActive(true);//初始状态，画布不显示

        plots.text = plot_text_arr[0].text;
        plots.color = Color.black;
        
        next_button.onClick.AddListener(NextPage);


    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sprites[m_image_index];
    }

    //右按钮事件函数
    private void RightButtonClick()
    {
        m_image_index++;
        m_text_index++;
        if (m_image_index > IMAGE_NUM - 1) {
            m_image_index = IMAGE_NUM - 1;
        }

        if (m_text_index > TEXT_NUM - 1) {
            m_text_index = TEXT_NUM - 1;
        }

        text_arr[m_text_index].alpha = 1;
    }

    //左按钮事件函数
	private void LeftButtonClick() 
	{
		m_image_index--;
		if (m_image_index < 0) {
			m_image_index = 0;
		}

		if (m_text_index > 0) {
			text_arr[m_text_index].alpha = 0;
		}
		
		m_text_index--;
		if (m_text_index < 0) {
			m_text_index = 0;
		}
	}

    //关闭按钮事件函数
    private void CrossButtonClick()
    {
        gameObject.SetActive(false);
    }

    //关闭画布，外部调用
    public void Close()
    {
        gameObject.SetActive(false);
    }

    //打开画布，外部调用
    public void Open()
    {
        gameObject.SetActive(true);
    }

    private void NextPage()
    {
        plots_index++;
        if (plots_index > MAX_PLOTS_INDEX - 1) {
            SecondStageInit();
            plots_index = 0;
        }
        plots.text = plot_text_arr[plots_index].text;
    }
    
    private void SecondStageInit()
    {
        //剧情结束，开启解谜阶段

        image.gameObject.SetActive(true);
        right_button.gameObject.SetActive(true);
        left_button.gameObject.SetActive(true);
        cross_button.gameObject.SetActive(true);
        text_arr[0].alpha = 1;
        text_arr[1].alpha = 1;
        text_arr[2].alpha = 1;
        text_arr[3].alpha = 1;

        plots.gameObject.SetActive(false);
        next_button.gameObject.SetActive(false);
    }
}
