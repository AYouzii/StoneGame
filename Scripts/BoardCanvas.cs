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
    public TMP_Text[] text_arr;

    private int m_image_index = 0;
    private int m_text_index = 0;
    private const int IMAGE_NUM = 4;
    private const int TEXT_NUM = 4;
    // Start is called before the first frame update
    void Start()
    {
		image.sprite = sprites[0];
       
        right_button = GameObject.Find("Right_Button").GetComponent<Button>();
        right_button.onClick.AddListener(RightButtonClick);

		left_button = GameObject.Find("Left_Button").GetComponent<Button>();
		left_button.onClick.AddListener(LeftButtonClick);

        text_arr[0] = GameObject.Find("m_Text0").GetComponent<TMP_Text>();
        text_arr[0].text = "棋谱";

        text_arr[1] = GameObject.Find("m_Text1").GetComponent<TMP_Text>();
        text_arr[1].text = "炮二平五   马8进7";
        text_arr[1].alpha = 0;

        text_arr[2] = GameObject.Find("m_Text2").GetComponent<TMP_Text>();
        text_arr[2].text = "马二进三   車9平8";
        text_arr[2].alpha = 0;

        text_arr[3] = GameObject.Find("m_Text3").GetComponent<TMP_Text>();
        text_arr[3].text = "车一平二   马2进3";
        text_arr[3].alpha = 0;

        // gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sprites[m_image_index];
    }

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
}
