using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change()
    {
        if(Camera.activeSelf == true)
        {
            Camera.SetActive(false);
        }
        else
        {
            Camera.SetActive(true);
        }
       
    }
}
