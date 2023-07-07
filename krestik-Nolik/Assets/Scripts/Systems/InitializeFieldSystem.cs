using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    internal class InitializeFieldSystem : IEcsInitSystem 
    {
        private Configuration _configuration;
        private EcsWorld _world;
        private GameState _gameState;
        
        public void Init()
        {
            for (int x = 0; x < _configuration.LevelWidth; x++)
            {
                for (int y = 0; y < _configuration.LevelHeigth; y++)
                {
                    var cellEntity = _world.NewEntity();
                    cellEntity.Get<Cell>();
                    var position = new Vector2Int(x,y);
                    cellEntity.Get<Position>().value = position;

                    _gameState.Cells[position] = cellEntity;
                }
            }

            _world.NewEntity().Get<UpdateCameraSystem>();
        }
    }
}