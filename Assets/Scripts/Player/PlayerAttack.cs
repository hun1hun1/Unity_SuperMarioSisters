using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1.0f;
    public LayerMask enemyLayer;
    public float attackCoolTime = 1.0f;
    
    private bool isAttacking = false;
    private bool canAttack = true;
    private float coolTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        UpdateCoolTimer();
        CheckAttackInput();
        ChangeCanAttack();
        ChangeAttackRange();
    }

    void CheckAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.X) == true || Input.GetKeyDown(KeyCode.C) == true)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (attackPoint == null)
        {
            return;
        }

        if (canAttack == false)
        {
            Debug.Log("공격 불가 상태입니다.");
            return;
        }

        if (isAttacking == true)
        {
            Debug.Log("공격 쿨타임입니다.");
            return;
        }

        isAttacking = true;

        Collider2D detectedEnemy = FindEnemyInRange();

        if (detectedEnemy != null)
        {
            Debug.Log("공격 범위 안의 적: " + detectedEnemy.name);
        }
        else
        {
            Debug.Log("공격 범위 안에 적이 없습니다.");
        }

        StartCoolTime();
    }

    void ChangeCanAttack()
    {
        if (Input.GetKeyDown(KeyCode.K) == true)
        {
            canAttack = !canAttack;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void StartCoolTime()
    {
        coolTimer = attackCoolTime;
        Debug.Log("공격 쿨타임이 시작되었습니다.");
    }

    void UpdateCoolTimer()
    {
        if (isAttacking == false)
        {
            return;
        }

        coolTimer = coolTimer - Time.deltaTime;

        if (coolTimer <= 0)
        {
            isAttacking = false;
            Debug.Log("공격 쿨타임이 끝났습니다.");
        }
    }

    void ChangeAttackRange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            attackRange = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            attackRange = 1.5f;
        }
    }

    Collider2D FindEnemyInRange()
    {
        return Physics2D.OverlapCircle(attackPoint.position, attackRange, enemyLayer);
    }
}

