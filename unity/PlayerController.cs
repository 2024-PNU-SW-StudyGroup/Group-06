using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �⺻ �̵� �ӵ�
    public float runSpeed = 10f; // �޸��� �ӵ�
    public float jumpForce = 10f; // ���� ��
    public float rollDuration = 0.5f; // ������ ���� �ð�
    public float climbSpeed = 3f; // ��Ÿ�� �ӵ�
    public LayerMask groundLayer; // �� ���̾�
    public LayerMask wallLayer; // �� ���̾�
    public GameObject attackCollider; // ���� �ݶ��̴� ������
    private Rigidbody2D rb; // Rigidbody2D ������Ʈ
    private bool isGrounded; // ���� ��� �ִ��� ����
    private bool isRolling; // ������ ������ ����
    private bool isClimbing; // ��Ÿ�� ������ ����
    private bool isAttacking; // ���� ������ ����
    private float rollTimer; // ������ Ÿ�̸�
    private PlayerHealth playerHealth; // �÷��̾� ü�� ��ũ��Ʈ ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ �ʱ�ȭ
        attackCollider.SetActive(false); // ���� �ݶ��̴� ��Ȱ��ȭ
        playerHealth = GetComponent<PlayerHealth>(); // PlayerHealth ������Ʈ �ʱ�ȭ
    }

    void Update()
    {
        if (!isClimbing)
        {
            Move();
            Jump();
            Roll();
            Attack();
            Defend();
            Parry();
        }
        else
        {
            Climb();
        }
    }

void Move()
    {
        if (!isRolling && !isAttacking)
        {
            float moveInput = Input.GetAxis("Horizontal"); // �¿� �Է� �ޱ�
            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed; // Shift Ű�� �޸���
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // �̵� ����
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // ���� �� �߰�
        }
    }

    void Roll()
    {
        if (Input.GetButtonDown("Fire1") && !isRolling && !isAttacking)
        {
            isRolling = true;
            rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y); // ������ �ӵ� ����
            rollTimer = rollDuration; // Ÿ�̸� ����
        }

        if (isRolling)
        {
            rollTimer -= Time.deltaTime;
            if (rollTimer <= 0)
            {
                isRolling = false; // ������ ����
            }
        }
    }

    void Climb()
    {
        float climbInput = Input.GetAxis("Vertical"); // ���Ʒ� �Է� �ޱ�
        rb.velocity = new Vector2(rb.velocity.x, climbInput * climbSpeed); // ��Ÿ�� �ӵ� ����

        // ��Ÿ�� �� ����
        if (Input.GetButtonDown("Jump"))
        {
            isClimbing = false; // ��Ÿ�� ����
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // ����
        }

        // ��Ÿ�� ���� �� ����
        if (!IsTouchingWall())
        {
            isClimbing = false; // ��Ÿ�� ����
        }
    }

    private bool IsTouchingWall()
    {
        // �÷��̾ ���� ��� �ִ��� üũ
        return Physics2D.OverlapCircle(transform.position, 0.1f, wallLayer);
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire2") && !isRolling && !isAttacking)
        {
            isAttacking = true;
            attackCollider.SetActive(true); // ���� �ݶ��̴� Ȱ��ȭ
            Invoke("ResetAttack", 0.5f); // ���� �� ���� �ʱ�ȭ
        }
    }

    void ResetAttack()
    {
        isAttacking = false; // ���� ���� �ʱ�ȭ
        attackCollider.SetActive(false); // ���� �ݶ��̴� ��Ȱ��ȭ
    }

    void Defend()
    {
        // ��� ���� �߰� (��: ��� �ִϸ��̼�)
        if (Input.GetKey(KeyCode.Z))
        {
            // ��� ����
            Debug.Log("Player is defending!");
        }
    }

    void Parry()
    {
        // �и� ���� �߰� (��: �� ������ ���� ����)
        if (Input.GetKeyDown(KeyCode.X))
        {
            // �и� ����
            Debug.Log("Player performed a parry!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ����� ��
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }

        // ���� �浹���� ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // �÷��̾�� ���ظ� �ִ� ���� (��: ���� ����)
            playerHealth.TakeDamage(1); // ���ط��� 1�� ����
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        // ������ �������� ��
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // ���� ����� ��
        if (((1 << collider.gameObject.layer) & wallLayer) != 0)
        {
            isClimbing = true; // ��Ÿ�� ����
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // ������ �������� ��
        if (((1 << collider.gameObject.layer) & wallLayer) != 0)
        {
            isClimbing = false; // ��Ÿ�� ����
        }
    }


}
