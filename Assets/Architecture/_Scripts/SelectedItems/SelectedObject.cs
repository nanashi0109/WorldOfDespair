using Despair.Assets.Architecture._Scripts.Player;
using UnityEngine;

namespace Despair
{
    public class SelectedObject : SelectedItem
    {
        [SerializeField] private bool _inInventory;
        public override void PickUpInHand(GameObject player)
        {
            player.GetComponent<PlayerSelectObject>().EquipWeapon(gameObject);
        }

        public override void PickUpInInventory(GameObject player)
        {
            // TODO : add pick up object in inventory
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerModel>() == null)
                return;

            if (Input.GetKey(KeyCode.E))
            {
                if (_inInventory)
                {
                    PickUpInInventory(collision.gameObject);
                }
                else
                {
                    PickUpInHand(collision.gameObject);
                }
            }
        }
    }
}
