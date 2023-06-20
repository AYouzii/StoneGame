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

    // Start is called before the first frame update
    void Start()
    {
		image.sprite = sprites[0];
       
        right_button.onClick.AddListener(RightButtonClick);

		left_button.onClick.AddListener(LeftButtonClick);

        cross_button.onClick.AddListener(CrossButtonClick);

        text_arr[0].text = "单马必胜单士";
        text_arr[0].alpha = 1;

        text_arr[1].text = "<color=#000000>马</color>六退五";
        text_arr[1].alpha = 0;

        text_arr[2].text = "将6进1   <color=#000000>马</color>五进七";
        text_arr[2].alpha = 0;

        text_arr[3].text = "士5进4   <color=#000000>马</color>七退六";
        text_arr[3].alpha = 0;

        gameObject.SetActive(true);//初始状态，画布不显示

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
      Close();
    }

    //关闭画布，外部调用
    public void Close()
    {
      gameObject.SetActive(false);
      GameObject.Find("Player").GetComponent<Player>().movable = true;
    }

    //打开画布，外部调用
    public void Open()
    {
        gameObject.SetActive(true);
    }

}
