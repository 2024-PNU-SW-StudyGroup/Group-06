using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifespan = 2f; // ����ü ���� �ð�
    public int damage = 1; // ����ü ���ط�

    void Start()
    {
        Destroy(gameObject, lifespan); // ������ �ð� �� ����ü ����
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // �÷��̾�� ���ظ� �ִ� ���� �߰�
            Debug.Log("Player hit by projectile!");
            // ���� ������ ���⿡ �߰��� �� �ֽ��ϴ� (��: PlayerHealth ��ũ��Ʈ ����)
            Destroy(gameObject); // ����ü ����
        }
    }
}
