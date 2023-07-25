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

        public void Jump(GroundCheck groundCheck)
        {
            if (groundCheck.IsGround)
                _playerModel.GetRigidbody.AddForce(Vector2.up * _playerModel.JumpForce, ForceMode2D.Impulse);
        }
    }
}
