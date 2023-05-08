using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ChucNang : MonoBehaviour
{
    public void ChoiMoi()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Thoat()
    {
        Application.Quit();
    }
    public void HuongDan()
    {
        SceneManager.LoadScene(6);
    }
    public void ThoatRaMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ThoatHuongDan()
    {
        SceneManager.LoadScene(0);
    }
   
    public void CaiDat()
    {
        SceneManager.LoadScene(7);
    }
    public void ThoatCaiDat()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void TiepTuc()
    {
        SceneManager.LoadScene(1);
        
    }
    public void QuaManLevel3()
    {
        SceneManager.LoadScene(3);

    }
    public void QuaManLevel4()
    {
        SceneManager.LoadScene(4);

    }
    public void QuaManLevel5()
    {
        SceneManager.LoadScene(5);

    }
    public void QuaManLevel2()
    {
        SceneManager.LoadScene(2);

    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        UIManager.Instance.dialog3.Show(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.dialog3.Show(true);
       
    }
}
    
