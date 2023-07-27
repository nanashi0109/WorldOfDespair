using System.Collections;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerRoll
    {
        private bool _isRolling = true;

        private PlayerModel _playerModel;
        private PlayerInputSystem _playerInputSystem;

        public PlayerRoll (PlayerModel playerModel, PlayerInputSystem playerInputSystem)
        {
            _playerModel = playerModel;
            _playerInputSystem = playerInputSystem;
        }

        public IEnumerator RollUpdate(float rollForce, float rollColldown)
        {
            if (_playerInputSystem.IsButtonRoll && _isRolling)
            {
                _playerModel.GetPlayerCollider.enabled = false;
                _playerModel.RollCollider.enabled = true;

                _playerModel.GetAnimator.SetTrigger("RollTrigger");
                _isRolling = false;
                _playerInputSystem.IsButtonRoll = false;

                _playerModel.GetRigidbody.velocity = new Vector2(_playerModel.gameObject.transform.localScale.x * rollForce, 0);
                yield return new WaitForSeconds(1.4f);


                _playerModel.GetPlayerCollider.enabled = true;
                _playerModel.RollCollider.enabled = false;

                yield return new WaitForSeconds(rollColldown);
                _isRolling = true;
            }
            else
            {
                yield return null;
            }
                
        }
    }
}
