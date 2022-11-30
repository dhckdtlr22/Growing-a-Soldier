using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BUTZip : MonoBehaviour
{
    
    public Enhance enhance;
    public SwordState swordState;

    public Image Sword;
 
    public float a;
    
    public GameObject Enhance;
    public GameObject inventory;
    public GameObject Shop;
    
    private void Start()
    {
     
        Sword = GameObject.Find("SwordImage").GetComponent<Image>();
        swordState = GameObject.Find($"{Sword.sprite.name}").GetComponent<SwordState>();
       
        inventory.SetActive(false);
        Shop.SetActive(false);
        Enhance.SetActive(false);
    }
    
    public void GoEnhance()
    {
        Enhance.SetActive(true);
        inventory.SetActive(false);
        Shop.SetActive(false);
        
    }
    public void GoInventory()
    {
        Enhance.SetActive(false);
        inventory.SetActive(true);
        Shop.SetActive(false);

    }
    public void GoShop()
    {
        Enhance.SetActive(false);
        inventory.SetActive(false);
        Shop.SetActive(true) ;
    }


    public void EnhanceBUt()
    {

        enhance.PlayEnhance();
        
    }
        
    
    public void GoMine()
    {
        SceneManager.LoadScene("Mine");
    }
    public void GoDunGeon()
    {
        SceneManager.LoadScene("DunGeon");
    }





}
