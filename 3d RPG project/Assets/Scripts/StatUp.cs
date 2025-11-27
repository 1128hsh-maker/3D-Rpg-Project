using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatUp : MonoBehaviour
{
    private int damageLevel = 1;
    private int healthLevel = 1;
    private int armorLevel = 1;
    [SerializeField]private TextMeshProUGUI damageText;
    [SerializeField]private TextMeshProUGUI healthText;
    [SerializeField]private TextMeshProUGUI armorText;
    public void damageUp()
    {
        if (Player.instance.gold >= 50 * damageLevel)
        {
            Player.instance.gold -= 50 * damageLevel;
            damageLevel++;
            Player.instance.damage += 10;
            damageText.text = damageLevel + ".LV";
        }
        else return;
    }
    public void healthUp()
    {
        if(Player.instance.gold >= 50*healthLevel)
        {
            Player.instance.gold -= 50*healthLevel;
            healthLevel++;
            Player.instance.maxHP += 20;
            Player.instance.currentHP += 20;
            healthText.text = healthLevel + ".LV";
            Condition.instance.CheckHP();
        }
        else return;
    }
    public void armorUp()
    {
        if (Player.instance.gold >= 50 * armorLevel)
        {
            Player.instance.gold -= 50 * armorLevel;
            armorLevel++;
            Player.instance.armor += 5;
            armorText.text = armorLevel + ".LV";
        }
        else return;
    }
}
