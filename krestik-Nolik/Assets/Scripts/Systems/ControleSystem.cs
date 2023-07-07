using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    public class ControleSystem : IEcsRunSystem 
    {
        private SceneData _sceneData;
        
        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var camera = _sceneData.Camera;
                var rey = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rey, out var hitInfo))
                {
                    var cellView = hitInfo.collider.GetComponent<CellView>();
                    if (cellView)
                    {
                        cellView.Entity.Get<Clicked>();
                    }
                }
            }
        }
    }
}