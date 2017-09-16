using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overtop.Utils
{
    public class MaterialChanger : MonoBehaviour
    {
        private bool m_activeMaterialOn = true;
        private MeshRenderer m_Mesh;
        public Material m_Material1;
        public Material m_Material2;

        public void Awake()
        {
            m_Mesh = GetComponent<MeshRenderer>();
        }

        public void SwapMaterial()
        {
            m_Mesh.material = m_activeMaterialOn ? m_Material1 : m_Material2;
            m_activeMaterialOn = !m_activeMaterialOn;
        }
    }
}