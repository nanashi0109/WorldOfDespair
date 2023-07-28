using System.Collections;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Despair
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject _target;

        [SerializeField] private Vector2 MinPositionFollow;
        [SerializeField] private Vector2 MaxPositionFollow;

        [SerializeField]private float _lerpSpeed;
        private Vector3 _cameraPosition;

        public void Init()
        {
            _cameraPosition.z = -10;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _cameraPosition, _lerpSpeed * Time.deltaTime);


            var targetPosition = _target.transform.position;

            if (targetPosition.x < MinPositionFollow.x)
            {
                _cameraPosition.x = MinPositionFollow.x;
            }
            else if (targetPosition.x > MaxPositionFollow.x)
            {
                _cameraPosition.x = MaxPositionFollow.x;
            }
            else
            {
                _cameraPosition.x = _target.transform.position.x;
            }


            if (targetPosition.y < MinPositionFollow.y)
            {
                _cameraPosition.y = MinPositionFollow.y;
            }
            else if(targetPosition.y > MaxPositionFollow.y)
            {
                _cameraPosition.y = MaxPositionFollow.y;
            }
            else
            {
                _cameraPosition.y = _target.transform.position.y;
            }
        }
    }
}
