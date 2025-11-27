using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public float currentHP;
    private bool isAttacking = false;
    private Player player;
    public float radius = 5f;
    public LayerMask playerLayer;
    public Collider[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = enemyData.hp;
    }

    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);
        if(colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                col.TryGetComponent<Player>(out player);
                if (player != null)
                {
                    if (!isAttacking)
                    {
                        StartCoroutine(Attack());
                    }
                }
            }
        }
    }
    public IEnumerator Attack()
    {
        isAttacking = true;
        if (player == null)
        {
            isAttacking = false;
            yield break;
        }
        
        BlowPlayer();
        yield return new WaitForSeconds(enemyData.attackCool);
        isAttacking = false;
    }

    public float BlowPlayer() //몬스터가 캐릭터를 공격하는 메서드
    {
        float actualDamage = enemyData.damage - player.armor;
        if (actualDamage < 0)
        {
            actualDamage = 0;
        }
        player.currentHP -= actualDamage;
        if (player.currentHP < 0)
        {
            player.currentHP = 0;
        }
        Condition.instance.CheckHP(); //*UI HP 갱신

        return actualDamage;
    }
}
