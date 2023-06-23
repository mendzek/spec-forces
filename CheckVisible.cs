using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SF
{
    public class CheckVisible : MonoBehaviour
    {
        InteractionWithObjects IWO;
        public void OnBecameVisible()
        {
            //IWO.canSee = true;
            //Debug.Log("can see");
        }
        public void OnBecameInvisible()
        {
            //IWO.canSee = false;
            //Debug.Log("can not see");
        }
    }
}
