using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HitMarks.Patches
{
    [HarmonyPatch(typeof(EnemyAI), "HitEnemyOnLocalClient")]
    internal class EnemyAIPatch
    {
        public static void Postfix(EnemyAI __instance)
        {
            GameObject gm = UnityEngine.Object.Instantiate(Plugin.newUI);
            __instance.StartCoroutine(Utils.DeleteAfter1Sec(gm, __instance));
        }
    }
}

namespace HitMarks
{
    public class Utils
    {
        public static IEnumerator DeleteAfter1Sec(GameObject gm, MonoBehaviour mono)
        {
            yield return new WaitForSeconds(1);
            UnityEngine.Object.Destroy(gm);
        }
    }
}
