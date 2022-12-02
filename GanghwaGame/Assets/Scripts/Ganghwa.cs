using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganghwa : MonoBehaviour
{
    public TotalScript total;
    public int rand;
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.Find("Total").GetComponent<TotalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        rand = Random.Range(1, 10001);
        if(rand <= total.Range)
        {
            total.Lv++;
        }
    }
        
}
