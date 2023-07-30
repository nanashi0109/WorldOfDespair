using System.Collections;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerJump
    {
        private PlayerModel _playerModel;

        private bool _isJump = true;

        public PlayerJump(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public IEnumerator Jump(GroundCheck groundCheck, float jumpForce)
        {
            if (groundCheck.IsGround && _isJump)
            {
                _playerModel.GetAnimator.SetTrigger("JumpTrigger");
                _playerModel.GetRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                _isJump = false;
                yield return new WaitForSeconds(0.6f);
                _isJump = true;
            }
        }
    }
}
