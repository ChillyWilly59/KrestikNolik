using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Client {
    public class WinScreen : Screen 
    {
        public Text Text;
        
        public void SetWinner(SingType value)
        {
            switch (value)
            {
                case SingType.Cross:
                    Text.text = "Крестик победил";
                    break;
                case SingType.Ring:
                    Text.text = "Нолик победил";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);

            }
        }

        public void OnRestertClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}