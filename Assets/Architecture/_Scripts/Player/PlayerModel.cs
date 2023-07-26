using Despair.Assets.Architecture._Scripts.Player.Movement;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player
{
    public class PlayerModel : MonoBehaviour
    {
        #region Properties
        public bool IsMove { get; set; } = true;

        public float WalkingSpeed => _walkingSpeed;
        public float RunningSpeed => _runningSpeed;
        public float JumpForce => _jumpForce;
        public Rigidbody2D GetRigidbody => _rigidbody;
        public Animator GetAnimator => _animator;
        #endregion


        #region Field
        [Header("Movement Data")]
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _runningSpeed;
        [SerializeField] private float _jumpForce;
        #endregion

        #region Links
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        [SerializeField] private GroundCheck _groundCheck;
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;
        private PlayerInputSystem _playerInputSystem;
        #endregion

        public void Init()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            _playerInputSystem = new PlayerInputSystem();
            _playerJump = new PlayerJump(this);
            _playerMovement = new PlayerMovement(this, _playerInputSystem);
        }

        private void FixedUpdate()
        {
            _playerMovement.FixedUpdateMovement();
        }

        private void Update()
        {
            _playerInputSystem.UpdateInputSystem();
            AnimationUpdate();

            if (_playerInputSystem.IsJump)
                _playerJump.Jump(_groundCheck);
        }

        private void AnimationUpdate()
        {
            _animator.SetBool("IsWalk", _playerMovement.IsWalk);
            _animator.SetBool("IsRun", _playerMovement.IsRun);
            _animator.SetFloat("HorizontalVelocity", Mathf.Abs(_playerMovement.HorizontalVelocity));
            _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
            _animator.SetBool("IsGround", _groundCheck.IsGround);
        }
    }
}
