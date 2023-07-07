using UnityEngine;

namespace Client {
    [CreateAssetMenu]
    public class Configuration : ScriptableObject 
    {
        public int LevelWidth = 3;
        public int LevelHeigth = 3;
        public int ChainLengt = 3;
        public CellView CellView;
        public Vector2 Offset;
        public SingView CrossView;
        public SingView RingView;
    }
}