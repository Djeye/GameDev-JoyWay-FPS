using UnityEngine;

namespace joyway
{
    public class GarbageCollector : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}