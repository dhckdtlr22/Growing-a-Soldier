using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonZip : MonoBehaviour
{
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public void next()
    {
        if(Player.PlayerHP > 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("DunGeon");

        }
        
    }
}
