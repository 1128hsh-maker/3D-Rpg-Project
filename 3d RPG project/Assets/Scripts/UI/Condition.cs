using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public static Condition instance { get; private set; }
    public TextMeshProUGUI hp;
    public TextMeshProUGUI mp;
    public TextMeshProUGUI exp;
    public TextMeshProUGUI dia;
    public TextMeshProUGUI gold;
    public Slider hpBar;
    public Slider mpBar;
    public Slider expBar;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        hp.text = $"{Player.instance.currentHP} / {Player.instance.maxHP}";
        mp.text = $"{Player.instance.currentMP} / {Player.instance.maxMP}";
        exp.text = $"{Player.instance.currentEXP} / {Player.instance.maxEXP}";
        dia.text = $"{Player.instance.dia}";
        gold.text = $"{Player.instance.gold}";
        
        CheckMP();
    }
    public void CheckHP() //*HP 갱신
    {
        if (hpBar != null)
            hpBar.value = Player.instance.currentHP / Player.instance.maxHP;
    }
    public void CheckMP() //*MP 갱신
    {
        if (mpBar != null)
            mpBar.value = Player.instance.currentMP / Player.instance.maxMP;
    }

    public void CheckEXP() //*EXP 갱신
    {
        if (expBar != null)
            expBar.value = Player.instance.currentEXP / Player.instance.maxEXP;
    }

}

