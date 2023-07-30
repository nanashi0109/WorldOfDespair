using Despair.Assets.Architecture._Scripts.Player;
using UnityEngine;

namespace Despair
{
    public class PickUpWeapon : SelectedItem
    {
        public override void PickUp(GameObject player)
        {
            player.GetComponent<PlayerPickUpWeapon>().ThrowWeapon();
            player.GetComponent<PlayerPickUpWeapon>().EquipWeapon(gameObject);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerModel>() != null)
            {
                if(Input.GetKeyDown(KeyCode.E))
                    PickUp(collision.gameObject);
            }
        }
    }
}
