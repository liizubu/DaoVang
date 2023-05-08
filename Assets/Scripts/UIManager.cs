using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   public static UIManager Instance;

    public Text TimeText;


    public Dialog dialog1;
    public Dialog dialog2;
    public Dialog dialog3;
    

    //private void Start()
    //{
    //    TimeText = GameObject.Find("TimeText").GetComponent<Text>();
    //}
    private void Awake()
    {
        MakeSingleton();
    }
    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTimeText(string content)
    {
        if(TimeText)
        {
            TimeText.text = content;
        }
    }
   
    

   
}
