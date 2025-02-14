﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talk; //스토리
    Dictionary<int, string> nameValue; //이름

    void Awake()
    {
        talk = new Dictionary<int, string[]>();
        nameValue = new Dictionary<int, string>();

        NameGenerate();
        TalkGenerate();
    }

    void NameGenerate()
    {
        nameValue.Add(102, "?? : ");
        nameValue.Add(104,"???? : ");
        nameValue.Add(103, "??? : ");
        nameValue.Add(105, "????? : ");
        nameValue.Add(1, "로제스트 : ");
        nameValue.Add(2, "케이안 : ");
        nameValue.Add(3, " 아우레시아 : ");
        nameValue.Add(11, "폴른 : ");
        nameValue.Add(12, "레이마 : ");

    }
    void TalkGenerate()
    {
        talk.Add(0, new string[] {
            "평화롭던 벨비아 시내",
            "갑자기 처음 보는 생물체들이 지나가기 시작한다",
            "마치 영화나 게임에서 봐오던 것들이...",
            "",
            "그렇게 평화롭던 마을... 도시는...",
            "한순간에 전쟁터가 되어버리고 말았다",
            "",
            "수많은 군대들의 시체가 마물이라고 불리는 것들의 사체와 섞여서 널부러져 있었고",
            "벨비아는 시체 냄새만 풍기는 아무도 가지 않는 도시가 되어버렸다",
            "",
            "어느 덧 마물과의 전쟁은 세계 전역으로 퍼져나가게 될 때 즈음, 혜성처럼 등장한 인물들이 있었다"
         });

        talk.Add(1, new string[] {
            nameValue[103] + "혹시 안 챙겨 간 것은 없겠지?" ,
            nameValue[104] ,
            nameValue[103] + "저번에 내가 놓고 간 건 바빠서 그런 거 였지. 정신이 없어서 그런게 아니라고" ,
            nameValue[104] ,
            nameValue[103] + "그보다 이렇게 선행하듯이 돌아다녀도 돈만 없어질 뿐이라고...\n"+
            "      그나마 정부가 지원해주는 돈이 있어서 망정이지...\n"+
            "      이 정도를 했는데도 후원해주는 단체가 없다니 너무하다고 생각하지 않아?" ,
            nameValue[104] ,
            "??? : 흐음.... 어쨌든 이해가 되지 않는군. 아무리 우리에게 특수한 능력이 있기로\n"+
            "      군인들과 같은 병력들도 있는데 우리 같은 민간인을 쓴다는게 이해가 되지 않는군",
            "???? : ",
            "??? : 그런가? 하지만 너무 부려먹는다고 생각하지 않아? 받는 금액도 짜다고...\n"+
            "      우리가 열정페이도 아니고 그래도 먹고 살아야하니까 돈은 받아야겠고",
            "???? : ",
            "??? : 당연한 걸 묻는군. 이런 시기에 우리와 같은 능력있는 자가 직접 악과 싸워야하는거 아니겠어.\n"+
            "      정의집행이지",
            "???? :",
            "??? : 군대도 이제 무서워하니까 어쩔 수 없는거 아니냐",
            "???? : ",
            "??? : 결국 말로는 안지려고 하는구만... 그보다 이녀석은 왜 이렇게 안나오냐?",
            "????? : 오래 기다렸지?",
            "??? : 한 사람 때문에 두 명 기다리게 만들어야겠냐?",
            "????? : 꼭 말을 그렇게 해야겠어?",
            "??? : 매번 그러니까 이러는거잖아",
            "????? : 그거 몇 분 늦었다고 남자가 쩨쩨하게",
            "??? : 뭐? 지금 40분 늦게 나온거라고! 심지어 매번 늦게 나오니까 추가금까지 나오잖아",
            "????? : 그거 얼마 안되잖아. 그럼 내 돈에서 빼든지... 로제스트도 말 좀 해봐",
            "로제스트 :",
            "????? : 너까지.... 하아... 내가 이런 배려심도 없는 얘들이랑 다닌다",
            "??? : 시간이나 지키면서 말하지?",
            "????? : 미안하게 됐네요",
            "??? : 아니다 내가 잘못했다. 앞으로 모일 시간 말할 때 너한테는 30분 일찍 불러야지",
            "????? : 그럼 일찍 말하든지",
            "로제스트 :",
            "??? :　일부러 이런 식으로 말한거라고. 그래도 아우레시아는 양반이지\n"+
            "       다른 여자얘들은 1시간은 기본으로 늦더라....",
            "아우레시아 : 고마워 하라고",
            "??? : 뭔소리지? 40분도 충분히 늦는거거든? 그리고 이번 달은 분량 다 못채웠잖아.",
            "??? : 저번 달도 나랑 로제스트가 남은 10% 마저 채우느라 힘들었을 때 넌 누워있었잖아!",
            "아우레시아 : 니예 니예... 우리 케이안님이 고생하셨네요",
            "케이안 : 그 반응 뭐야! 나랑 로제스트는 쌔빠지게 일하고 있는데",
            "아우레시아 : 알았다고. 그만큼 일할테니까.... 너무 뭐라고 하는거 아니야?\n"+
            "             로제스트도 뭐라고 좀 해줘 봐",
            "케이안 : 그래. 로제스트. 너도 뭐라고 좀 해줘봐",
            "로제스트 : ",
            "케이안 : 하아... 그래. 내가 화내봐야 스트레스만 받지",
            "로제스트 : ",
            "케이안 : 알았어.... 잡설 그만하고 빨리 가자. 시간 없다",
            "아우레시아 : 오우",
            "로제스트 : ",
        });
        talk.Add(2, new string[] {
            "- 모든 일에는 시작이 있고",
            "- 모든 일에는 끝이 있기에...."
        });
        talk.Add(11, new string[]{
            "-1- 전장에 서다",
            "로제스트 :",
            "케이안 : 뭘 물어보고 있어. 어제 니가 가자고 한 록티즈로 가고 있는 길인데",
            "로제스트 :",
            "케이안 : 어쨌든 매번 있는 일이지만 경비가 또 만만치 않게 깨졌구만...\n"+
            "         이거야 차라도 한 대 장만해야겠어?",
            "아우레시아 : 운전도 할 줄 알아?",
            "로제스트 :",
            "케이안 : 그거야 굴러가다보면 어떻게 되지 않겠어?\n"+
            "         그보다 요즘 세상에 운전면허 하나 없는 사람이 어디있다고",
            "아우레시아 : 미안하게 됐네",
            "케이안 : 넌 없을지 알고 있었고 로제스트는",
            "로제스트 : ",
            "케이안 : 봐바 너만 없잖아",
            "아우레시아 : 운전면허 없는게 잘못인건 아니잖아. 그리고 있으면 뭐하냐고 차가 없는데!",
            "로제스트 :　",
            "케이안 : 아... 미안...,",
            "케이안 : 어쨌든 빨리 가자고 늦겠다. 누구 때문에....",
            "아우레시아 : 마지막까지 또...."
        });
        talk.Add(12, new string[]{
            "케이안 : 왜 이렇게 늦게 오는거야",
            "로제스트 : ",
            "케이안 : 후우... 알았어. 근데 너무 큰 희망을 가지진 말라고.\n"+
            "          니가 그렇게 평화적으로 일을 해결하려고 해도 결국 변하는 것은 없어\n"+
            "          이미 그 녀석들은 우리를 해쳤고 우리는 정당방위하고 있는 것뿐이니까",
            "로제스트 : ",
            "케이안 : 일일이 속는 것들이 바보지.\n"+
            "          만약 우리가 그들 입장이라도 똑같이 말했을거야. 아주 의미심장하게 말이야\n"+
            "          결국 자기 자신의 행동을 정당화하기 위한 속임일 뿐이라고",
            "로제스트 :",
            "케이안 : 말이 너무 많은 거 아니야? 결국 우리도 당하는 입장이라고",
            "케이안 : 다른 누군가를 봐줄만한 그런 사정이 되지 못한다고",
            "로제스트 :",
            "케이안 : 어쨌든 빨리 가자. 또 아우레시아 화낸다.",
            "로제스트 : ",
            "....",
            "- 정답이 모른다고 한다면 정의는..."
        });

        talk.Add(100, new string[] {
            "아우레시아 : 케이안에게 좋은 소식!",
            "케이안 : 불안하게 또 무슨 소리....",
            "아우레시아 : 뭐야! 내가 말만 하면 저러네... 너무한거 아니야?",
            "케이안 : 그럼 평소에 불안하지 않게 행동하고 말하면 안되냐?",
            "아우레시아 : 내가 얼마나 평소에 우리 파티를 위해서 노력하는데",
            "케이안 : 로제스트의 반만이라도 해줘라",
            "아우레시아 : 너무하네. 그래도 어제는 로제스트보다 더 열일했다고",
            "로제스트 :",
            "아우레시아 : 어쨌든 내가 건의한게 통과됐다고",
            "케이안 : ... 벌써부터 불안해지는데....",
            "로제스트 :",
            "아우레시아 : 바로 ‘우리 전용 자동차’를 지원해준다는 건의가 통과됐다고?",
            "케이안: ....",
            "로제스트 : ",
            "아우레시아 : 뭐야 이 반응은? 또 내가 잘못한 것 같은 반응이잖아?",
            "케이안 : 아니... 너무 정상적인 건의를 한 부분에 놀란 건데?",
            "로제스트 : ",
            "아우레시아 : 너희들 두고 봐라",
            "로제스트 : "
        });

        talk.Add(101, new string[] {
            "- 크레시아 마을 -",
            "케이안 : 그나저나 차는 언제 오는데",
            "아우레시아 : 글쎄... 아직 연락받은 것은 없는데",
            "케이안 : 그럼 건의가 통과되는 안되든 똑같은거 아니야",
            "아우레시아 : 아니 뭐 해도 나쁜사람으로 만드네 나쁜건 아니잖아",
            "케이안 : 아니 뭐 나쁘다는 말은 아닌데... 안좋게 들었으면 미안하다",
            "아우레시아 : 얘 왜 이래 갑자기... 곧 죽어?",
            "케이안 : 그럴지도...",
            "로제스트 :",
            "아우레시아 : 장난이라도 그런 소리 하지마라.\n"+
            "                그나저나 평화로운 것 같은데 여기서 무슨 의뢰를....",
            "로제스트 : ",
            "아우레시아 : 그럼 의뢰한 사람을 찾아가면 되는거 아닌가?",
            "로제스트 : ",
            "케이안 : 일단 의뢰인이 딱히 써져있지는 않은데....\n"+
            "           그럼 이 마을을 맡고 있는 사람한테 가보면 되는건가?"
        });

        talk.Add(102, new string[] {
            "- 이 마을은 특별하게 시의 중심지이기 때문에 시장이 직접 관리하는 듯 하다 -",
            "?? : 누구지? 당신들은?",
            "로제스트 : ",
            "?? : 그렇군. 난 여기. 크레시아의 이장이자 렌더 시의 시장을 맡고 있는 폴른이라고 한다네",
            "로제스트 : ",
            "폴른 : 보통 그렇지. 아무리 시청 내부라고 해도 이장까지 역임하진 않지만 큰일이 따로 없기도 하고\n"+
            "        전 이장이 불의의 사고로 이장 일을 계속 할 수 없게 돼서\n"+
            "        당분간은 많이 할 일이 없어서 같이 역임하고 있네",
            "케이안 : 뭐 우리가 관여 할 일은 아닌거 같고... 의뢰에 대해서 설명해줄 수 있나요?",
            "폴른 : 그렇군. 의뢰서를 보여줄 수 있나?",
            "로제스트 : ",
            "폴른 : 의심하는 건가? 그렇다면 시청으로 들어가지. 나를 증명할 만한 자료를 보여주지",
            "케이안 : 그냥 대충 이야기해도 되는거 아니야?",
            "로제스트 :",
            "아우레시아 : 그래. 혹시 모르니까 확인하는 것도 나쁘지 않지.",
            "케이안 : 하지만 여기에는 바쁘다고 나와있는데",
            "폴른 : 그것은 걱정없네",
            "로제스트 : ",
            "폴른 : 마족이 이 곳으로 향한다는 것을 도청에 보고함과 동시에 군대 동원이 승인이 나서 말이지.\n"+
            "        꽤나 정확했던 정보인지라 빨리 승인이 난 것 같더군.",
            "폴른 : 그도 그럴게 다른 시에서도 같은 보고가 올라간 부분도 크고 말이지\n"+
            "        그래서 마족보다도 더 일찍 군대가 상주하게 될 것 같아서 말이지...",
            "케이안 : 뭡니까... 그러면 애초에 올 필요가 없다는거 아닙니까?",
            "로제스트 : ",
            "- 사람의 욕심은 끝이 없고 -",
            "- 사람은 마음을 보지 못하기에...-"
        });
        talk.Add(110, new string[] {
            "로제스트 : ",
            "케이안 : 그나저나 역시인가... 구조 자체가 현대의 군이 차 같은 것을 몰고 다닐만한 지형은 아니긴 하군...\n"+
            "         폴른인지 그 녀석 생각이 옳았군",
            "아우레시아 : 착해보이긴 했는데 반말하는게 거슬렸어",
            "로제스트 :",
            "케이안 : 그보다 녀석이랑 무슨 이야기 한거야?",
            "로제스트 : ",
            "케이안 : 뭐 그렇지... 어차피 우리야 일 처리 잘하고 돈 받으면 그만이지.",
            "아우레시아 : 태평한 소리나 하고 있네... 마물 집단이 쳐들어 오는거라고?",
            "케이안 : 그게 한두번인가?",
            "아우레시아 : 그것도 수십마리 정도 상대했을 때야 별 문제 안될 수 있는거지\n"+
            "             지금 우리가 잡으려는 건 군이 투입될지도 모르는 규모의 마물 집단이잖아",
            "케이안 : 뭐.... 어떻게든 돼겠지? 어차피 군 지원도 조금 보내준다는 것 같고 말이야",
            "로제스트 : "
        });
        talk.Add(111, new string[] {
            "- 결국 지키러 가는 길은 정의로운 길이기 때문에... -"
        });

        talk.Add(200, new string[] {
            "로제스트 : ",
            "케이안 : 흠... 사람이 별로 안보이는데",
            "??? : 이미 대부분은 주민들은 크레시아 마을로 대피시켰습니다.\n"+
            "      렌더에서는 그래도 크레시아 마을이 가장 안전할테니까요",
            "케이안 : 애초에 크레시아 마을로 적들이 오는데 굳이....\n"+
            "         .....그보다 누구?",
            "??? : 아 죄송합니다. 인사가 늦었군요.\n"+
            "      저는 감니아 마을의 이장을 맡고 있는 ‘페스라 레이마’라고 합니다",
            "케이안 : 페스라.... 어디서 많이 들어본 이름인데...",
            "레이마 : 아하하... 저희 아버지가 크레시아 마을을 맡고 있어서 그런 듯 합니다",
            "케이안 : 응? 너무 분위기가 다른데....",
            "로제스트 : ",
            "레이마 : 저희 아버지 성격상 아무에게나 반말 비스므레하게 하는 성격이라서 그런 듯 합니다. 하하... 죄송합니다",
            "아우레시아 : 딱히 저희에게 죄송할 필요는 없지만.... 어쨌든 경험해봐서 그런지 믿기지는 않네요,,,,",
            "레이마 : 성격이 그래도 마을과 그걸 넘어서 시장으로써 랜더시 전체를 소중히 생각하시는 분입니다.\n"+
            "         저도 그런 부분을 존경하며 열심히 하면서 이 마을을 최선의 결과로 이끌어 나가려고 노력하고 있습니다",
            "아우레시아 : 제가 봤을 때는 그 쪽이 더 유능해보이는데..",
            "레이마 : 네?",
            "아우레시아 : 아... 아니예요... 하하하....",
            "레이마 : 어쨌든 곧 군 지원도 올 예정입니다만, 거리 상으로 유추했을 때,\n" +
            "         마물이 여기로 바로 오고 있다면 마물이 더 빨리 이 곳에 도착할 것으로 예상되어\n"+
            "         먼저 대비해주실 수 있나요? 완수금은 드리겠습니다",
            "로제스트 : ",
            "레이마 : 아 그렇습니까?.... 제 일인데 아버지께서 괜히... 나중에 갚아 드려야겠군요",
            "케이안 : 어차피 정부 지원금 나오는거 아닌가요? 이런거 하면....",
            "레이마 : 나오긴 합니다만.... 의뢰금 전부를 주는 건 아니죠.\n"+
            "         심지어 반절도 못받는 경우가 허다합니다.",
            "케이안 : 그렇군요.... 이거 왠지 미안해지는데....",
            "레이마 : 아닙니다. 자신을 희생하며 우리를 지켜주시는 일을 하시는데\n" + 
            "         이 정도면 저희가 미안해질 정도입니다. 저희도 여유분이 있다면 보태드리겠습니다",
            "아우레시아 : 괜찮아요...",
            "케이안 : 괜히 우리가 더 미안해지는 걸.... 그보다 아우레시아도 이런 상황 파악은 빨리 되다니 놀랍네",
            "아우레시아 : 적당히 놀려 케이안!",
            "케이안 : 아... 알았어 미안....",
            "로제스트 : "
        });

        talk.Add(210, new string[] {
            "로제스트 : ",
            "아우레시아 : 아니.... 나는...",
            "케이안 : 그만해 로제스트. 아무리 그래도 적을 죽인거야.\n"+
            "         니가 이야기 나누는 건 이해하지만 어쨌든 적인 건 똑같다고",
            "로제스트 : ",
            "케이안 : 굳이 그렇게까지 말해야 되는거야?\n"+
            "         아우레시아도...",
            "아우레시아 : 아니야... 나는 그냥 저 녀석이면...\n"+
            "             아.... 아니야....",
            "케이안 : ....",
            "로제스트 : ",
            "케이안 : 어쩔 수 없는거잖아. 죽이다보면...\n"+
            "         어차피 결국에는 녀석도 우리를 죽이던지 우리가 죽이던지 해야됐다고\n"+
            "         아무리 니가 이야기를 하더라도 이 상황은 변하지 않아",
            "케이안 : 생각해봐. 이미 우리도 당했고 녀석들도 당했던 상황에서\n"+ 
            "         서로를 이해한다는 것은 불가능하다고",
            "로제스트 : ",
            "케이안 : 적당히!",
            "아우레시아 : 미... 안해...",
            "로제스트 : ",
            "- 모든 일의 끝은 허무하게.... -"
        });

        talk.Add(300, new string[] {
            "로제스트 : ",
            "케이안 : 그러게...",
            "아우레시아 :.... ",
            "로제스트 : ",
            "케아안 : 응? 아... 별거 아니야... 하하...",
            "로제스트 : ",
            "케이안 : 어쨋든 이번엔 제대로 된 일이겠지? 제발 저번처럼 '혼선'만 안생겼어도...",
            "아우레시아 : 불길한 소리 좀 하지마",
            "로제스트 : "
        });
        talk.Add(301, new string[] {
            "??? : 너희는 뭐지?",
            "로제스트 : ",
            "??? : 우리는 의뢰를 받고 이 동굴 안을 조사하러 왔는데...",
            "케이안 : 하아.... 설마 또 이런거냐?",
            "??? : 그런거냐니... 설마 너희도....?",
            "아우레시아 : 요즘 되는 일이 없네...",
            "??? : 이거 골치군... 이중 계약이라니... 본적도 들은적도 없어....",
            "로제스트 : ",
            "??? : 안돼. 너희도 알거 아니야. 우리는 사냥감이 필요하다고",
            "로제스트 : ",
            "??? : 뭐?... 어쨋든 이 일은 양보 못한다",
            "로제스트 : ",
            "- 지나친 욕심이 낳는 것은.... -"
        });
        //전투 후
        talk.Add(310, new string[] {
            "???_1 : 뭐지? 힘이 넘쳐나는 느낌이야.",
            "???_2 : 이 전보다 더 쌔진 느낌이야",
            "로제스트 : ",
            "케이안 : ..... 하아....",
            "아우레시아 : .....",
            "로제스트 : ",
            "케이안 : 응?... 아니야 아무것도..."
        });
        talk.Add(311, new string[] {
            "- 직면한 일에 대한 대답은....-"
        });

        //케이안 전 이전
        talk.Add(400, new string[] {
            "케이안 : 로제스트",
            "로제스트 :",
            "케이안 : 더 이상 너와 같이 이 일을 못해먹겠어!",
            "로제스트 :",
            "케이안 : 이유를 묻는다고? 니가?",
            "케이안 : 니가 언제 한번이라도 니 행동의 결정이 어떤 영향을 끼치는지 생각해본적 있어?",
            "로제스트 :",
            "케이안 : 예전부터 그런게 마음에 들지 않았어",
            "로제스트 :",
            "케이안 : 그럴지도 몰라! 하지만 나는!!....",
            "케이안 : .....",
            "케이안 : .... 어쨋든 나는 이 파티를 나가겠어. 아우레시아! 니 생각은 어때",
            "아우레시아 : 응?.... 나... 나는....",
            "로제스트 : ",
            "케이안 : 끝까지 설득하겠다는거냐.... 제길....",
            "로제스트 :"
        });
        talk.Add(401, new string[] {
            "- 끊임 없는 갈등의 결과는... -"
        });

        talk.Add(410, new string[] {
            "케이안 : 니가 하는 모든 말이 정설이라고 하더라도 나는 떠날거다",
            "로제스트 : ",
            "케이안 : 그 따위 동정은 필요없어!",
            "아우레시아 : 케이안....",
            "케이안 : 걱정하지마. 나라고. 케이안",
            "케이안 : 언젠가 다시 보자... 아우레시아",
            "아우레시아 : 로제스트... 제발..." ,
            "로제스트 : "
        });
        talk.Add(411, new string[] {
            "- 사람마다 생각이 다르고 -",
            "- 사람마다 선택이 다르기에... -"
        });

        talk.Add(500, new string[] {
            "시간이 지나 도착한 곳은 어느 연구소....",
            "아니... 정확히는 연구소 였던 곳이 눈에 들어왔다",
            "그 곳 주변에는 곳곳에 의아하게도 옷이 널부러져있다"
        });
        talk.Add(501, new string[] {
            "아우레시아 : 로제스트...",
            "로제스트 : ",
            "아우레시아 : 우리... 볼 수 있는거지",
            "로제스트 : ",
            "아우레시아 : 거짓말치지마!",
            "로제스트 : ",
            "아우레시아 : 그러면 이 옷은 뭐냐고!",
            "로제스트 : ",
            "아우레시아 : 그래... 그렇다고 쳐...",
            "아우레시아 : 그러면 이 도끼는! 어떻게 설명할건데!",
            "로제스트 : ",
            "아우레시아 : .....",
            "아우레시아 : 나도 정했어...",
            "로제스트 : ",
            "아우레시아 : 나도.... 널 떠나겠어",
        });
        talk.Add(502, new string[] {
            "- 내 손에 쥐고 있던 것은.... -"
        });

        talk.Add(510, new string[] {
            "(전화벨 소리)",
            "로제스트 : ",
            "?? : 여어. 오랜만이야",
            "로제스트 : ",
            "?? : 잊은건가? 나야. 폴른. '페스라 폴른'",
            "로제스트 : ",
            "?? : 들었네... 결국 혼자가 되었다는 소문을...",
            "로제스트 : ",
            "?? : 당치도 않아. 하지만 한가지 너에게 하고 싶은 말이 있어서야",
            "로제스트 : ",
            "?? : 의뢰를 부탁하고 싶어서 전화했네",
            "로제스트 : ",
            "?? : 흠... 어쩔 수 없군... 자네 상황을 알기에 의뢰하고자 한건데 말이야",
            "로제스트 : ",
            "?? : 기억하게. 난 자네 편이야.\n"+
            "     동굴 조사 의뢰인데... 심상치 않아서 말이야",
            "?? : 분명 니가 원하는 해답을 얻을 수 있을거야",
            "로제스트 : ",
            "?? : 물론! 믿을 만한 정보일세",
            "로제스트 : "
        });
        talk.Add(511, new string[] {
            "- 손으로 잡으려는 것은 진실일지... -",
            "- 아니면 자기 위안일지.... -"
        });
        //last game
        talk.Add(600, new string[] {
            "무슨 일인지 마물들이 아무것도 하지 않는다",
            "무슨 일인지 길을 알려 주는 듯이 가상에 서있다",
            "무슨 일인지 고개를 숙이고 있다",
            "그리고 결국 그 앞에 다다른 것은...."
        });
        talk.Add(601, new string[] {
            "???? : 어서와",
            "???? : 산전 수전 다 겪은 얼굴인걸?",
            "???? : 굉장히 많은 일을 겪었겠지.",
            "???? : 때로는 그만두고 싶었을거야",
            "???? : 그래도 생각보다 간단했지 않나?",
            "???? : 이봐 얼굴 피라고?",
            "???? : 그래도 결국 마지막이잖아?",
            "???? : 너도 알겠지만 이 마지막은 처음부터 하지 않으면 볼수가 없지",
            "???? : 어이, 왜 의문스러운 얼굴이지?",
            "???? : 이 충고는 전부 너한테 하고 있는거라고",
            "???? : 자기가 아닌듯이 보고있군 그래... 너말이야 건너편에 있는 이 말을 '보고'있는 너!",
            "???? : 말이 길었군... 로제스트...",
            "???? : 어떻게 이름을 알고 있는지는 중요하지 않아",
            "???? : 니가 이 마지막에 도달했다는게 중요한거지",
            "???? : 미안하지만 난 호락호락하지 않아",
            "???? ; 어디 한 번 덤벼보라고 스릴넘치게 말이야",
            "???? : 어디 한 번 덤벼보라고",
            "???? : 진실에 도달할 때 까지 말이야!"
        });
        talk.Add(602, new string[] {
            "- 결국 진실은... -"
        });
        
        //1번 엔딩
        talk.Add(901, new string[] {
            "- 그 후, 우리는 마물을 정리해 나갔다",
            "- 하지만 과연 이것은 옳은 일일까...",
            "- 그 한가지 질문만이.... 머릿 속을 감돌았다..."
        });
        talk.Add(902, new string[] {
            "- 사람의 행동에는 정답이 없기에... -"
        });

        //2번 엔딩
        talk.Add(911, new string[] {
            "- 결국 혼자 남았다",
            "- 어느 쪽을 선택해도 후회하지 않을까...",
            "- 나는 혼자 남아서 그런 생각만을 한다",
            "로제스트 : ",
            "- 언제까지나...."
        });
        talk.Add(912, new string[] {
            "- 어느 쪽을 선택하든 결국 후회하는 길이기에..."
        });

        //진 엔딩
        talk.Add(921, new string[] {
            "???? : 결국 진실의 끝에 도달했군. 축하해.",
            "로제스트 : ",
            "???? : 뭐지? 니가 원하던게 이거 아니였나?",
            "???? : 허무하겠지... 지금 당장은 뇌가 찢어지게 아플지도 몰라",
            "???? : 수많은 생각이 너를 집어 삼킬지도 몰라.",
            "???? : 두 개의 생각이 너의 머리를 아프게 하겠지",
            "로제스트 : ",
            "???? : 하지만 진실은 하나야. 친구... 아니..."
        });
        talk.Add(922, new string[] {
            "???? : 알잖아?",
            "???? : 니가 누구고 내가 누군지 말이야",
            "로제스트 : ",
            "???? : 다시 돌아갈 생각은 없어. 니가 해야할 일도 있을테니까...",
            "로제스트 : ",
            "???? : 후후후... 그래...",
            "???? : 건승을 빌지...",
            "???? : 그게 내 존재 의의니까 말이야"
        });

        talk.Add(9999, new string[] {
            "케이안 : 그래도 녀석들이 오긴 했네",
            "로제스트 : ",
            "케이안 : 주로 감니아로 향했다는 소리가 들리긴 하는데...",
            "케이안 : 뭐... 우리는 의뢰대로 한 것 뿐이니까",
            "케이안 : 우리 선택은 잘못되지 않았을거야",
        });
        talk.Add(10000, new string[] {
            "- 하나의 선택은 다른 것의 포기이기에... -"
        });
    }
 
    public string GetTalk(int id, int index)
    {
        //해당 스토리 라인의 각 대화 순서의 마지막일 경우
        if (index == talk[id].Length) return null;

        return talk[id][index];
    }
}
