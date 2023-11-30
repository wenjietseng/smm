using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelpersFunctions
{
    public static class Helpers
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            // https://forum.unity.com/threads/randomize-array-in-c.86871/
            // https://stackoverflow.com/questions/273313/randomize-a-listt
            // Knuth shuffle algorithm :: courtesy of Wikipedia :)
            for (int n = 0; n < list.Count; n++)
            {
                T tmp = list[n];
                int r = UnityEngine.Random.Range(n, list.Count);
                list[n] = list[r];
                list[r] = tmp;
            }
        }

        public static float DegreeToRadian(float deg)
        {
            return deg * Mathf.PI / 180;
        }
    }
}