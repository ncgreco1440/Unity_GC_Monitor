using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overtop.Utils
{
    public class PositionChanger : MonoBehaviour
    {
        private bool m_ActivePosOn = true;
        public Vector3 pos1;
        public Vector3 pos2;

        private Transform m_Transform;

        private void Awake()
        {
            m_Transform = GetComponent<Transform>();
        }

        public void SwapPositions()
        {

        }
    }
}