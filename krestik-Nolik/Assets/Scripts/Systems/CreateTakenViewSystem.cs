using System;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Client {
    public class CreateTakenViewSystem : IEcsRunSystem 
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> _filter;
        private Configuration _configuration;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var position = _filter.Get2(index).value.transform.position;
                var takenType = _filter.Get1(index).value;

                SingView singView = null;
                switch (takenType)
                {
                    case SingType.Cross:
                        singView = _configuration.CrossView;
                        break;
                    case SingType.Ring:
                        singView = _configuration.RingView;
                        break;
                        
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var instanse = Object.Instantiate(singView, position, Quaternion.identity);
                _filter.GetEntity(index).Get<TakenRef>().value = instanse;
            }            
        }
    }
}