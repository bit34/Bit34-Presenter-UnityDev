using System.Collections.Generic;
using UnityEngine;
using Com.Bit34Games.Director.Unity;
using MyGame.Character.Views;

namespace MyGame.Character.Unity
{
    public class CharactersView : DirectorUnityView, ICharactersView
    {
        //  MEMBERS
#pragma warning disable 0649
        //      For Editor
        [SerializeField] private GameObject _characterPrefab;
#pragma warning restore 0649
        //      Intenal
        private ICharactersViewListener             _viewListener;
        private Dictionary<int, CharacterComponent> _characters;

        //  METHODS
        public void Initialize(ICharactersViewListener viewListener)
        {
            _viewListener = viewListener;
            _characters   = new Dictionary<int, CharacterComponent>();
        }

        public void AddCharacter(int id, string name, Vector3 position)
        {
            GameObject         characterObject = Instantiate(_characterPrefab, transform);
            CharacterComponent character       = characterObject.GetComponent<CharacterComponent>();

            character.Initialize(_viewListener, id, name, position);

            _characters.Add(id, character);
        }

        public void UnselectCharacter(int id)
        {
            _characters[id].SetSelection(false);
        }

        public void SelectCharacter(int id)
        {
            _characters[id].SetSelection(true);
        }

        public void MoveCharacter(int id, Vector3 newPosition)
        {
            _characters[id].SetPosition(newPosition);
        }

    }
}
