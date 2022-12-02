using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButMgr : MonoBehaviour
{
    public GameObject GanghwaPop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoGanghwa()
    {
        GanghwaPop.SetActive(true);
    }
    public void Back()
    {
        GanghwaPop.SetActive(false);
    }    
}
