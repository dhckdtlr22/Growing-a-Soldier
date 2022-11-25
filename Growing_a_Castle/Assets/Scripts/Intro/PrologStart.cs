using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologStart : MonoBehaviour
{
    public GameObject img;
    public CameraTr Tr;
    public GameObject Bg;
    public bool IsProlog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Prolog()
    {
        if (IsProlog == false)
        {
            Bg.SetActive(true);
            Tr.IsTake = 0;
        }
    }
}
