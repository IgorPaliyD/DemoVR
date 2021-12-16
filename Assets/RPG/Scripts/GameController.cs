using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance = null;
        private static Character _character;

        public static Character CharachterInstance
        {
            get => _character;
        }

        void Start()
        {

            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            InitializeManager();
        }
        private void InitializeManager()
        {
            _character = FindObjectOfType<Character>();
        }
    }
}