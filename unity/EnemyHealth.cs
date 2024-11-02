using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // �ִ� ü��
    private int currentHealth; // ���� ü��
    public GameObject weaponPrefab; // ������ ���� ������

    void Start()
    {
        currentHealth = maxHealth; // ���� ü���� �ִ� ü������ �ʱ�ȭ
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ü�� ����
        Debug.Log("Enemy damaged! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // �״� �޼��� ȣ��
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        DropWeapon(); // ���� ����߸���
        Destroy(gameObject); // �� ����
    }

    void DropWeapon()
    {
        if (weaponPrefab != null)
        {
            // ���� ��ġ�� ���� ����
            GameObject weapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // �ణ�� ���� �༭ ���⸦ ����߸�
                rb.AddForce(new Vector2(Random.Range(-2f, 2f), 2f), ForceMode2D.Impulse);
            }
        }
    }
}
