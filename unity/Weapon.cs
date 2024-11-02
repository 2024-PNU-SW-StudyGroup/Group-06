using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float dropForce = 5f; // ������ ���� ��

    void Start()
    {
        // �ʱ� �ӵ� ���� (�ɼ�)
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
        }
    }
}
