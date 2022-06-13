using UnityEngine;
using UnityEditor;
using EasySkillSystem.Base;
using EasySkillSystem.Base.Generic;

public class PlayerItemCollector : MonoBehaviour
{
    // Debug Player Demonstraition
    // this script tests a situation where player obtained item.
    // collection input is replaced with collision.
    [SerializeField] float collectionDistance = 10;

    PlayerInventory playerInventory;
    PlayerEquipmentManager playerEquipmentManager;
    InputManager inputManager;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collectionDistance);

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        Handles.Label(transform.position + Vector3.up * collectionDistance + Vector3.up*.1f, "Collection Distance", style);
    }

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerEquipmentManager = GetComponent<PlayerEquipmentManager>();
        inputManager = InputManager.Instance;
        inputManager.OnCollect += delegate () {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, collectionDistance, transform.forward, float.Epsilon);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.TryGetComponent(out Item item))
                {
                    playerInventory.Obtain(item.Obtain(GetComponent<Status>()));
                }
            }
        };
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            if (item.TryGetComponent(out EquipableItem equipableItem))
            {
                //collision == item and also equippable

                if(equipableItem.TryGetComponent(out Rigidbody targetRigidbody))
                {
                    Destroy(targetRigidbody);
                }

                playerEquipmentManager.Equip(equipableItem.Equip(GetComponent<Status>()));
            }
            else
            {
                //collision == item but not equippable

            }
        }
        else
        {
            //collision != item
            Debug.Log("Collided with non-item: " + collision.transform.name);
        }
    }
}
