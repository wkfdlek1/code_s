using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoootManager : MonoBehaviour
{
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;
    public GameObject num7;//그녀와 갈등
    public GameObject num8;//마지막 게임

    public GameObject end1;
    public GameObject end2;
    public GameObject end3;

    public GameObject ark;

    private int root;

    // Start is called before the first frame update
    //setRoot별로 버튼을 setActive 할것
    void Awake()
    {
        root = PlayerPrefs.GetInt("setRoot");
        if (root < 1) num2.SetActive(false);
        if (root < 2) num3.SetActive(false);
        if (!PlayerPrefs.HasKey("ark") || PlayerPrefs.GetInt("ark") == 0) ark.SetActive(false);
        if (root < 4 || (!PlayerPrefs.HasKey("egoistic") || PlayerPrefs.GetInt("egoistic") == 0))
        {
            num4.SetActive(false);
        }
        if(root < 6) num5.SetActive(false);
        end1.SetActive(false);
        if (PlayerPrefs.HasKey("end1Root") && PlayerPrefs.GetInt("end1Root") > 0) end1.SetActive(true); 
        if(root < 8) num6.SetActive(false);
        num7.SetActive(false);
        if(PlayerPrefs.GetInt("loadValue") == 0)
        {
            if(root >= 10) num7.SetActive(true);
        }
        else
        {
            if(PlayerPrefs.HasKey("end2Root") || PlayerPrefs.HasKey("end3Root")) num7.SetActive(true);
        }
        end2.SetActive(false);
        if (PlayerPrefs.HasKey("end2Root")&&PlayerPrefs.GetInt("end2Root")>0) end2.SetActive(true);
        end3.SetActive(false);
        if (PlayerPrefs.HasKey("end3Root") && PlayerPrefs.GetInt("end3Root") > 0) end3.SetActive(true);
        num8.SetActive(false);
        if(PlayerPrefs.GetInt("loadValue") == 0)
        {
            if (root >= 12 && PlayerPrefs.GetInt("isLastBattle") == 1)
            {
                num8.SetActive(true);
            }
        }
        else
        {
            if (PlayerPrefs.HasKey("end3Root") && PlayerPrefs.GetInt("end3Root") > 0)
            {
                num8.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick1()
    {
        if(PlayerPrefs.GetInt("loadValue") > 0)
        {
            PlayerPrefs.SetInt("setRoot", 0);
            SceneManager.LoadScene("StoryScene");
        }
        else if(PlayerPrefs.GetInt("setRoot") == 0)
        {
            PlayerPrefs.SetInt("setRoot", 1);
            SceneManager.LoadScene("StoryScene");
        }
    }
    //그냥 스토리 첫 승리 후 이거 없애
    public void OnClick2()
    {
        if (PlayerPrefs.GetInt("loadValue") > 0)
        {
            PlayerPrefs.SetInt("setRoot", 1);
            SceneManager.LoadScene("StoryScene");
        }
        else if(PlayerPrefs.GetInt("setRoot") == 2)
        {
            SceneManager.LoadScene("StoryScene");
        }
    }
    //2차전 이전 스토리
    public void OnClick3()
    {
        if (PlayerPrefs.GetInt("loadValue") > 0)
        {
            PlayerPrefs.SetInt("setRoot", 3);
            SceneManager.LoadScene("StoryScene");
        }
        else if (PlayerPrefs.GetInt("setRoot") == 2)
        {
            PlayerPrefs.SetInt("setRoot", 3);
            SceneManager.LoadScene("StoryScene");
        }
    }
    //그들
    public void OnClick4()
    {
        if (PlayerPrefs.GetInt("loadValue") > 0)
        {
            PlayerPrefs.SetInt("setRoot", 5);
            SceneManager.LoadScene("StoryScene");
        }
        else if (PlayerPrefs.GetInt("setRoot") == 4)
        {
            PlayerPrefs.SetInt("setRoot", 5);
            SceneManager.LoadScene("StoryScene");
        }
    }
    //여기부터 만드셈()
    public void OnClick5()
    {
        if (PlayerPrefs.GetInt("loadValue") > 0)
        {
            PlayerPrefs.SetInt("setRoot", 7);
            SceneManager.LoadScene("StoryScene");
        }
        else if (PlayerPrefs.GetInt("setRoot") == 6)
        {
            PlayerPrefs.SetInt("setRoot", 7);
            SceneManager.LoadScene("StoryScene");
        }
    }
    public void OnClick6()
    {
        if (PlayerPrefs.GetInt("loadValue") > 0)
        {
            PlayerPrefs.SetInt("setRoot", 9);
            SceneManager.LoadScene("StoryScene");
        }
        else if (PlayerPrefs.GetInt("setRoot") == 8)
        {
            PlayerPrefs.SetInt("setRoot", 9);
            SceneManager.LoadScene("StoryScene");
        }
    }
    public void OnClick7()
    {
        if (PlayerPrefs.GetInt("loadValue") > 0)
        {
            PlayerPrefs.SetInt("setRoot", 11);
            SceneManager.LoadScene("StoryScene");
        }
        else if (PlayerPrefs.GetInt("setRoot") == 10)
        {
            PlayerPrefs.SetInt("setRoot", 11);
            SceneManager.LoadScene("StoryScene");
        }
    }
    public void OnClick8()
    {
        if (PlayerPrefs.GetInt("loadValue") > 0)
        {
            PlayerPrefs.SetInt("setRoot", 13);
            SceneManager.LoadScene("StoryScene");
        }
        else if (PlayerPrefs.GetInt("setRoot") == 12)
        {
            PlayerPrefs.SetInt("setRoot", 13);
            SceneManager.LoadScene("StoryScene");
        }
    }

    public void End1Click()
    {
        PlayerPrefs.SetInt("setRoot", 200);
        SceneManager.LoadScene("StoryScene");
    }
    public void End2Click()
    {
        PlayerPrefs.SetInt("setRoot", 300);
        SceneManager.LoadScene("StoryScene");
    }
    public void End3Click()
    {
        PlayerPrefs.SetInt("setRoot", 400);
        SceneManager.LoadScene("StoryScene");
    }
}
