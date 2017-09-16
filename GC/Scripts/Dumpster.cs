using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overtop.Utils
{
    public class Dumpster : MonoBehaviour
    {
        int m_Iter = 0;
        //Vector3[] x = new Vector3[10000];

        private void Update()
        {
            /** 
             * Setting the newly allocated array to 100,000,000 is going to be allocating over 1GB per Update loop.
             * The result will be extremely choppy animations roughly 10-15ish FPS on a GTX 1060 w/ core i7 6700 HQ 
             * Machines with better specs will be able to push for maybe 1 - 2 billion Vector3s and lower tiered machines
             * probably don't want to go any higher. My best guess is a system crash is your worst case scenario.
             */

            /**
             * What hurts performance is allocation of large chunks/lots of individual memory
             * very frequently, and then not using them for very long.
             */
            //Vector3[] x = new Vector3[10000];

            /**
             * For large chunks of memory that have been paid for up-front, reassignment of
             * that memory costs nothing from a memory standpoint. 
             */
            //for (; m_Iter < 10000; m_Iter++)
            //    x[m_Iter] = new Vector3(0, 0, 0);
            //m_Iter = 0;
        }
    }
}