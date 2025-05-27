using UnityEngine;

public enum ZombieState
{
    Run,
    Attack,
    Die
}

[RequireComponent(typeof(Animator))]
public class Zombie : Creature
{
    public ZombieDetectorController detectorController;
    private Animator animator;
    [SerializeField] public HealthBar healthBar;
    [SerializeField] private float speed = 1f;

    private ZombieState State
    {
        get
        {
            if (animator.GetBool("IsAttacking"))
            {
                return ZombieState.Attack;
            }
            else if (animator.GetBool("IsDead"))
            {
                return ZombieState.Die;
            }
            else
            {
                return ZombieState.Run;
            }
        }
    }

    public float Speed
    {
        get => speed;
        set
        {
            speed = value;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP = Mathf.Max(0, currentHP - dmg);
        UpdateHealthBar();

        if (currentHP <= 0)
            Die();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
            healthBar.SetHealthRatio((float)currentHP / maxHP);
    }

    private void Die()
    {
        // 사망 로직
    }

    private void Update()
    {
        // 테스트용 - 키 입력으로 상태 전환
        //if (Input.GetKeyDown(KeyCode.R)) ApplyState(ZombieState.Run);
        //if (Input.GetKeyDown(KeyCode.A)) ApplyState(ZombieState.Attack);
    }

    private void ApplyState(ZombieState newState)
    {
        if (newState == ZombieState.Run)
        {
            animator.speed = speed;
        }
        animator.Play(newState.ToString());
    }

    public void OnAttack()
    {
        animator.speed = 1f;
        Debug.Log("애니메이션 이벤트 OnAttack 호출!");
    }

    public void OnDead()
    {
        animator.speed = 1f;
        Debug.Log("애니메이션 이벤트 OnDead 호출!");
    }
}
