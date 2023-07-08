using Leopotam.Ecs;

namespace Client {
    public class AnalyzerClickSystem : IEcsRunSystem 
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter;
        private GameState _gameState;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var ecsEntity = ref _filter.GetEntity(index);
                ecsEntity.Get<Taken>().value = _gameState.CurrentType;
                ecsEntity.Get<CheckWinEvent>();

                _gameState.CurrentType = _gameState.CurrentType == SingType.Ring ? SingType.Cross : SingType.Ring;

                _sceneData.UI.GameHUD.SetTurn(_gameState.CurrentType);
            }
        }
    }
}