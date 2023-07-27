using System.Data;
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
                _playerModel.CrouchCollider.enabled = true;
                _playerModel.GetPlayerCollider.enabled = false;
            }

            else
            {
                _playerModel.CrouchCollider.enabled = false;
                _playerModel.GetPlayerCollider.enabled = true;
            }

        }
    }
}
