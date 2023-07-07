using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    public class GameState 
    {
        public SingType CurrentType = SingType.Cross;
        public readonly Dictionary<Vector2Int, EcsEntity> Cells = new Dictionary<Vector2Int, EcsEntity>();
    }
}