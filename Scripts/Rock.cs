using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public RockCanvas rockCanvas;
    // Start is called before the first frame update
    void Start()
    {
        rockCanvas.Close();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCanvas()
    {
        rockCanvas.Open();
    }
}
