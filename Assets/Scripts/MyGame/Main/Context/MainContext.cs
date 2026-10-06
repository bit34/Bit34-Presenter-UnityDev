using UnityEngine;
using Com.Bit34Games.Director.Unity;
using Com.Bit34Games.Presenter.Utilities;
using MyGame.Character.Context;
using MyGame.Ground.Context;
using MyGame.Main.Unity;
using MyGame.Main.Signals;
using MyGame.Main.Constants;
using Com.Bit34Games.Presenter.Context;
using Com.Bit34Games.Presenter.VOs;

namespace MyGame.Main.Context
{
    public class MainContext : DirectorUnityContext
    {
        //  MEMBERS
        //      For Editor
#pragma warning disable 0649
        [SerializeField] private ResourceRefs _resourceRefs;
        [SerializeField] private SceneRefs    _sceneRefs;
#pragma warning restore 0649

        //  METHODS
        private void Start()
        {
            InitializeContext();
            StartContext();
        }

        protected override void InitializeBindings()
        {
            AddBindings();
            PostBindingInitialize();
        }

        protected override void Launch()
        {
            LoadPresenterResources();
            CreateViews();
            LoadData();
        }

        private void AddBindings()
        {
            PresenterContextBindings.AddBindings(Injector, MediationBinder, SignalCommandBinder);
            
            MainContextBindings.AddBindings(Injector, MediationBinder, SignalCommandBinder);
            CharacterContextBindings.AddBindings(Injector, MediationBinder, SignalCommandBinder);
            GroundContextBindings.AddBindings(Injector, MediationBinder, SignalCommandBinder);
        }

        private void PostBindingInitialize()
        {
            PresenterContextBindings.Initialize(Injector, _sceneRefs.PresenterManager);
        }

        private void LoadPresenterResources()
        {
            _sceneRefs.PresenterManager.LoadAsset(_resourceRefs.MainScreenViewAsset);
            _sceneRefs.PresenterManager.LoadAsset(_resourceRefs.CharacterOverlayViewAsset);
        }

        private void CreateViews()
        {
            PresenterOperations presenterOperations = Injector.GetInstance<PresenterOperations>();
            presenterOperations.OpenScreen(ResourceNames.MainScreen);
            presenterOperations.CreateOverlay(ResourceNames.CharacterOverlay);

            GameObject.Instantiate(_resourceRefs.CharactersViewAsset,      _sceneRefs.WorldContainer);
        }

        private void LoadData()
        {
            Injector.GetInstance<LoadDataSignal>().Dispatch();
        }
        
    }
}
