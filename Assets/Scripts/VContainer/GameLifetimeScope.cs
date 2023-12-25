using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GameObject _characterPrefab;
    //[SerializeField] private BulletConfig _bulletConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<GameManager>().AsSelf();

        builder.Register(_ =>
        {
            using (EnqueueParent(this))
            {
                return Instantiate(_characterPrefab);
            }
        }, Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<GameCountableLauncher>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<LevelBackground>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<MoveInput>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<FireInput>().AsImplementedInterfaces().AsSelf();

        builder.RegisterComponentInHierarchy<EnemyPool>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<EnemySpawner>().AsImplementedInterfaces().AsSelf();
        builder.Register<EnemyManager>(Lifetime.Singleton).AsSelf();

        builder.Register<CharacterHitPointsObserver>(Lifetime.Singleton).AsImplementedInterfaces();
        //builder.Register<CharacterFireController>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.Register<CharacterMoveController>(Lifetime.Singleton).AsImplementedInterfaces();

        builder.RegisterComponentInHierarchy<BulletsPool>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<BulletSystem>().AsImplementedInterfaces().AsSelf();
        //builder.RegisterInstance(_bulletConfig.physicsLayer);
        //builder.RegisterInstance(_bulletConfig.color);
        //builder.RegisterInstance(_bulletConfig.damage);
        //builder.RegisterInstance(_bulletConfig.speed);

    }
}
