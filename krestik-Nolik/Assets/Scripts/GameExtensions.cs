using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    public static class GameExtensions 
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
        {
            var startEntity = cells[position];
            if (!startEntity.Has<Taken>())
            {
                return 0;
            }
            var startType = startEntity.Ref<Taken>().Unref().value;
            var direction = new Vector2Int(-1, 0);
            var currentPosition = position + direction;

            var currentLength = 1;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    currentLength++;
                    currentPosition += direction;
                }
            }
            
            return currentLength;
        }
    }
}