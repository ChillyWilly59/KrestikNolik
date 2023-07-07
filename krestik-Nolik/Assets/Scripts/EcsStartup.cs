using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        public Configuration Configuration;
        public SceneData SceneData;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            var gameState = new GameState();
            
            _systems
                // register your systems here, for example:
                .Add (new InitializeFieldSystem ())
                .Add(new CreateCellViewSystem())
                .Add(new SetCameraSystem())
                .Add(new ControleSystem())
                .Add (new AnalyzerClickSystem())
                .Add(new CreateTakenViewSystem())
                .Add(new CheckWinSystem())
                
                // register one-frame components (order is important), for example:
                .OneFrame<UpdateCameraSystem> ()
                .OneFrame<Clicked> ()
                .OneFrame<CheckWinEvent> ()
                
                // inject service instances here (order doesn't important), for example:
                .Inject (Configuration)
                .Inject(SceneData)
                .Inject (gameState)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}