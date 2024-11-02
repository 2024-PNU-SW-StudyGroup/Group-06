using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // �ִ� ü��
    private int currentHealth; // ���� ü��

    void Start()
    {
        currentHealth = maxHealth; // ���� ü���� �ִ� ü������ �ʱ�ȭ
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ü�� ����
        Debug.Log("Player damaged! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // �״� �޼��� ȣ��
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // ���� ���� ���� �߰� (��: �����, ���� ��)
        Destroy(gameObject); // �÷��̾� ����
    }
}
