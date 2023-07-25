using UnityEngine;
using Despair.Assets.Architecture._Scripts.Player;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerMovement
    {
        private PlayerModel _playerModel;
        private PlayerInputSystem _playerInputSystem;

        public PlayerMovement(PlayerModel playerModel, PlayerInputSystem playerInputSystem)
        {
            _playerModel = playerModel;
            _playerInputSystem = playerInputSystem;
        }

        public void Movement(Rigidbody2D rigidbody)
        {
            var horizontalVelocity = _playerInputSystem.GetHorizontalDirection * _playerModel.SpeedMovement;

            rigidbody.velocity = new Vector2(horizontalVelocity, rigidbody.velocity.y);
        }
    }
}
