using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    private float damageCount = 1800f;
    private float hpCount = 1800f;
    private float armorCount = 1800f;
    private float DefaltCount = 1800f;
    private bool isDamageBuffed = false;
    private bool isHPBuffed = false;
    private bool isArmorBuffed = false;
    [SerializeField] private TextMeshProUGUI damageBuffTimer;
    [SerializeField] private TextMeshProUGUI hpBuffTimer;
    [SerializeField] private TextMeshProUGUI armorBuffTimer;

    public void DamageTimer()
    {
        damageBuffTimer.text = ((int)(damageCount / 60)).ToString("00") + ":" + ((int)(damageCount % 60)).ToString("00");
    }
    public void HPTimer()
    {
        hpBuffTimer.text = ((int)(hpCount / 60)).ToString("00") + ":" + ((int)(hpCount % 60)).ToString("00");
    }
    public void ArmorTimer()
    {
        armorBuffTimer.text = ((int)(armorCount / 60)).ToString("00") + ":" + ((int)(armorCount % 60)).ToString("00");
    }
    public void DamageBuff()
    {
        if (!isDamageBuffed)
        StartCoroutine(DamageBuffTime());
    }

    public void HPBuff()
    {
        if (!isHPBuffed)
        StartCoroutine(HPBuffTime());
    }

    public void ArmorBuff()
    {
        if (!isArmorBuffed)
        StartCoroutine(ArmorBuffTime());
    }

    public IEnumerator DamageBuffTime()
    {
        isDamageBuffed = true;
        float playerDamage = Player.instance.damage;
        Player.instance.damage *= 2;
        while (damageCount > 0)
        {
            damageCount -= 1f;
            DamageTimer();
            yield return new WaitForSeconds(1f);
        }
        damageCount = DefaltCount;
        isDamageBuffed = false;
        Player.instance.damage = playerDamage;
    }
    public IEnumerator HPBuffTime()
    {
        isHPBuffed = true;
        float playerMaxHP = Player.instance.maxHP;
        Player.instance.maxHP *= 2;
        Player.instance.currentHP = Player.instance.maxHP;
        while (hpCount > 0)
        {
            hpCount -= 1f;
            HPTimer();
            yield return new WaitForSeconds(1f);
        }
        hpCount = DefaltCount;
        isHPBuffed = false;
        Player.instance.maxHP = playerMaxHP;
        if (Player.instance.currentHP > Player.instance.maxHP)
        {
            Player.instance.currentHP = Player.instance.maxHP;
        }
    }

    public IEnumerator ArmorBuffTime()
    {
        isArmorBuffed = true;
        float playerArmor = Player.instance.armor;
        Player.instance.armor *= 2;
        while (armorCount > 0)
        {
            armorCount -= 1f;
            ArmorTimer();
            yield return new WaitForSeconds(1f);
        }
        armorCount = DefaltCount;
        isArmorBuffed = false;
        Player.instance.armor = playerArmor;
    }
}
