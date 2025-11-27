using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public static Quest instance {  get; private set; }
    [SerializeField] private TextMeshProUGUI questText;
    public int currentQuestIndex = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void TextUpDate()
    {
               questText.text =$"{currentQuestIndex}/1";
    }

    public void MonsterKillQuest()
    {
        if (currentQuestIndex > 0)
        {
            currentQuestIndex--;
            Player.instance.dia += 1;
            Condition.instance.dia.text = $"{Player.instance.dia}";
            TextUpDate();
        }
    }
}