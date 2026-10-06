using Com.Bit34Games.Presenter.Unity;
using UnityEngine;

namespace MyGame.Main.Unity
{
    public class ResourceRefs : MonoBehaviour
    {
        //  MEMBERS
        public PresenterSceneAsset MainScreenViewAsset       { get { return _mainScreenViewAsset;      } }
        public PresenterSceneAsset CharacterOverlayViewAsset { get { return _characterOverlayViewAsset; } }
        public GameObject          CharactersViewAsset       { get { return _charactersView; } }
        //      For Editor
#pragma warning disable 0649
        [Header("UI resources")]
        [SerializeField] private PresenterSceneAsset _mainScreenViewAsset;
        [SerializeField] private PresenterSceneAsset _characterOverlayViewAsset;
        [Header("World resources")]
        [SerializeField] private GameObject _charactersView;
#pragma warning restore 0649
    }
}