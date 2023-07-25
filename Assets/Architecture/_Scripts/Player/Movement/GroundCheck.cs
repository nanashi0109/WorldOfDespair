using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class GroundCheck : MonoBehaviour
    {
        public bool IsGround { get; private set; }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                IsGround = false;
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                IsGround = true;
            }
        }
    }
}
