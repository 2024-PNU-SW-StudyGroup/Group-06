using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public float parallaxEffectMultiplier; // ����� �з����� ȿ�� ���
    public Vector2 minPosition; // ����� �ּ� ��ġ (���� ��)
    public Vector2 maxPosition; // ����� �ִ� ��ġ (������ ��)

    private Vector3 lastPlayerPosition; // ������ �÷��̾� ��ġ

    void Start()
    {
        lastPlayerPosition = player.position; // ������ ���� �÷��̾� ��ġ ����
    }

    void Update()
    {
        // �÷��̾��� �̵��� ���
        float deltaX = player.position.x - lastPlayerPosition.x;

        // ��� �̵�
        transform.position += new Vector3(deltaX * parallaxEffectMultiplier, 0, 0);

        // ��� ��ġ ����
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x),
            transform.position.y,
            transform.position.z
        );

        lastPlayerPosition = player.position; // ������ �÷��̾� ��ġ ������Ʈ
    }
}
