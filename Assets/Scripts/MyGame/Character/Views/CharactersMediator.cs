using System.Collections.Generic;
using UnityEngine;
using Com.Bit34Games.Director.Mediation;
using Com.Bit34Games.Director.Signaling;
using MyGame.Character.Models;
using MyGame.Character.Models.VO;
using MyGame.Character.Signals;
using MyGame.Main.Signals;

namespace MyGame.Character.Views
{
    public class CharactersMediator : IMediator, ICharactersViewListener
    {
        //  MEMBERS
#pragma warning disable 0649
        //      View
        [Inject] private ICharactersView _view;
        //      Models
        [Inject] private CharactersModel _charactersModel;
        //      Signals to dispatch
        [Inject] private SelectCharacterSignal _selectCharacterSignal;
        //      Signals to listen
        [Inject] private DataLoadedSignal        _dataLoadedSignal;
        [Inject] private CharacterSelectedSignal _characterSelectedSignal;
        [Inject] private CharacterMovedSignal    _characterMovedSignal;
#pragma warning restore 0649
        //      Internal
        SignalListener _signalListener;

        //  METHODS
#region MediatorBase implementation
    
        public void OnRegister()
        {
            _view.Initialize(this);
            
            _signalListener = new SignalListener();
            _signalListener.AddListener(_dataLoadedSignal,        OnDataLoaded);
            _signalListener.AddListener(_characterSelectedSignal, OnCharacterSelected);
            _signalListener.AddListener(_characterMovedSignal,    OnCharacterMoved);

            if (_charactersModel.CharacterCount>0)
            {
                CreateCharacters();
            }
        }

        public void OnRemove()
        {
            _signalListener.StopListening();
            _signalListener = null;
        }

#endregion

#region ICharactersViewListener implementation
    
        public void OnViewCharacterClicked(int characterId)
        {
            _selectCharacterSignal.Dispatch(characterId);
        }

#endregion

#region Signal listeners

        private void OnDataLoaded()
        {
            CreateCharacters();
        }

        private void OnCharacterSelected(int prevCharacterId, int newCharacterId)
        {
            if (prevCharacterId != -1)
            {
                _view.UnselectCharacter(prevCharacterId);
            }
            if (newCharacterId != -1)
            {
                _view.SelectCharacter(newCharacterId);
            }
        }

        private void OnCharacterMoved(int characterId, Vector3 oldPosition, Vector3 newPosition)
        {
            _view.MoveCharacter(characterId, newPosition);
        }

#endregion

        private void CreateCharacters()
        {
            IEnumerator<CharacterVO> characters = _charactersModel.GetCharacters();
            while (characters.MoveNext())
            {
                CharacterVO character = characters.Current;
                _view.AddCharacter(character.id, character.name, character.position);
            }
        }

    }
}
