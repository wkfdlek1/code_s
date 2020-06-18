using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public MainTalkManager mainTalkManager;

    //이미지
    public Image lozest0_1;
    public Image lozest;
    public Image keian;
    public Image auresia;
    public Image polen;
    public Image reima;
    public Image there;
    public Image lastScene;

    public GameObject talkPanel;
    public Text nameTxt;
    public Text storyTxt;

    public bool isStoryAction;
    public int gameStage;

    private float time;
    private int round; //진행되는 talkData
    private int tmp; //talkData내의 대화 포인터

    //스토리 라인의 번호
    private int rootScene;

    void ThreeCharaColor()
    {
        Color color1 = lozest.color;
        Color color2 = keian.color;
        Color color3 = auresia.color;
        color1.a = 1.0f;
        lozest.color = color1;
        color2.a = 1.0f;
        keian.color = color2;
        color3.a = 1.0f;
        auresia.color = color3;
    }

    //스토리 진행
    public void StoryAction()
    {
        if (time >= 1.0f)//시작 1초 뒤
        {
            isStoryAction = true; //스토리 시작
        }
        //스토리 진행하는 코드
        if(isStoryAction && time >= 1.0f)
        {
            //첫번째 씬에서
            if (rootScene == 0)
            {
                if(round == 1)
                {
                    Color color = lozest0_1.color;
                    color.a = 1.0f;
                    lozest0_1.color = color;
                }
                else if (round == 2)
                {
                    Color color = lozest0_1.color;
                    color.a = 0.0f;
                    lozest0_1.color = color;
                }
                //다 끝나면
                else if (round == 3)
                {
                    SceneManager.LoadScene("root");
                }
            }
            //전투 전
            else if (rootScene == 1)
            {
                if(round == 11)
                {
                    ThreeCharaColor();
                }
                else if(round == 12)
                {
                    PlayerPrefs.SetInt("battle", 0);
                    SceneManager.LoadScene("battleInterface");
                }
            }
            //1스테이지 전투 후
            else if(rootScene == 2)
            {
                if(round == 12)
                {
                    ThreeCharaColor();
                }
                //한번만 말함
                if (round == 13)
                {
                    SceneManager.LoadScene("root");
                }
            }
            //2 전투 전
            else if(rootScene == 3)
            {
                ThreeCharaColor();
                if(round == 102)
                {
                    Color color = polen.color;
                    color.a = 1.0f;
                    polen.color = color;
                }
                else if(round == 103)
                {
                    PlayerPrefs.SetInt("battle", 1);
                    SceneManager.LoadScene("battleInterface");
                }
            }
            //진 루트
            else if(rootScene == 4)
            {
                if (round == 110)
                {
                    ThreeCharaColor();
                }
                else if(round == 111)
                {
                    //nonThreeCharaColor();
                }
                else if(round == 112)
                {
                    SceneManager.LoadScene("root");
                }
            }
            //그들의 상황 진적
            else if(rootScene == 5)
            {
                if(round == 200)
                {
                    Color color1 = lozest.color;
                    Color color2 = keian.color;
                    Color color3 = auresia.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color2.a = 0.9f;
                    keian.color = color2;
                    color3.a = 0.9f;
                    auresia.color = color3;
                    Color color = reima.color;
                    color.a = 1.0f;
                    reima.color = color;
                }
                if(round == 201)
                {
                    PlayerPrefs.SetInt("battle", 2);
                    SceneManager.LoadScene("battleInterface");
                }
            }
            else if (rootScene == 6)
            {
                if(round == 210)
                {
                    Color color1 = lozest.color;
                    Color color2 = keian.color;
                    Color color3 = auresia.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color2.a = 0.7f;
                    keian.color = color2;
                    color3.a = 0.8f;
                    auresia.color = color3;
                }
                else if(round == 211)
                {
                    SceneManager.LoadScene("root");
                }
            }
            //혼선
            else if (rootScene == 7)
            {
                if (round == 300)
                {
                    Color color1 = lozest.color;
                    Color color2 = keian.color;
                    Color color3 = auresia.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color2.a = 0.6f;
                    keian.color = color2;
                    color3.a = 0.8f;
                    auresia.color = color3;
                }
                else if(round == 301)
                {
                    Color color = there.color;
                    color.a = 0.8f;
                    there.color = color;
                }
                else if(round == 302)
                {
                    PlayerPrefs.SetInt("battle", 3);
                    SceneManager.LoadScene("battleInterface");
                }
            }
            else if(rootScene == 8)
            {
                if(round == 310)
                {
                    Color color1 = lozest.color;
                    Color color2 = keian.color;
                    Color color3 = auresia.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color2.a = 0.5f;
                    keian.color = color2;
                    color3.a = 0.6f;
                    auresia.color = color3;
                    Color color = there.color;
                    color.a = 1.0f;
                    there.color = color;
                }
                else if(round == 312)
                {
                    SceneManager.LoadScene("root");
                }
            }
            //5차전 이전
            else if(rootScene == 9)
            {
                if(round == 400)
                {
                    Color color1 = lozest.color;
                    Color color2 = keian.color;
                    Color color3 = auresia.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color2.a = 0.4f;
                    keian.color = color2;
                    color3.a = 0.7f;
                    auresia.color = color3;
                }
                if(round == 402)
                {
                    PlayerPrefs.SetInt("battle", 4);
                    SceneManager.LoadScene("battleInterface");
                }
            }
            //5차전 이후(정 루트)
            else if(rootScene == 10)
            {
                if(round == 410)
                {
                    Color color1 = lozest.color;
                    Color color2 = keian.color;
                    Color color3 = auresia.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color2.a = 0.3f;
                    keian.color = color2;
                    color3.a = 0.7f;
                    auresia.color = color3;
                }
                if(round == 412)
                {
                    SceneManager.LoadScene("root");
                }
            }
            //6차전 이전
            else if(rootScene == 11)
            {
                if(round == 501)
                {
                    Color color1 = lozest.color;
                    Color color3 = auresia.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color3.a = 0.7f;
                    auresia.color = color3;
                }
                else if(round == 503)
                {
                    PlayerPrefs.SetInt("battle", 5);
                    SceneManager.LoadScene("battleInterface");
                }
            }
            //6차전 이후
            else if(rootScene == 12)
            {
                if(round == 510)
                {
                    Color color1 = lozest.color;
                    Color color3 = polen.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color3.a = 1.0f;
                    polen.color = color3;
                }
                if(round == 512)
                {
                    PlayerPrefs.SetInt("isLastBattle", 1);
                    SceneManager.LoadScene("root");
                }
            }
            //라스트 이전
            else if(rootScene == 13)
            {
                if(round == 601)
                {
                    Color color1 = lozest.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                }
                else if(round == 603)
                {
                    PlayerPrefs.SetInt("battle", 6);
                    PlayerPrefs.SetInt("isLastBattle", 0);
                    SceneManager.LoadScene("battleInterface");
                }
            }
            //거절 루트
            else if(rootScene == 100)
            {
                if (round == 9999)
                {
                    Color color1 = lozest.color;
                    Color color2 = keian.color;
                    Color color3 = auresia.color;
                    color1.a = 1.0f;
                    lozest.color = color1;
                    color2.a = 0.7f;
                    keian.color = color2;
                    color3.a = 0.8f;
                    auresia.color = color3;
                }
                else if(round == 10001)
                {
                    PlayerPrefs.SetInt("setRoot", 6);
                    SceneManager.LoadScene("root");
                }
            }
            //200이후는 ending 1~3으로 마지막 round일 경우 Ending 씬으로 이동
            else if(rootScene == 200)
            {
                ThreeCharaColor();
                if(round == 903)
                {
                    PlayerPrefs.SetInt("Ending", 1);
                    PlayerPrefs.SetInt("end1Root", 1);
                    SceneManager.LoadScene("Ending");
                }
            }
            else if(rootScene == 300)
            {
                if (round == 911)
                {
                    Color color = lozest.color;
                    color.a = 1.0f;
                    lozest.color = color;
                }
                else if(round == 913)
                {
                    PlayerPrefs.SetInt("Ending", 2);
                    PlayerPrefs.SetInt("end2Root", 1);
                    SceneManager.LoadScene("Ending");
                }
            }
            else if (rootScene == 400)
            {
                if(round == 922)
                {
                    Color color = lastScene.color;
                    color.a = 1.0f;
                    lastScene.color = color;
                }
                else if (round == 923)
                {
                    PlayerPrefs.SetInt("Ending", 3);
                    PlayerPrefs.SetInt("end3Root", 1);
                    SceneManager.LoadScene("Ending");
                }
            }
            if (Input.GetMouseButtonDown(0)) Talk(round, tmp++);
        }
        talkPanel.SetActive(isStoryAction);
    }

    void Awake(){
        //초기값은 스토리 진행이 안됐으므로 false
        isStoryAction = false;

        tmp = 0;
        time = 1.0f;
        rootScene = PlayerPrefs.GetInt("setRoot");
        talkPanel.SetActive(isStoryAction);
        gameStage = 0;
        if (rootScene == 0)
        {
            round = 0;
        }
        else if (rootScene == 1)
        {
            round = 11;
        }
        //첫 배틀 후
        else if (rootScene == 2)
        {
            round = 12;
        }
        //2차전 이전
        else if (rootScene == 3)
        {
            round = 100;
        }
        //2차전 후(진 루트)
        else if (rootScene == 4)
        {
            round = 110;
        }
        //부정 루트
        else if (rootScene == 100)
        {
            round = 9999;
        }
        //3차전(진루트 전투 전)
        else if (rootScene == 5)
        {
            round = 200;
        }
        //3차전 후
        else if (rootScene == 6)
        {
            round = 210;
        }
        //4차전(혼선) 전
        else if (rootScene == 7)
        {
            round = 300;
        }
        else if (rootScene == 8)
        {
            round = 310;
        }
        //5차전 이전
        else if(rootScene == 9)
        {
            round = 400;
        }
        else if(rootScene == 10)
        {
            round = 410;
        }
        else if (rootScene == 11)
        {
            round = 500;
        }
        else if (rootScene == 12)
        {
            round = 510;
        }
        else if (rootScene == 13)
        {
            round = 600;
        }

        //4차전 후 바로 엔딩, 5차전 엔딩
        else if (rootScene == 200)
        {
            round = 901;
        }
        //엔딩2
        else if(rootScene == 300)
        {
            round = 911;
        }
        //엔딩3
        else if(rootScene == 400)
        {
            round = 921;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        StoryAction();
    }

    void Talk(int id, int index)
    {
        string talkData;
        talkData = mainTalkManager.GetTalk(id, index);

        //해당 talkData가 마지막일 경우 패널을 순간 없애고 다음 텍스트(round + 1)를 불러온다
        if(talkData == null)
        {
            storyTxt.text = "";
            isStoryAction = false;
            round++;
            tmp = 0;
            time = 0.0f;
            return;
        }
        else storyTxt.text = talkData;
    }
}
