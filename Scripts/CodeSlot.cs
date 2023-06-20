using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSlot : MonoBehaviour
{
    public Slot[] slots;
    public PlotsCanvas plotsCanvas;
    private bool unlocked;//是否解锁
    private bool isGiven;//是否给予玩家物品
    private bool isShown;//是否已经展示剧情
    // Start is called before the first frame update
    void Start()
    {
        unlocked = false;
        isGiven = false;
        isShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (! unlocked) {
            Check();
        }
    }

    private void Check()
    {
        if (unlocked) {
            return;
        }
        //判断密码是否正确
        if (slots[0].obj_index == 5 &&
            slots[1].obj_index == 4 &&
            slots[2].obj_index == 4 &&
            slots[3].obj_index == 6 &&
            slots[4].obj_index == 6 &&
            slots[5].obj_index == 5) { 
                unlocked = true;
                if (! isGiven) {
                    GiveObject();
                    isGiven = true;
                }
                if (! isShown) {
                    plotsCanvas.Open();
                    isShown = true;
                }
            }
    }

    private void GiveObject() 
    {
        //给予玩家道具
    }
}
