using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    internal class SetCameraSystem : IEcsRunSystem 
    {
        private EcsFilter<UpdateCameraSystem> _filter;
        private SceneData SceneData;
        private Configuration _configuration;

        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                var height = _configuration.LevelHeigth;
                var width = _configuration.LevelWidth;

                var camera = SceneData.Camera;
                camera.orthographic = true;
                camera.orthographicSize = height / 2f + (height - 1) * _configuration.Offset.y / 2;

                SceneData.CameraTransform.position = new Vector3(width / 2f + (width - 1) * _configuration.Offset.y / 2,
                    height / 2f + (height - 1) * _configuration.Offset.y / 2);
            }
        }
    }
}