using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PuzzleCanvas : MonoBehaviour
{
    public Button[] buttons;//六张拼图对应的按钮
    public Button cross_button;//画布关闭按钮
    private int[] button_image_index_arr = new int[6]; //表示按钮与图片索引对应关系的数组，用来标记拼图是否在正确位置
    public Sprite[] sprites;//拼图对应的图画
    private const int BUTTON_NUM = 6;
    public Hand hand;// 玩家的手持物
    private Dictionary<string, int> Name_Index_Dic = new Dictionary<string, int>();//拼图名称与图片索引的字典
    private bool unlocked = false;//谜题成功解开的标志
    private bool isGiven = false;//是否已经给予玩家道具

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(ButtonClick1);
        buttons[1].onClick.AddListener(ButtonClick2);
        buttons[2].onClick.AddListener(ButtonClick3);
        buttons[3].onClick.AddListener(ButtonClick4);
        buttons[4].onClick.AddListener(ButtonClick5);
        buttons[5].onClick.AddListener(ButtonClick6);

        cross_button.onClick.AddListener(CrossButtonClick);

        Name_Index_Dic.Add("puzzle1", 0);
        Name_Index_Dic.Add("puzzle2", 1);
        Name_Index_Dic.Add("puzzle3", 2);
        Name_Index_Dic.Add("puzzle4", 3);
        Name_Index_Dic.Add("puzzle5", 4);
        Name_Index_Dic.Add("puzzle6", 5);

        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ButtonClick1()
    {
    if (hand.GetItem().tag == "Puzzle" && !unlocked && hand.GetItem() != null) {
            //首先判断手持物的标签是否为Puzzle，然后读取手持物的名字，根据字典转换为图片数组索引
            string itemName = hand.GetItem().GetComponent<ItemSlot>().slotItem.name;
            button_image_index_arr[0] = Name_Index_Dic[itemName];
            buttons[0].GetComponent<Image>().sprite = sprites[Name_Index_Dic[itemName]];
            buttons[0].GetComponent<Image>().color = Color.white;//初始状态为黑色，为显示图片，需要设置成白色
            CheckPuzzles();
        }
    }

    private void ButtonClick2()
    {
    if (hand.GetItem().tag == "Puzzle" && !unlocked && hand.GetItem() != null) {
            string itemName = hand.GetItem().GetComponent<ItemSlot>().slotItem.name;
            button_image_index_arr[1] = Name_Index_Dic[itemName];
            buttons[1].GetComponent<Image>().sprite = sprites[Name_Index_Dic[itemName]];
            buttons[1].GetComponent<Image>().color = Color.white;
            CheckPuzzles();
        }
    }

    private void ButtonClick3()
    {
    if (hand.GetItem().tag == "Puzzle" && !unlocked && hand.GetItem() != null) {
            string itemName = hand.GetItem().GetComponent<ItemSlot>().slotItem.name;
            button_image_index_arr[2] = Name_Index_Dic[itemName];
            buttons[2].GetComponent<Image>().sprite = sprites[Name_Index_Dic[itemName]];
            buttons[2].GetComponent<Image>().color = Color.white;
            CheckPuzzles();
        }
    }

    private void ButtonClick4()
    {
        if (hand.GetItem().tag == "Puzzle" && ! unlocked && hand.GetItem()!=null) {
            string itemName = hand.GetItem().GetComponent<ItemSlot>().slotItem.name;
            button_image_index_arr[3] = Name_Index_Dic[itemName];
            buttons[3].GetComponent<Image>().sprite = sprites[Name_Index_Dic[itemName]];
            buttons[3].GetComponent<Image>().color = Color.white;
            CheckPuzzles();
        }
    }

    private void ButtonClick5()
    {
    if (hand.GetItem().tag == "Puzzle" && !unlocked && hand.GetItem() != null) {
            string itemName = hand.GetItem().GetComponent<ItemSlot>().slotItem.name;
            button_image_index_arr[4] = Name_Index_Dic[itemName];
            buttons[4].GetComponent<Image>().sprite = sprites[Name_Index_Dic[itemName]];
            buttons[4].GetComponent<Image>().color = Color.white;
            CheckPuzzles();
        }
    }

    private void ButtonClick6()
    {
    if (hand.GetItem().tag == "Puzzle" && !unlocked && hand.GetItem() != null) {
            string itemName = hand.GetItem().GetComponent<ItemSlot>().slotItem.name;
            button_image_index_arr[5] = Name_Index_Dic[itemName];
            buttons[5].GetComponent<Image>().sprite = sprites[Name_Index_Dic[itemName]];
            buttons[5].GetComponent<Image>().color = Color.white;
            CheckPuzzles();
        }
    }

    private void CrossButtonClick()
    {
        gameObject.SetActive(false);
    }

    private void CheckPuzzles()
    {
        //检查谜题是否成功解开
        bool isComplete = true;
        for (int i = 0; i < BUTTON_NUM; i++) {
            if (button_image_index_arr[i] != i) {
                isComplete = false;
                break;
            }
        }

        if (isComplete) {
            unlocked = true;
            if (! isGiven) {
                GiveObject();
                isGiven = true;
                gameObject.SetActive(false);//隐藏画布

            }
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
        
    }

    public void Close()
    {
        gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<Player>().movable = true;
    }

  public void GiveObject()
    {
        //给予玩家物品
    }
}
