using UnityEngine;
using System.Collections;

namespace Overtop.Utils
{
    public class CoroutineTimer : MonoBehaviour
    {
        private MaterialChanger m_MaterialChanger;
        public float m_IterationDuration = 1.0f;

        private void Start()
        {
            m_MaterialChanger = GetComponent<MaterialChanger>();
            StartCoroutine(ActivateOnTimer());
        }

        private void OnEnable()
        {
            if(m_MaterialChanger != null)
                StartCoroutine(ActivateOnTimer());
        }

        private void OnDisable()
        {
            StopCoroutine(ActivateOnTimer());
        }

        private IEnumerator ActivateOnTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(m_IterationDuration);
                m_MaterialChanger.SwapMaterial();
            }
        }
    }
}