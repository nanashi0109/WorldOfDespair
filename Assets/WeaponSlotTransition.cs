using UnityEngine;

namespace Despair
{
    public class WeaponSlotTransition : MonoBehaviour
    {
        [SerializeField] private Transform _rigRightArm;
        private void Update()
        {
            transform.localScale = GetComponentInParent<Transform>().localScale;
            transform.rotation = _rigRightArm.transform.rotation * Quaternion.Euler(0.0f, 0.0f, -180.0f);
        }
    }
}
