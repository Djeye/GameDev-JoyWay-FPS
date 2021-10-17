using System;
using System.Collections;
using System.Collections.Generic;
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
