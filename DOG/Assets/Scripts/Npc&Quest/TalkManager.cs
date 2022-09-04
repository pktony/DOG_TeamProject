using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    public int QuestNumber1 = 0;

    private static TalkManager instance;
    public static TalkManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);     // 씬이 변경되더라도 게임 오브젝트가 사라지기 않게 해주는 함수
        }
        else
        {
            // 씬의 Gamemanager가 여러번 생성됐다.
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    private void GenerateData()
    {
        ////일반 대화
        //talkData.Add(1000, new string[] {"무슨 일 있는가?", "자네라도 얼른 마을을 떠나게....", "난 마을의 장로로서 끝까지 마을을 지키겠네."});
        //
        //talkData.Add(2000, new string[] { "당신은 정말 운이 좋았군요.", "언젠가 부터 마을 사람들이 사라지기 시작했어요.", "장로 말을 듣고 마을 밖으로 나간 주민들은 돌아오지 못했어요."});
        //
        talkData.Add(3000, new string[] { "보기엔 평범한 상자이다." });

        //퀘스트 대화
        talkData.Add(10 + 1000, new string[] { "플레이어 : 장로님! 오랜만에 뵙습니다.", "장로 : 자네는?!", "장로 : 도대체 이제까지 어디에 있었던 건가?!", "플레이어 : 열병에 걸려서 오랫동안 집 다락방에 누워있었습니다....", "장로 : 다행이야, 그래서 화를 피할 수 있었구먼!",
        "플레이어 : 화 라니요? 마을에 무슨 일이 있었나요?","장로 : 자네, 내 집에 오는 동안 누구를 만났는가?"," 플레이어 : 아니요, 아무도 보지 못했습니다.","장로 : 그렇네, 지금 마을에 재앙이 일어나 모두 사라지고 나만 남았네...","플레이어 : 네?!",
        "장로 : 놀라는게 당연하지....","플레이어 : 무슨 재앙인가요? 원인이 뭔가요?!","장로 : 원인을 찾으러 주민들이 마을 주변을 살폈지만....","장로 : 모두 돌아오지 못했네...남은 주민들은 불안함에 마을을 떠났지.","장로 : 마을에는 나 밖에 남지 않았네.","장로 : 자네도 어서 떠나게!",
        "플레이어 : 아닙니다. 제가 나고 자란 고향인데 그럴 수는 없습니다.", "플레이어 : 제가 일단 마을을 순찰하고 올게요!","장로 : 정말 고집불통이로군....살아 돌아오게.","플레이어 : 넵", "독백 : 마을을 순찰해보자..."});

        talkData.Add(11 + 2000, new string[] { "플레이어 : 엇! 대장간 아저씨 따님 아니십니까?!", "주민 : 앗, 당신은 그....?", "플레이어 : 접니다. 마을 목수셨던 하퍼의 아들이요!", "주민 : 아!...흐릿하지만 아들이 있었던 것 같았어.",
        "주민 : 당신은 어떻게 살아있나요? 정말 다행이에요...흑흑","플레이어 : 방금 장로님에게 들었습니다...마을에 재앙이 일어났다고요.","주민 : 장로요!? 아직도 마을에 있나요?","플레이어 : 네, 무슨 일이라도?...",
        "주민 : 재앙이 시작될 때 장로가 장정들을 모아 마을 밖 순찰을 보냈어요."," 주민 : 그리고 살아돌아온 사람이 없었죠.","주민 : 그 사람들을 찾기 위해서 장로는 또 장정들을 모았어요.","플레이어 : 그리고 그들도 못 돌아왔다?"," 주민 : 네...",
        "플레이어 : 저희는 작은 마을이라 장정 몇 명이 사라져도 엄청난 타격이죠.","주민 : 거기까진 의심을 안 했어요!"," 주민 : 모두들 장로가 순찰하라고 한곳에 재앙의 원인이 있구나 했죠.","주민 : 하지만 저는 봤어요...","플레이어 : 어떤?...",
        "주민 : 장로가 순찰대에게 지급한 물통에 어떤 가루를 타는 것을요..","플레이어 : 그런....","주민 : 하지만 아무도 저를 믿지 않았어요.","주민 : 사람들은 두려움에 떠나거나 순찰을 나가 사라진 겁니다.","플레이어 : 이것 참 굉장한 사실이군요.",
        "주민 : 저는 장로를 피해 지금 이곳에 숨은 거에요.","플레이어 : 계속 숨어계십시오, 제가 상황을 파악해보겠습니다.","주민 : 부디...조심하세요.","독백 : 다시 장로에게 돌아가보자."});

        talkData.Add(20 + 1000, new string[] { "플레이어 : 장로님, 다녀왔습니다.","장로 : 오, 그래! 고생했네, 마을에 특이사항이 있던가?","플레이어 : 음....아니요, 전부 사라졌더군요.","장로 : 그럴게야...나도 많이 찾아봤네....너무 상심말게.",
        "플레이어 : 저희 부모님은 제가 병을 앓기 전에 돌아셔서 오히려 다행이라고 생각드네요.","장로 : 하퍼를 말하는건가, 정말 좋은 사람이었지.","플레이어 : 혹시라도 생존자를 발견하시면 어쩌실 생각입니까?",
        "장로 : 당연히 지금 빈 집을 깨끗히 청소하고 먹을 것을 주고 해야지!","플레이어 : 제가 그럼 마을 밖을 순찰하고 오겠습니다.","장로 : 그러지 말게나...자넨 이미 충분히 고생했어!","플레이어 : 아닙니다. 원인을 찾고 얼른 해결해야 마을이 다시 예전처럼 돌아갈 것 같습니다.",
        "장로 : 아버지 답게 정말 고집불통이로군, 그럼 더 이상 말리지 않겠네","플레이어 : 저는 집에서 좀 쉬고 정비한 다음 가보겠습니다. 장로님께서도 조심하시길....","장로 : 벌써 자네가 오지 않으면 어떡하나 걱정이네",
        "장로 : 변변한 건 없지만 여기 이 약을 가져가게","플레이어 : 이건 무슨 약이지요?","장로 : 내가 재앙이 일어난 후 순찰대들에게 조금이나마 도움주고 싶어 약초들을 넣은 약일세","플레이어 : 알겠습니다. 감사합니다. 그럼 이만 가볼게요.","장로 : 꼭 돌아오게!",
        "독백 : 대장간 따님의 말대로 장로가 가루를 탄 것으로 추측되는 약을 주었다. 다시 가보자."});
        talkData.Add(21 + 2000, new string[] { "플레이어 : 잘 계셨습니까?","주민 : 오셨군요! 마을과 장로의 상황은 어떤가요?","플레이어 : 마을에는 역시 아무도 보이질 않고 장로님만 마을 회관에 계십니다.","주민 : 그렇군요.","플레이어 : 저는 그러면 장로님에게 들은 마을 밖 장소들로 가보겠습니다.",
        "주민 : 당신을 보니 희망이 생기네요...저도 제가 할 수 있는 것을 하고 있겠어요.","플레이어 : 따님께서도 부디 조심하십시오.","주민 : 마을 밖에는 아마 고블린들도 돌아다니고 있을 거에요.","플레이어 : 인간이 없으니 마을을 차지하러 오는 것이군요. 걱정마십시오.",
        "독백 : 빈 마을을 탐내는 고블린을 처치하자."});

        //다섯 번째 고블린 처치 카운트를 센다음 카운트 채워지면 NextQuest(); 발동해서 넘어가게끔

        talkData.Add(40 + 1000, new string[] { "장로 : 자네 살아 돌아왔군! 정말 다행이야.", "플레이어 : 마을 주변을 순찰했지만 눈에 띄는 것은 없었습니다.","플레이어 : 다만 주민들이 사라진 마을을 고블린들이 노리고 있는 것 같아 몇 마리 처치했습니다.",
        "장로 : 인간들이 없는 마을을 차지하고 싶겠지....다친 곳은 없는가?","플레이어 : 주신 약초액을 마시며 쉬었더니 자잘한 상처들은 다 나았습니다.","장로 : 그렇지? 내가 오랜 시간 책을 보며 연구한 약초일세, 뿌듯하구만.","독백 : 어떤 약초일까?",
        "장로 : 몬스터들이 가깝다니....마을 입구들의 문들을 단속하고 오겠네","플레이어 : 저는 그럼 재정비하며 이곳에서 기다리겠습니다.","장로 : 집에서 쉬지 않고?","플레이어 : 집에는 음식과 씻을 물이 다 떨어졌습니다.","장로 : 아 그럴 수 있지, 그럼 편히 쉬고 있게나!",
        "독백 : 장로가 잠시 자를 비운 사이에 특이사항이 없는지 회관을 둘러보자."});
        talkData.Add(41 + 3000, new string[] { "독백 : 장로의 집에 따로 특이사항은 없는 것 같은데....", "독백 : 수상해보이는 상자다. 열어보자", "독백 : 엇 갑자기 주변이?", "시스템 : 상자 속으로 빨려들어 갑니다." });

        //미니게임 공간을 탈출하고 씬 이동하면 NextQuest(); 발동해서 넘어가게끔

        talkData.Add(60 + 2000, new string[] { "주민 : 무사하셨군요! 다친 곳은 없으신가요?","플레이어 : 당신이 맞았습니다. 방금 장로회관에서 마법에 걸린 상자 때문에 영원히 갇힐 뻔 했습니다.","주민 : 저런!....그렇다면....지금 사라진 주민들도 상자에 갇힌 건가요?",
        "플레이어 : 이상한 공간으로 들어갔을 땐 저 혼자였습니다. 아마 각자의 공간에 갇혀있지 않을까요?","플레이어 : 그 약초액을 먹으면 잠이 들게 되고 그 사이에 상자에 모두 넣은 것 같습니다.","주민 : 이런 미친 짓이라니!...증거를 찾았으니 얼른 같이 가볼까요?","플레이어 : 아닙니다. 제가 가서 장로에게 자백을 받아내겠습니다.",
        "주민 : 저는 그러면 마을 사람들이 돌아왔을 때를 대비해서 진실을 알릴 준비를 하고 있을게요.","플레이어 : 저는 다시 마을 회관으로 가서 장로를 기다리겠습니다."});

        talkData.Add(61 + 3000, new string[] { "독백 : 상자를 미리 확보해놓자.","독백 : 엇....상자에서 무슨 목소리가?","장로 : 눈치를 챘나....흐흐흐","플레이어 : 장로!....어디서 말을 하는 거지? 주민들은 어디있어!",
        "장로 : 찾아보시지, 주민들은 기쁘게 나의 영생을 위한 제물이 될 준비를 하고 있다.","플레이어 : 제길....처음부터 의심했어야 했어","장로 : 비밀을 안 김에 나와같이 영생을 누리지 않겠나?","플레이어 : 싫다! 꼭 찾아내 마을의 원수를 갚겠다.","장로 : 난 이미 거의 불사의 몸이 되었고 너 따위는 상대가 안 된다.",
        "플레이어 : 마을 내외부에 숨을 만한 곳은 다 알고 있다. 너는 분명 거기에 있겠지","장로 : 마을 밖을 돌아다니지 말라는 말을 안 들은 꼬맹이라서 신경썼어야 했는데 클클","플레이어 : 원수를 갚으러 가겠다!","장로 : 기다리고 있으마","독백 : 마을 밖 몬스터들에게 점령된 동굴로 가보자"});

        talkData.Add(80 + 2000, new string[] { "플레이어 : 장로를 제거했지만....그래도 마을 사람들이 돌아오지는 않았습니다.","주민 : 정말 대단하세요. 다치신 곳은 없나요.","플레이어 : 네, 저는 괜찮습니다만....상자는 이미 장로가 채간 후 몬스터화 되는데 사용한 것 같았어요.",
        "주민 : 정말 충격이군요....제가 알고 있던 장로는 그런 사람이 아니었는데....","플레이어 : 저도 지금 현실이 좀 믿기지가 않습니다....","주민 : 그러면 이제 재앙의 원인도 해결하셨는데 어쩌실 건가요?","플레이어 : 일단 생각을 좀 정리하며 집에서 쉬려고 합니다.",
        "주민 : 그래요, 저도 숨어있을 필요가 없으니 마을을 돌아다녀봐야겠네요.","플레이어 : 조심하세요. 마을 밖은 아직 몬스터들이 돌아다니고 있습니다.","주민 : 네, 조심할게요. 그리고 저녁이 되기 전에 음식을 차린 후 당신을 기다릴게요.","플레이어 : !....","시스템 : 마을을 지켰습니다. 행복하게 사세요."});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                if (talkIndex == talkData[id - id % 100].Length)
                {
                    return null;
                }
                else
                {
                    return talkData[id - id % 100][talkIndex];
                }
            }
            else
            {
                //퀘스트 진행 중 대사가 없을 때 
                //퀘스트 맨 처음 대사를 가지고 옴
                if (talkIndex == talkData[id - id % 10].Length)
                {
                    return null;
                }
                else
                {
                    return talkData[id - id % 10][talkIndex];
                }
            }
        }

        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            //id로 대화 talkIndex로 대화의 한 문장을 리턴
            return talkData[id][talkIndex];
        }
    }
}