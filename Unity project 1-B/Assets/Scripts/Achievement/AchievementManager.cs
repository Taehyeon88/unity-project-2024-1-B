using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public AchievementManager Instance;
    public List<Achievement> achievements;

    public Text[] AchievementTexts = new Text[4];

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateAchievementUI()
    {
        AchievementTexts[0].text = achievements[0].name; 
        AchievementTexts[1].text = achievements[0].description; 
        AchievementTexts[2].text = $"{achievements[0].currentProgress}/{achievements[0].goal}"; 
        AchievementTexts[3].text = achievements[0].isUnlocked ? "달성" : "미달성"; 
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddProgress("도약", 1);
            UpdateAchievementUI();
        }
    }
    public void AddProgress(string achievementName, int amount)    //업적 진행 상황 갱신 함수
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);    //인수에서 받아온 이름으로 업적리스트에서 받아서 반환
        if(achievement != null)                                                         //반환된 업적이 있을 경우
        {
            achievement.AddProgress(amount);                                            //프로그래스를 증가시킨다
        }
    }

    public void AddAchievement(Achievement achievement)
    {
        //Achievement temp = new Achievement("이름", "설명", 5);
       // achievement.AddProgress(achievement);
    }

}
