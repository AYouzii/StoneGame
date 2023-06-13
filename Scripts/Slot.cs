using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public SlotButton[] buttons;
    private bool unlock;
    // Start is called before the first frame update
    void Start()
    {
        unlock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttons[0].count_number == 2) {
            unlock = true;
        }

        if (unlock) {
            Debug.Log("Unlock!");
        }

    }
}
