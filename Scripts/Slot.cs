using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject[] numbers = new GameObject[9];
    public int obj_index = 0;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Instantiate(numbers[obj_index]);
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition = new Vector3(0,0.1f,0);
        obj.transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        GameObject.Destroy(obj);
        obj_index++;
        if (obj_index > 8) {
            obj_index = 0;
        }
        obj = GameObject.Instantiate(numbers[obj_index]);
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition = new Vector3(0,0.1f,0);
        obj.transform.localScale = Vector3.one;
    }
}
