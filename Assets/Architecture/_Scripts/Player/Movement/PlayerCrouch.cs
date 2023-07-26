using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerCrouch
    {
        private PlayerModel _playerModel;

        public PlayerCrouch(PlayerModel playerModel) 
        {
            _playerModel = playerModel;
        }

        public void Crouch(bool isButtonCrouch)
        {
            if (isButtonCrouch)
            {
                _playerModel.GetPlayerCollider.size = new Vector2(0.375f, 1);
                _playerModel.GetPlayerCollider.offset = new Vector2(0, 1);
            }
            else
            {
                _playerModel.GetPlayerCollider.size = _playerModel.DefaultColliderSize;
                _playerModel.GetPlayerCollider.offset = _playerModel.DefaultColliderOffset;
            }
        }
    }
}
