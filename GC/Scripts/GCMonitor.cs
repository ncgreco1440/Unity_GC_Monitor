using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overtop.Utils
{
    public class GCMonitor : MonoBehaviour
    {
        public int m_MaxGenerations = 0;

        [Tooltip("Average time between Garbage Collection")]
        public float m_AverageDownTime = 0.0f;
        [Tooltip("Splits of last 10 down times.")]
        public float[] m_Splits = { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        private float m_TimeSplit = 0.0f;
        private int m_Iter = 0;

        private long m_GenZeroCollectionCountSt = 0;
        private long m_GenOneCollectionCountSt = 0;
        private long m_GenTwoCollectionCountSt = 0;

        public long m_GenZeroCollectionCount = 0;
        public long m_GenOneCollectionCount = 0;
        public long m_GenTwoCollectionCount = 0;

        [Tooltip("Memory in Bytes")]
        public long m_TotalBytes = 0;
        [Tooltip("Memory in Kilobytes")]
        public long m_TotalKiloBytes = 0;
        [Tooltip("Memory in Megabytes")]
        public long m_TotalMegaBytes = 0;
        [Tooltip("Memory in Gigabytes")]
        public long m_TotalGigaBytes = 0; // Server use only

        private void Start()
        {
            m_MaxGenerations = GC.MaxGeneration;
            m_GenZeroCollectionCountSt = GC.CollectionCount(0);
            m_GenOneCollectionCountSt = GC.CollectionCount(1);
            m_GenTwoCollectionCountSt = GC.CollectionCount(2);
        }

        private void Update()
        {
            m_TimeSplit += Time.unscaledDeltaTime;

            if (GC.CollectionCount(0) - m_GenZeroCollectionCountSt != m_GenZeroCollectionCount)
            {
                m_Splits[m_Iter++] = m_TimeSplit;
                m_TimeSplit = 0.0f;
                UpdateGCDownTime();
            }

            m_GenZeroCollectionCount = GC.CollectionCount(0) - m_GenZeroCollectionCountSt;
            m_GenOneCollectionCount = GC.CollectionCount(1) - m_GenOneCollectionCountSt;
            m_GenTwoCollectionCount = GC.CollectionCount(2) - m_GenTwoCollectionCountSt;

            m_TotalBytes = GC.GetTotalMemory(false);
            m_TotalKiloBytes = m_TotalBytes / 1000;
            m_TotalMegaBytes = m_TotalKiloBytes / 1000;
            m_TotalGigaBytes = m_TotalMegaBytes / 1000;
        }

        private void UpdateGCDownTime()
        {
            float sum = 0.0f;
            for(int i = 0; i < m_Iter; i++)
            {
                sum += m_Splits[i];
            }
            m_AverageDownTime = sum / m_Iter;
            if (m_Iter > 9) //Reset m_Iter if necessary
                m_Iter = 0;
        }
    }
}