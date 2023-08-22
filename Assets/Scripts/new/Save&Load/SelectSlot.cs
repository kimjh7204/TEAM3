using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class SelectSlot : MonoBehaviour
{
    public TextMeshProUGUI[] slotText;
    bool[] savefile = new bool[3];
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = "SAVED";
                

            }
            else
            {
                slotText[i].text = "EMPTY";
            }
        }
        
        DataManager.instance.DataClear();
    }

        
    
    void Update()
    {
        
    }

    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
        
        //1. 저장데이터가 있을 때
        if (savefile[number])
        { 
            DataManager.instance.LoadData();
            GoGame();
        }
        //2. 저장데이터가 없을 때

        else
        {
            GoGame();
        }
    }

    public void GoGame()
    {
        {
            if (!savefile[DataManager.instance.nowSlot])
                DataManager.instance.SaveData();
        }
        SceneManager.LoadScene(1);
    }
    
}
