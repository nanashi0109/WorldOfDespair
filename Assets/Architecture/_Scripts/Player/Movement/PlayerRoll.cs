using System.Collections;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerRoll
    {
        public bool IsRolling => _isRolling;

        private bool _isRolling = false;
        private bool _canRolling = true;

        private PlayerModel _playerModel;
        private PlayerInputSystem _playerInputSystem;

        public PlayerRoll (PlayerModel playerModel, PlayerInputSystem playerInputSystem)
        {
            _playerModel = playerModel;
            _playerInputSystem = playerInputSystem;
        }

        public IEnumerator RollUpdate(float rollForce, float rollColldown)
        {
            if (_playerInputSystem.ButtonRoll() && !_isRolling && _canRolling)
            {
                _playerModel.RollCollider.enabled = true;
                _playerModel.GetPlayerCollider.enabled = false;
                _playerModel.CrawlCollider.enabled = false;
                _playerModel.CrouchCollider.enabled = false;

                _playerModel.GetAnimator.SetTrigger("RollTrigger");

                _isRolling = true;
                _canRolling = false;
                _playerInputSystem._isButtonRoll = false;

                _playerModel.GetRigidbody.velocity = new Vector2(_playerModel.gameObject.transform.localScale.x * rollForce, 0);

                yield return new WaitForSeconds(1);

                _isRolling = false;


                _playerModel.GetPlayerCollider.enabled = true;
                _playerModel.RollCollider.enabled = false;

                yield return new WaitForSeconds(rollColldown);
                _canRolling = true;
            }  
        }
    }
}
