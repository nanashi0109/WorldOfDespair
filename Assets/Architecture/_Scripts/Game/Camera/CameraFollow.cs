using UnityEngine;

namespace Despair
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject _target;

        [SerializeField] private Vector2 _minPositionFollow;
        [SerializeField] private Vector2 _maxPositionFollow;

        [SerializeField] private Vector2 _offsetPosition;

        [SerializeField]private float _lerpSpeed;


        private Vector3 _cameraPosition;
        private float halfHeight;
        private float halfWidth;

        public void Init()
        {
            _cameraPosition.z = -10;


        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _cameraPosition, _lerpSpeed * Time.deltaTime);


            var targetPosition = _target.transform.position;

            if (targetPosition.x < _minPositionFollow.x)
            {
                _cameraPosition.x = _minPositionFollow.x;
            }
            else if (targetPosition.x > _maxPositionFollow.x)
            {
                _cameraPosition.x = _maxPositionFollow.x;
            }
            else
            {
                _cameraPosition.x = _target.transform.position.x + _offsetPosition.x;
            }


            if (targetPosition.y < _minPositionFollow.y)
            {
                _cameraPosition.y = _minPositionFollow.y + _offsetPosition.y;
            }
            else if(targetPosition.y > _maxPositionFollow.y)
            {
                _cameraPosition.y = _maxPositionFollow.y;
            }
            else
            {
                _cameraPosition.y = _target.transform.position.y + _offsetPosition.y;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            halfHeight = (Camera.main.orthographicSize * 2) / 2;
            halfWidth = ((halfHeight * 2) * Screen.width / Screen.height) / 2;

            Gizmos.DrawLine(new Vector2(_minPositionFollow.x - halfWidth, _minPositionFollow.y - halfHeight), 
                new Vector2(_maxPositionFollow.x + halfWidth, _minPositionFollow.y - halfHeight)); //bottom
            Gizmos.DrawLine(new Vector2(_minPositionFollow.x - halfWidth, _maxPositionFollow.y + halfHeight), 
                new Vector2(_maxPositionFollow.x + halfWidth, _maxPositionFollow.y + halfHeight)); // top

            Gizmos.DrawLine(new Vector2(_minPositionFollow.x - halfWidth, _minPositionFollow.y - halfHeight), 
                new Vector2(_minPositionFollow.x - halfWidth, _maxPositionFollow.y + halfHeight)); //left
            Gizmos.DrawLine(new Vector2(_maxPositionFollow.x + halfWidth, _minPositionFollow.y - halfHeight), 
                new Vector2(_maxPositionFollow.x + halfWidth, _maxPositionFollow.y + halfHeight)); //right
        }
    }
}
