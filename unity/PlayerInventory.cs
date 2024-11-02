using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject currentWeapon; // ���� ����

    public void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            // ���� ���� ��Ȱ��ȭ (�Ǵ� ����)
            Destroy(currentWeapon);
        }

        // �� ���� ����
        currentWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        currentWeapon.transform.parent = transform; // �÷��̾��� �ڽ����� ����
    }
}
