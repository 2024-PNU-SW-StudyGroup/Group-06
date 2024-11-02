using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 2f; // �̵� �ӵ�
    public float attackRange = 1f; // ���� ���� ����
    public float projectileSpeed = 5f; // ����ü �ӵ�
    public GameObject projectilePrefab; // ����ü ������
    public Transform player; // �÷��̾��� ��ġ
    public float shootInterval = 2f; // ����ü �߻� ����
    public bool isMelee; // ���� �������� ����
    private bool canShoot = true; // ����ü �߻� ���� ����
    private Vector3 startPosition; // ������ ���� ��ġ
    private Vector3 targetPosition; // ������ ��ǥ ��ġ

    void Start()
    {
        startPosition = transform.position; // ���� ��ġ ����
        targetPosition = startPosition; // ��ǥ ��ġ �ʱ�ȭ
    }

    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        // �Դ� ���� �ϴ� ����
        float distance = Mathf.PingPong(Time.time * moveSpeed, 3f); // �̵� ���� ����
        transform.position = new Vector3(startPosition.x + distance, startPosition.y, startPosition.z);
    }

    void Attack()
    {
        if (isMelee)
        {
            // ���� ����
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                // �÷��̾�� ���ظ� �ִ� ���� �߰�
                Debug.Log("Player damaged by melee monster!");
            }
        }
        else
        {
            // ���Ÿ� ����
            if (canShoot && Vector2.Distance(transform.position, player.position) <= 10f) // �����Ÿ� �������� �߻�
            {
                canShoot = false;
                Shoot();
                Invoke("ResetShoot", shootInterval); // �߻� ���� ����
            }
        }
    }

    void Shoot()
    {
        // ����ü �߻�
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed; // ����ü �ӵ� ����
    }

    void ResetShoot()
    {
        canShoot = true; // ����ü �߻� ���� ���·� �ʱ�ȭ
    }
}
