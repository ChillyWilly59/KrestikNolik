﻿using UnityEngine;

namespace Client {
    public class Screen : MonoBehaviour 
    {
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}