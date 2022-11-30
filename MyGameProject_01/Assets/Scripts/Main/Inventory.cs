using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Button b;
    Image image;
    public Image changeimage;

    private void Start()
    {
        
        b = GetComponent<Button>();
        image = GetComponent<Image>();
    }
    public void Update()
    {
        b.onClick.AddListener(change);
    }
    public void change()
    {
        if(image.sprite.name != "UISprite")
        {
            Player.SwordName = $"{image.sprite.name}";
            changeimage.sprite = image.sprite;
            Player.Swordimage = image;
            Player.sword = GameObject.Find($"{image.sprite.name}").GetComponent<SwordState>();
        }
       
    }
}
