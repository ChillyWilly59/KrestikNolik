using System;
using UnityEngine;
using UnityEngine.UI;

namespace Client {
    public class GameHud : MonoBehaviour 
    {
        public Text TurnLabel;
        
        public void SetTurn(SingType gameStateCurrentType)
        {
            switch (gameStateCurrentType)
            {   
                case SingType.Cross:
                    TurnLabel.text = "Ходит крестик";
                    break;
                case SingType.Ring:
                    TurnLabel.text = "Ходит нолик";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateCurrentType), gameStateCurrentType, null);
            }
        }
    }
}