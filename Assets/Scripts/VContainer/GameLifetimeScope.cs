using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private BulletConfig _bulletConfig; 

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameManager>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf(); 

        builder.Register(_ =>
        {
            using (EnqueueParent(this))
            {
                return Instantiate(_characterPrefab);
            }
        }, Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<GameCountableLauncher>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<LevelBackground>().AsImplementedInterfaces().AsSelf();
        builder.Register<LevelBackgroundParams>(Lifetime.Transient);

        builder.RegisterInstance(_bulletConfig);

        builder.Register<EnemyMoveAgent>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<EnemyPool>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<EnemySpawner>().AsImplementedInterfaces().AsSelf();
        builder.Register<EnemyManager>(Lifetime.Singleton);
        builder.Register<EnemyCouldownSpawner>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

        builder.Register<FireInput>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<MoveInput>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

        builder.Register<CharacterHitPointsObserver>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<CharacterFireController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<CharacterMoveController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

        builder.RegisterComponentInHierarchy<BulletsPool>().AsImplementedInterfaces().AsSelf();
        builder.RegisterComponentInHierarchy<BulletSystem>().AsImplementedInterfaces().AsSelf();
    }
}
