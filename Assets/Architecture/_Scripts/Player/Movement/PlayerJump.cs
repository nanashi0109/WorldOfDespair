using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerJump
    {
        private PlayerModel _playerModel;

        public PlayerJump(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Jump(GroundCheck groundCheck, float jumpForce)
        {
            if (groundCheck.IsGround)
            {
                _playerModel.GetAnimator.SetTrigger("JumpTrigger");
                _playerModel.GetRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            }
        }
    }
}
