using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public int damage = 1; // ���ط�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // ���� �浹���� ��
        {
            // ���� ü�� ���� ������ �߰��մϴ�.
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // ������ ���ظ� �ִ� �޼��� ȣ��
                Debug.Log("Enemy hit!");
            }
        }
    }
}
