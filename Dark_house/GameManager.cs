using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //배틀중 특정상황이면 단서 획득하게 딕셔너리에 add시킬 것
    public TalkManager talkManager;

    public Text explanText;
    public Text nameText;
    public Text playTxt;
    public Text battleTxt;

    public Text lvText;
    public Text expText;
    public Text hpText;

    public Text stageNum1;
    public Text stageNum2;
    public Text stageNum3;
    public Text stageNum4;
    public Text stageNum5;
    public Text stageNum6;
    public Text stageNum7;
    public Text stageNum8;
    public Text stageNum9;
    public Text stageNum10;

    public Text provisoNum1;
    public Text provisoNum2;
    public Text provisoNum3;
    public Text provisoNum4;
    public Text provisoNum5;
    public Text provisoNum6;
    public Text provisoNum7;
    public Text provisoNum8;
    public Text provisoNum9;

    public Image enemy1;
    public Image enemy2;
    public Image enemy3;
    public Image enemy4;
    public Image enemy5;
    public Image enemy6;
    public Image enemy7;

    public bool isAction;
    public bool bAttackAvailable; //가능한지는 단서가 해당 공격분기에서 가능한가
    public bool bAttackTime;//지금이 공격 시간인가?

    public int gameStage; //스토리에 따라 진행
    public int gameQuart; //스토리내 분기(공격시 분기를 나타냄)
    public int gameCnt; //게임 진행 카운트

    //공격 버튼 눌렀을때 true
    public bool bAttackBtn;
    
    private bool bSkill;//스킬 공격일 경우
    private bool bProviso;//단서 공격일 경우

    private bool isUntilCnt;//카운트 증가 활성화시 true
    private string msg;

    //배틀에 이기고 졌을때 true
    private bool bLose;
    private bool bWin;

    private bool btnDown;

    //스테이지, 단서 선택
    private int stagePointer;
    private int provisoPointer;

    //현재 스토리 루트 정보 저장
    private int stageRoot;

    private float time;

    //player
    public int hp;
    public int exp;
    public int lv;


    //배틀부
    public void BattleTextAction()
    {
        //이겼을때 스토리로 이동
        if (bWin)
        {
            bAttackAvailable = false;
            bSkill = false;
            if (time >= 2.0f)
            {
                explanText.text = "";
                SceneManager.LoadScene("StoryScene");
            }
        }
        //졌을때 초기화
        if (bLose && time >= 2.0f)
        {
            PlayerPrefs.SetInt("setRoot", 0);
            PlayerPrefs.SetInt("LV", 1);
            PlayerPrefs.SetInt("HP", 5);
            PlayerPrefs.SetInt("EXP", 0);
            PlayerPrefs.SetInt("loadValue", 0);
            SceneManager.LoadScene("mainScene");
        }
        if (hp == 0 || hp == 150)
        {
            stageRoot = 899;
            bLose = true;
            gameQuart = stageRoot;
            BattleMsg((gameStage * 1000) + gameQuart, gameCnt); 
        }
        else if (bAttackTime && bAttackBtn)
        {
            bAttackBtn = false;
            bAttackTime = false;
            isUntilCnt = true;
            //공격이 유효하다면
            //보통 승리 코드는 quart = 900, 0스테이지 제외
            
            //스킬 사용시 패배
            if (bSkill)
            {
                bSkill = false;
                //스테이지가 0이었을때
                if (gameStage == 0)
                {
                    //승리 코딩(경험치)
                    exp += 10;
                    explanText.text = "??에게 100의 데미지를 입혔다\n??가 죽었다\n경험치 10 획득";
                    PlayerPrefs.SetInt("LV", lv);
                    PlayerPrefs.SetInt("HP", hp);
                    PlayerPrefs.SetInt("EXP", exp);
                    PlayerPrefs.SetInt("setRoot", 2);
                }
                //마지막 배틀이었을 때는 hp를 0으로
                else if (gameStage == 6)
                {
                    //패배 코드
                    hp = 0;
                }
                //일반 전투
                else
                {
                    lv = 100;
                    hp = 150;
                    explanText.text = "LV가 100이 되었다";
                    //살인루트 코딩
                    time = 0.0f;
                }
                gameQuart = 999;
                BattleMsg((gameStage * 1000) + gameQuart, gameCnt);
            }
            //스킬이 아니면서 공격이 됐을 경우
            else if (bAttackAvailable)
            {
                bool fail = false; //실패가 아님
                bAttackAvailable = false;
                //0스테이지는 스킬빼고는 다 실패
                if (gameStage == 0) fail = true;
                else if (gameStage == 1)
                {
                    //root는 스토리 가지가 어떻게 뻗어나가는지
                    if (stageRoot == 0)
                    {
                        if (stagePointer == 1 && provisoPointer == 6)
                        {
                            gameQuart = 100;
                            stageRoot = gameQuart;
                        }
                        else if (stagePointer == 1 && provisoPointer == 4)
                        {
                            gameQuart = 101;
                            stageRoot = gameQuart;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 100)
                    {
                        if (stagePointer == 1 && provisoPointer == 0)
                        {
                            gameQuart = 200;
                            stageRoot = gameQuart;
                        }
                        else if (stagePointer == 1 && provisoPointer == 1)
                        {
                            gameQuart = 203;
                            stageRoot = gameQuart;
                            PlayerPrefs.SetInt("setRoot", 4);//4가 정 루트일 예정
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("ark", 0);
                            PlayerPrefs.SetInt("egoistic", 1);
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 200)
                    {
                        if (stagePointer == 1 && provisoPointer == 7)
                        {
                            //방주 루트
                            gameQuart = 300;
                            stageRoot = gameQuart;
                            exp += 7;
                            explanText.text = "거래가 성립됐다\n폴른을 물리쳤다\n경험치 7 획득";
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("setRoot", 4);//4가 정 루트일 예정
                            PlayerPrefs.SetInt("ark", 1);
                            PlayerPrefs.SetInt("egoistic", 1);
                        }
                        else if (stagePointer == 1 && provisoPointer == 8)
                        {
                            //부정 루트
                            gameQuart = 399;
                            stageRoot = gameQuart;
                            explanText.text = "폴른을 물리쳤다";
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("setRoot", 100);
                            PlayerPrefs.SetInt("egoistic", 0);
                            PlayerPrefs.SetInt("ark", 0);
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 101)
                    {
                        if (stagePointer == 0 && provisoPointer == 2)
                        {
                            stageRoot = 201;
                            gameQuart = stageRoot;
                        }
                        else fail = true; //공격이 먹히지 않을 경우 실패로 한다
                    }
                    else if (stageRoot == 201)
                    {
                        if (stagePointer == 1 && provisoPointer == 7)
                        {
                            stageRoot = 301;
                            gameQuart = stageRoot;
                            exp += 4;
                            explanText.text = "거래가 성립됐다\n폴른을 물리쳤다\n경험치 4 획득";
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("setRoot", 4);//4가 정 루트일 예정
                            PlayerPrefs.SetInt("ark", 0);
                            PlayerPrefs.SetInt("egoistic", 1);
                        }
                        else if (stagePointer == 1 && provisoPointer == 8)
                        {
                            //부정 루트
                            gameQuart = 302;
                            stageRoot = gameQuart;
                            explanText.text = "폴른을 물리쳤다";
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("setRoot", 100);//100가 거절루트
                            PlayerPrefs.SetInt("ark", 0);
                            PlayerPrefs.SetInt("egoistic", 0);
                        }
                        else fail = true;
                    }
                }
                else if (gameStage == 2)
                {
                    //root는 스토리 가지가 어떻게 뻗어나가는지
                    if (stageRoot == 0)
                    {
                        if (stagePointer == 0 && provisoPointer == 1)
                        {
                            stageRoot = 100;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 100)
                    {
                        if (stagePointer == 0 && provisoPointer == 4)
                        {
                            stageRoot = 200;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 200)
                    {
                        if (stagePointer == 0 && provisoPointer == 0)
                        {
                            stageRoot = 300;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if(stageRoot == 300)
                    {
                        fail = false;
                    }
                }
                else if (gameStage == 3)
                {
                    if (stageRoot == 0)
                    {
                        if (stagePointer == 0 && provisoPointer == 2)
                        {
                            stageRoot = 1;
                            gameQuart = 1;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 1)
                    {
                        if ((stagePointer == 0 && provisoPointer == 0) || (stagePointer == 3 && provisoPointer == 0))
                        {
                            stageRoot = 2;
                            gameQuart = 2;
                        }
                    }
                    else if (stageRoot == 2)
                    {
                        if (stagePointer == 0 && provisoPointer == 3)
                        {
                            stageRoot = 100;
                            gameQuart = stageRoot;
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("setRoot", 200);//200은 엔딩1
                        }
                        else if (stagePointer == 3 && provisoPointer == 3)
                        {
                            stageRoot = 3;
                            gameQuart = stageRoot;
                            exp += 5;
                            explanText.text = "???와 일시적으로 동료가 되었다\n경험치가 5 올랐다";
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("setRoot", 8);
                        }
                        else fail = true;
                    }
                }
                else if (gameStage == 4)
                {
                    if (stageRoot == 0)
                    {
                        if (stagePointer == 1 && provisoPointer == 7)//긍정. 엔딩 루트
                        {
                            stageRoot = 101;
                            gameQuart = stageRoot;
                        }
                        else if (stagePointer == 1 && provisoPointer == 8)//부정. 정 루트
                        {
                            stageRoot = 1;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 1)
                    {
                        if (stagePointer == 3 && provisoPointer == 0)
                        {
                            stageRoot = 2;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 2)
                    {
                        if (stagePointer == 0 && provisoPointer == 3)//에너지가 정루트다
                        {
                            stageRoot = 3;
                            gameQuart = stageRoot;
                            exp += 7;
                            explanText.text = "경험치가 7 올랐다";
                            PlayerPrefs.SetInt("setRoot", 10);
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("HP", hp);
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 101)
                    {
                        if (stagePointer == 4 && (provisoPointer == 1 || provisoPointer == 2))
                        {
                            stageRoot = 102;
                            gameQuart = stageRoot;
                        }
                        else if (stagePointer == 0 && provisoPointer == 0)
                        {
                            stageRoot = 102;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 102)
                    {
                        if (stagePointer == 3 && provisoPointer == 3)
                        {
                            stageRoot = 103;
                            gameQuart = stageRoot;
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("setRoot", 200);
                        }
                        else fail = true;
                    }
                }
                else if (gameStage == 5)
                {
                    if (stageRoot == 0)
                    {
                        if (stagePointer == 5)
                        {
                            if (provisoPointer == 0)
                            {
                                stageRoot = 1;
                                gameQuart = stageRoot;
                            }
                            else if (provisoPointer == 2)
                            {
                                stageRoot = 101;
                                gameQuart = stageRoot;
                            }
                            else fail = true;
                        }
                    }
                    else if (stageRoot == 1)
                    {
                        if (stagePointer == 4 && provisoPointer == 1)//케이안
                        {
                            stageRoot = 2;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 2)
                    {
                        if (stagePointer == 0 && provisoPointer == 3)//에너지
                        {
                            stageRoot = 3;
                            gameQuart = stageRoot;
                            if (PlayerPrefs.HasKey("egoistic") && PlayerPrefs.HasKey("ark"))
                            {
                                if (PlayerPrefs.GetInt("egoistic") > 0 && PlayerPrefs.GetInt("ark") > 0)
                                {
                                    exp += 8;
                                    explanText.text = "경험치가 8 올랐다";
                                    PlayerPrefs.SetInt("LV", lv);
                                    PlayerPrefs.SetInt("HP", hp);
                                    PlayerPrefs.SetInt("EXP", exp);
                                    PlayerPrefs.SetInt("setRoot", 12);
                                }
                                else
                                {
                                    PlayerPrefs.SetInt("LV", lv);
                                    PlayerPrefs.SetInt("HP", hp);
                                    PlayerPrefs.SetInt("EXP", exp);
                                    PlayerPrefs.SetInt("setRoot", 300);
                                }
                            }
                            else
                            {
                                PlayerPrefs.SetInt("LV", lv);
                                PlayerPrefs.SetInt("HP", hp);
                                PlayerPrefs.SetInt("EXP", exp);
                                PlayerPrefs.SetInt("setRoot", 300);
                            }
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 101)
                    {
                        if (stagePointer == 0 && provisoPointer == 3)
                        {
                            stageRoot = 102;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 102)
                    {
                        if (stagePointer == 4 && provisoPointer == 3)
                        {
                            stageRoot = 103;
                            gameQuart = stageRoot;
                            PlayerPrefs.SetInt("LV", lv);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("setRoot", 300);
                        }
                        else fail = true;
                    }
                }
                else if (gameStage == 6)
                {
                    if (stageRoot == 0)
                    {
                        if (stagePointer == 6 && provisoPointer == 0)
                        {
                            stageRoot = 1;
                            gameQuart = stageRoot;
                        }
                        else if (stagePointer == 5 && provisoPointer == 0)//연구소를 바로 하면 진리가 아니다
                        {
                            stageRoot = 101;
                            gameQuart = stageRoot;
                        }
                        else if (stageRoot == 6 && provisoPointer == 1)//동굴
                        {
                            stageRoot = 201;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 1)//진리(진실)
                    {
                        if (stagePointer == 2 && provisoPointer == 0)//3 : 300
                        {
                            stageRoot = 2;
                            gameQuart = stageRoot;
                        }
                        else if (stagePointer == 5 && provisoPointer == 0)//연구소.진리가 아니다
                        {
                            stageRoot = 101;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 2)//3 : 300
                    {
                        if ((stagePointer == 4 && provisoPointer == 3) || (stagePointer == 0 && provisoPointer == 3))//형태, 에너지
                        {
                            stageRoot = 3;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 3)//형태, 에너지
                    {
                        if (stagePointer == 4 && (provisoPointer == 1 || provisoPointer == 2))//케이안 혹은 아우레시아
                        {
                            stageRoot = 4;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 4)//케이안 혹은 아우레시아 
                    {
                        if (stagePointer == 4 && provisoPointer == 0)
                        {
                            stageRoot = 5;
                            gameQuart = stageRoot;
                            exp += 10;
                            explanText.text = "exp를 10 획득했다";
                            PlayerPrefs.SetInt("isLastBattle", 1);
                            PlayerPrefs.SetInt("Lv", lv);
                            PlayerPrefs.SetInt("EXP", exp);
                            PlayerPrefs.SetInt("HP", hp);
                            PlayerPrefs.SetInt("setRoot", 400);//진엔딩! 와! 샌즈!
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 101)
                    {
                        if (stagePointer == 5 && provisoPointer == 2) //옷
                        {
                            stageRoot = 102;
                        }
                        else if ((stagePointer == 4 && provisoPointer == 3) || (stagePointer == 0 && provisoPointer == 3))//형태, 에너지
                        {
                            stageRoot = 112;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 102)//옷
                    {
                        if (stagePointer >= 0 && stagePointer <= 6)
                        {
                            if (provisoPointer >= 0 && provisoPointer <= 9)
                            {
                                stageRoot = 990;
                                gameQuart = stageRoot;
                            }
                            else fail = true;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 112)//형태, 에너지
                    {
                        if (stagePointer >= 0 && stagePointer <= 6)
                        {
                            if (provisoPointer >= 0 && provisoPointer <= 9)
                            {
                                stageRoot = 990;
                                gameQuart = stageRoot;
                            }
                            else fail = true;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 201)
                    {
                        if (stagePointer == 0 && provisoPointer == 3)//에너지
                        {
                            stageRoot = 202;
                            gameQuart = stageRoot;
                        }
                        else fail = true;
                    }
                    else if (stageRoot == 202)
                    {
                        if (stagePointer >= 0 && stagePointer <= 6)
                        {
                            if (provisoPointer >= 0 && provisoPointer <= 9)
                            {
                                stageRoot = 990;
                                gameQuart = stageRoot;
                            }
                            else fail = true;
                        }
                        else fail = true;
                    }
                }
                //fail은 공격이
                if (fail)
                {
                    gameQuart = 998;//998이 실패시
                    if (hp > 0) hp--;
                    if (hp == 0)
                    {
                        gameQuart = 899;//패배시 899
                        BattleMsg((gameStage * 1000) + gameQuart, gameCnt);
                        explanText.text = "♥가 " + hp.ToString() + "으로 줄어들었다\n게임에서 졌다";
                    }
                    else
                    {
                        BattleMsg((gameStage * 1000) + gameQuart, gameCnt);
                        explanText.text = "♥가 " + hp.ToString() + "으로 줄어들었다";
                    }
                }
                else
                {
                    BattleTextAction();
                }
            }
            
        }
        else //어택 준비중이 아닐 경우
        {
            BattleMsg((gameStage * 1000) + gameQuart, gameCnt);
        }
    }

    //실제 배틀 메시지를 받아오는 메소드
    void BattleMsg(int id, int index)
    {
        if (!isUntilCnt) return;

        msg = talkManager.GetTalkData(id, index);
        battleTxt.text = msg;
        //첫번째 스테이지의 경우 단서 획득하는 장면을 위한 코드
        if(id == 0)
        {
            if (index == 10 || index == 11 || index == 15 || index == 24 || index == 28)
                //index별로 단서 획득
                Stage1Selector();
        }

        if (talkManager.GetTalkData(id,index + 1) == null)
        {
            int isId = id % 1000;
            if (isId == 899) { bLose = true; time = 0.0f; }
            //패배코드
            if (isId == 999)
            {
                //첫 스테이지에 한에서 승리
                if (gameStage == 0) {
                    bWin = true;
                    time = 0.0f;
                }
                //첫번째 스테이지가 아니면 패배
                else
                {
                    bLose = true;
                }
            }
            //스테이지별 승리코드
            if (gameStage == 1)
            {
                if (isId == 300 || isId == 203 || isId == 399)
                {
                    bWin = true;
                    time = 0.0f;
                }
            }
            else if (gameStage == 2)
            {
                if (isId == 300)//데미지 들어간 코드
                {
                    exp += 5;
                    stageRoot = 301;
                    gameQuart = stageRoot;
                    explanText.text = "?가 죽었다.  경험치 5를 얻었다";
                    PlayerPrefs.SetInt("LV", lv);
                    PlayerPrefs.SetInt("HP", hp);
                    PlayerPrefs.SetInt("EXP", exp);
                    PlayerPrefs.SetInt("setRoot", 6);
                    bWin = true;
                    time = 0.0f;
                }
                
            }
            else if (gameStage == 3)
            {
                if (isId == 3 || isId == 100)
                {
                    bWin = true;
                    time = 0.0f;
                }
            }
            else if (gameStage == 4)
            {
                if(isId == 3 || isId == 103)
                {
                    bWin = true;
                    time = 0.0f;
                }
            }
            else if (gameStage == 5)
            {
                if (isId == 3 || isId == 103)
                {
                    bWin = true;
                    time = 0.0f;
                }
            }
            else if (gameStage == 6)
            {
                if(stageRoot == 5)
                {
                    bWin = true;
                    time = 0.0f;
                }
                if(stageRoot == 990)
                {
                    bLose = true;
                    time = 0.0f;
                }
            }
            gameCnt = 0;
            isUntilCnt = false;
            bAttackTime = true;
            return;
        }
        gameCnt++;
    }

    void Awake()
    {
        bAttackTime = false;
        bAttackBtn = false;

        explanText.text = "";
        bLose = false;
        bWin = false;

        gameStage = PlayerPrefs.GetInt("battle");
        gameQuart = 0;
        gameCnt = 0;
        bAttackAvailable = false;
        if(gameStage == 0)
        {
            Color color = enemy1.color;
            color.a = 1.0f;
            enemy1.color = color;
        }
        else if (gameStage == 1)
        {
            Color color = enemy2.color;
            color.a = 1.0f;
            enemy2.color = color;
        }
        else if (gameStage == 2)
        {
            Color color = enemy3.color;
            color.a = 1.0f;
            enemy3.color = color;
        }
        else if (gameStage == 3)
        {
            Color color = enemy4.color;
            color.a = 1.0f;
            enemy4.color = color;
        }
        else if (gameStage == 4)
        {
            Color color = enemy5.color;
            color.a = 1.0f;
            enemy5.color = color;
        }
        else if (gameStage == 5)
        {
            Color color = enemy6.color;
            color.a = 1.0f;
            enemy6.color = color;
        }
        else if (gameStage == 6)
        {
            Color color = enemy7.color;
            color.a = 1.0f;
            enemy7.color = color;
        }

        isUntilCnt = true;

        btnDown = false;
        bSkill = false;
        bProviso = false;

        stagePointer = gameStage;
        provisoPointer = 0;
        stageRoot = 0;

        hp = PlayerPrefs.GetInt("HP");
        lv = PlayerPrefs.GetInt("LV");
        exp = PlayerPrefs.GetInt("EXP");

        StageSelectGenerate();
        //시작하자마자 텍스트 나오게
        BattleTextAction();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (lv == 1)
        {
            if(exp >= 10)
            {
                exp -= 10;
                lv++;
                hp++;
                explanText.text += "\n레벨 업 하였다\n♥가 1 올랐다";
            }
        }
        else if(lv == 2)
        {
            if(exp >= 15)
            {
                exp -= 15;
                lv++;
                hp++;
                explanText.text = "\n레벨 업 하였다\n♥가 1 올랐다";
            }
        }
        else if (lv == 3)
        {
            if (exp >= 20)
            {
                exp -= 20;
                lv++;
                hp++;
                explanText.text = "\n레벨 업 하였다\n♥가 1 올랐다";
            }
        }
        else if (lv == 4)
        {
            if (exp >= 23)
            {
                exp -= 23;
                lv++;
                hp++;
                explanText.text += "\n레벨 업 하였다\n♥가 1 올랐다";
            }
        };
        hpText.text = hp.ToString();
        expText.text = exp.ToString();
        lvText.text = lv.ToString();
    }

    public void NextScript()
    {
        BattleTextAction();
    }

    public void AttackBtnDown()
    {
        btnDown = true; 
    }
    public void AttactBtnUp()
    {
        btnDown = false;
        bAttackBtn = true;
        if (stagePointer >= 0 && stagePointer <= 8)
        {
            if (provisoPointer >= 0 && provisoPointer <= 9)
            {
                bAttackAvailable = true;
            }
        }
        NextScript();
    }

    void StageSelectGenerate()
    {
        if(gameStage >= 0)
        {
            stageNum1.text = "전장에 서다";
            if (gameStage == 0) Stage1Selector();
        }
        if(gameStage >= 1)
        {
            stageNum2.text = "선택장애";
            if (gameStage == 1) Stage2Selector();
        }
        if(gameStage >= 2)
        {
            //폴른 의뢰를 성공시
            if(PlayerPrefs.GetInt("egoistic") > 0)
            {
                stageNum3.text = "그들의 상황";
            }
            else
            {
                stageNum3.text = "--";
            }
            if (gameStage == 2) Stage3Selector();
        }
        if(gameStage >= 3)
        {
            stageNum4.text = "혼 선";
            if (gameStage == 3) Stage4Selector();
        }
        if(gameStage >= 4)
        {
            stageNum5.text = "그와의 갈등";
            if (gameStage == 4) Stage5Selector();
        }
        if(gameStage >= 5)
        {
            stageNum6.text = "그녀와의 갈등";
            if (gameStage == 5) Stage6Selector();
        }
        if(gameStage >= 6)
        {
            stageNum7.text = "stage ????";
            Stage7Selector();
        }
    }

    public void Stage1Selector()
    {
        stagePointer = 0;
        if(gameStage > 0 || (gameStage == 0 && (gameQuart > 0 || bAttackTime)))
        {
            provisoNum1.text = "정확히는 알지 못한다";
            provisoNum2.text = "우리의 잘못?";
            provisoNum3.text = "그들의 군대";
            provisoNum4.text = "에너지";
            provisoNum5.text = "정의";
        }
        //첫 게임스테이지 일 경우
        else
        {
            if(gameCnt >= 10)
            {
                provisoNum1.text = "정확히는 알지 못한다";
                if (gameCnt >= 11)
                {
                    provisoNum2.text = "우리의 잘못?";
                    if (gameCnt >= 15)
                    {
                        provisoNum3.text = "그들의 군대";
                        if(gameCnt >= 24)
                        {
                            provisoNum4.text = "에너지";
                            if(gameCnt >= 28)
                            {
                                provisoNum5.text = "정의";
                            }
                            else
                            {
                                provisoNum5.text = "";
                            }
                        }
                        else
                        {
                            provisoNum4.text = "";
                            provisoNum5.text = "";
                        }
                    }
                    else
                    {
                        provisoNum3.text = "";
                        provisoNum4.text = "";
                        provisoNum5.text = "";
                    }
                }
                else
                {
                    provisoNum2.text = "";
                    provisoNum3.text = "";
                    provisoNum4.text = "";
                    provisoNum5.text = "";
                }
            }
        }
        provisoNum6.text = "";
        provisoNum7.text = "";
        provisoNum8.text = "";
        provisoNum9.text = "";
    }
    public void Stage2Selector()
    {
        stagePointer = 1;
        if (gameStage >= 1)
        {
            provisoNum1.text = "첨부. 폴른의 의뢰서";
            provisoNum2.text = "전용 자동차";
            provisoNum3.text = "크레시아 마을";
            provisoNum4.text = "평화로울 것 같은 마을";
            provisoNum5.text = "군대";
            provisoNum6.text = "시장과 이장";
            provisoNum7.text = "마을 중 하나";
            provisoNum8.text = "긍정";
            provisoNum9.text = "부정";
        }
        else
        {
            provisoNum1.text = "";
            provisoNum2.text = "";
            provisoNum3.text = "";
            provisoNum4.text = "";
            provisoNum5.text = "";
            provisoNum6.text = "";
            provisoNum7.text = "";
            provisoNum8.text = "";
            provisoNum9.text = "";
        }
    }
    public void Stage3Selector()
    {
        stagePointer = 2;
        if (gameStage >= 2 && PlayerPrefs.GetInt("egoistic") > 0)
        {
            provisoNum1.text = "3 : 300";
            provisoNum2.text = "완수금";
            provisoNum3.text = "페스라 레이마";
            provisoNum4.text = "감니아 마을";
            provisoNum5.text = "랜더 시";
            provisoNum6.text = "군의 지원";
            
        }
        else
        {
            provisoNum1.text = "";
            provisoNum2.text = "";
            provisoNum3.text = "";
            provisoNum4.text = "";
            provisoNum5.text = "";
            provisoNum6.text = "";
        }
        provisoNum7.text = "";
        provisoNum8.text = "";
        provisoNum9.text = "";
    }
    public void Stage4Selector()
    {
        stagePointer = 3;
        if (gameStage >= 3)
        {
            provisoNum1.text = "의뢰서";
            provisoNum2.text = "그들";
            provisoNum3.text = "이중 계약";
            provisoNum4.text = "제안";
        }
        else
        {
            provisoNum1.text = "";
            provisoNum2.text = "";
            provisoNum3.text = "";
            provisoNum4.text = "";
        }
        provisoNum5.text = "";
        provisoNum6.text = "";
        provisoNum7.text = "";
        provisoNum8.text = "";
        provisoNum9.text = "";
    }
    //케이안 전
    public void Stage5Selector()
    {
        stagePointer = 4;
        if (gameStage >= 4)
        {
            provisoNum1.text = "로제스트";
            provisoNum2.text = "케이안";
            provisoNum3.text = "아우레시아";
            provisoNum4.text = "형태";
            provisoNum5.text = "도끼";
        }
        else
        {
            provisoNum1.text = "";
            provisoNum2.text = "";
            provisoNum3.text = "";
            provisoNum4.text = "";
            provisoNum5.text = "";
        }
        provisoNum6.text = "";
        provisoNum7.text = "";
        provisoNum8.text = "";
        provisoNum9.text = "";
    }
    public void Stage6Selector()
    {
        stagePointer = 5;
        if (gameStage >= 5)
        {
            provisoNum1.text = "연구소";
            provisoNum2.text = "마법";
            provisoNum3.text = "옷";
            provisoNum4.text = "";
        }
        else
        {
            provisoNum1.text = "";
            provisoNum2.text = "";
            provisoNum3.text = "";
            provisoNum4.text = "";
        }
        provisoNum6.text = "";
        provisoNum7.text = "";
        provisoNum8.text = "";
        provisoNum9.text = "";
    }
    //라스트 스테이지
    public void Stage7Selector()
    {
        stagePointer = 6;
        if (gameStage >= 6)
        {
            provisoNum1.text = "진실";
            provisoNum2.text = "동굴";
            provisoNum3.text = "";
            provisoNum4.text = "";
        }
        else
        {
            provisoNum1.text = "";
            provisoNum2.text = "";
            provisoNum3.text = "";
            provisoNum4.text = "";
        }
        provisoNum6.text = "";
        provisoNum7.text = "";
        provisoNum8.text = "";
        provisoNum9.text = "";
    }

    public void Proviso1Selector()
    {
        if (provisoNum1.text != "")
        {
            provisoPointer = 0;
            bSkill = false;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 0);
        }
    }
    public void Proviso2Selector()
    {
        if(provisoNum2.text != "")
        {
            bSkill = false;
            provisoPointer = 1;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 1);
        }
    }
    public void Proviso3Selector()
    {
        if (provisoNum3.text != "")
        {
            bSkill = false;
            provisoPointer = 2;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 2);
        }
    }
    public void Proviso4Selector()
    {        
        if (provisoNum4.text != "")
        {
            bSkill = false;
            provisoPointer = 3;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 3);
        }
    }
    public void Proviso5Selector()
    {
        if (provisoNum5.text != "")
        {
            bSkill = false;
            provisoPointer = 4;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 4);
        }
    }
    public void Proviso6Selector()
    {
        if (provisoNum6.text != "")
        {
            bSkill = false;
            provisoPointer = 5;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 5);
        }
    }
    public void Proviso7Selector()
    {
        if (provisoNum7.text != "")
        {
            bSkill = false;
            provisoPointer = 6;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 6);
        }
    }
    public void Proviso8Selector()
    {
        if (provisoNum8.text != "")
        {
            bSkill = false;
            provisoPointer = 7;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 7);
        }
    }
    public void Proviso9Selector()
    {
        if (provisoNum9.text != "")
        {
            bSkill = false;
            provisoPointer = 8;
            explanText.text = talkManager.GetExplanData((stagePointer * 1000) + 8);
        }
    }

    public void UseSkillBtn()
    {
        bSkill = true;
        explanText.text = "스킬이 선택됨";
    }
}
