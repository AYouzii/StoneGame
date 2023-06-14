using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotButton : MonoBehaviour
{
    public int count_number;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        count_number = 0; //rrrr
        spriteRenderer.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            NumberIncrement();
        }

        spriteRenderer.sprite = sprites[count_number];
    }

    public void NumberIncrement()
    {
        count_number++;
        if (count_number > 8) {
            count_number = 0;
        }
                
    }

    

}
