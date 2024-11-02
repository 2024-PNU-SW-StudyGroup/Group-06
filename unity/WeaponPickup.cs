using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; // �ֿ� ���� ������
    public float pickupRadius = 1f; // �ֿ� �� �ִ� ����

    void Update()
    {
        // �÷��̾ �ֿ� �� �ִ��� üũ
        if (Input.GetKeyDown(KeyCode.E)) // E Ű�� �ֿ�
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player")) // �÷��̾�� �浹�� ��
                {
                    // ���� �ֿ�� ����
                    PickupWeapon();
                    break;
                }
            }
        }
    }

    void PickupWeapon()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null && weaponPrefab != null)
        {
            playerInventory.EquipWeapon(weaponPrefab); // �÷��̾��� �κ��丮�� ���� �߰�
        }

        Debug.Log("Weapon picked up!");
        Destroy(gameObject); // ���� ������Ʈ ����
    }

}
