using System;
using Atomic.Entities;
using Game.View;
using SampleGame;
using UnityEngine;

namespace Game
{
    [DefaultExecutionOrder(-100)]
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameContextInstaller _gameContextInstaller;

        private EntityUpdater _entityUpdater;
        private EntityWorld _entityWorld;

        private void Awake()
        {
            var gameContext = GameContext.Instance;
            var viewContext = ViewContext.Instance;

            _entityUpdater = new EntityUpdater(viewContext, gameContext);
            _entityWorld = new EntityWorld();
            
            gameContext.AddEntityWorld(_entityWorld);
            _gameContextInstaller.Install(gameContext);
            
            _entityUpdater.Init();
            _entityWorld.Init();
        }

        private void Start()
        {
            _entityUpdater.Enable();
            _entityWorld.Enable();
        }

        private void Update()
        {
            _entityUpdater.OnUpdate(Time.deltaTime);
            _entityWorld.OnUpdate(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _entityUpdater.OnLateUpdate(Time.deltaTime);
            _entityWorld.OnLateUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _entityUpdater.OnFixedUpdate(Time.fixedDeltaTime);
            _entityWorld.OnFixedUpdate(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _entityUpdater.Disable();
            _entityWorld.Disable();
            
            _entityUpdater.Dispose();
            _entityWorld.Dispose();
        }
    }
}