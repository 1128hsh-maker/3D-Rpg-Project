using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngineInternal;
using static UnityEditor.Experimental.GraphView.GraphView;
public enum PlayerState
{
    Move,
    Attack,
}

public class Player : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    public float maxMP = 100f;
    public float currentMP;
    public float damage = 20f;
    public float armor = 10f;
    public float level = 1;
    public float maxEXP;
    public float currentEXP = 0;
    public int gold = 0;
    public int dia = 0;
    public Rigidbody rb;
    [SerializeField] private float power = 5f;
    [SerializeField] private float attackCool = 1f;
    private RaycastHit hit;
    private PlayerState state = PlayerState.Move;
    private bool isAttacking = false;
    private Enemy enemy;
    public float radius = 5f;
    public LayerMask enemyLayer;
    public Collider[] colliders;
    public Collider shortEnemy;





    public static Player instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        maxEXP = level * 100;
        currentHP = maxHP;
        currentMP = maxMP;
    }
    void Update()
    {
        
        switch (state)
        {
            case PlayerState.Move:
                MoveState();
                LookEnemy();
                break;
            case PlayerState.Attack:
                if (!isAttacking)
                    StartCoroutine(Attack());
                break;
        }
    }
    void MoveState()
    {
        rb.AddForce(Vector3.forward * power, ForceMode.Acceleration);
    }

    void LookEnemy()
    {
        colliders = Physics.OverlapSphere(transform.position,radius, enemyLayer);

        if (colliders.Length > 0)
        {
            rb.velocity = Vector3.zero;
            state = PlayerState.Attack;
            float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            shortEnemy = colliders[0];
            foreach (Collider col in colliders) // 가장 가까운 적 찾기
            {
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if (short_distance > short_distance2)
                {
                    short_distance = short_distance2;
                    shortEnemy = col;
                }
            }
            if (shortEnemy != null)
            {
                shortEnemy.TryGetComponent<Enemy>(out enemy);
            }
        }
    }
    public IEnumerator Attack() //캐릭터가 몬스터를 공격하는 메서드 (나중에 인터페이스로 변경할 예정)
    {
        isAttacking = true;
        if (enemy == null)
        {
            state = PlayerState.Move;
            isAttacking = false;
            yield break;
        }
        BlowEnemy();
        yield return new WaitForSeconds(attackCool);
        isAttacking = false;
    }
    public float BlowEnemy() //(나중에 인터페이스로 변경할 예정)
    {
        float actualDamage = damage - enemy.enemyData.armor;
        if (actualDamage < 0)
        {
            actualDamage = 0;
        }
        enemy.currentHP -= actualDamage;
        if (enemy.currentHP <= 0)
        {
            enemy.currentHP = 0;
            gold += enemy.enemyData.gold;
            currentEXP += enemy.enemyData.exp;
            if (currentEXP >= maxEXP)
            {
                level++;
                currentEXP = currentEXP - maxEXP;
                maxEXP = level * 100;
                maxHP += 20f;
                currentHP = maxHP;
                damage += 5f;
                armor += 2f;
            }
            Condition.instance.CheckEXP(); //*UI EXP 갱신
            state = PlayerState.Move;
            Destroy(enemy.gameObject);

            Quest.instance.currentQuestIndex += 1;
            Quest.instance.TextUpDate();
        }

        return actualDamage;
    }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
}


