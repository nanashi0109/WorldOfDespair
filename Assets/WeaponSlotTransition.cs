using UnityEngine;

namespace Despair
{
    public class WeaponSlotTransition : MonoBehaviour
    {
        [SerializeField] private Transform _rigWeapon;

        private void Update()
        {
            transform.position = _rigWeapon.transform.position;
            transform.rotation = _rigWeapon.transform.rotation * Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }
    }
}
