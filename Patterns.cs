using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kreddik.UnityUtils.Patterns
{
    public class SingletonUnity<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        public virtual void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }else{
                _instance = this as T;
            }
        }
    }

}