using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class GroundCheck : MonoBehaviour
    {
        public bool IsGround { get; private set; }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                IsGround = false;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                IsGround = true;
            }
        }
    }
}
