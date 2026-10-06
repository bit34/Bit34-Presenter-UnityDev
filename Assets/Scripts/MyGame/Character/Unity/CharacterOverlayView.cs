using UnityEngine;
using UnityEngine.UI;
using MyGame.Character.Views;
using Com.Bit34Games.Presenter.Unity;

namespace MyGame.Character.Unity
{
    public class CharacterOverlayView : OverlayView, 
                                        ICharacterOverlayView
    {
        //  MEMBERS
#pragma warning disable 0649
        //      For Editor
        [SerializeField] private Text _nameLabel;
#pragma warning restore 0649

        //  METHODS
        public void Initialize()
        {
            _nameLabel.text = "";
        }

        public void SetCharacter(string name)
        {
            _nameLabel.text = "Selected character : " + name;
        }

        public void ClearCharacter()
        {
            _nameLabel.text = "";
        }

    }
}
