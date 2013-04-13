using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Ui.Metro.ViewModels
{
    public class YahtzeeDiceRollerViewModel : Screen
    {
        #region Private fields

        private const int MaxNumberOfRolls = 3;
        private const int NumberOfDices = 5;

        private readonly Random _random = new Random();
        private int _rollCount;

        #endregion

        public BindableCollection<DiceViewModel> Dices { get; private set; }

        public string RollCountCaption
        {
            get { return string.Format("Roll ({0})", _rollCount + 1); }
        }

        public bool CanRoll
        {
            get { return (_rollCount + 1) < MaxNumberOfRolls; }
        }

        public YahtzeeDiceRollerViewModel()
        {
            var dices = GetRandomDices(NumberOfDices);
            Dices = new BindableCollection<DiceViewModel>(dices);
        }

        public void Roll()
        {
            _rollCount++;

            var dicesForReroll = Dices.Where(d => !d.IsOnHold);

            foreach (var dice in dicesForReroll)
                dice.Value = GetRandomDiceValue();

            RefreshRollBindings();
        }

        public void ResetRollCount()
        {
            _rollCount = 0;

            foreach (var dice in Dices)
                ClearDice(dice);

            RefreshRollBindings();
            NotifyOfPropertyChange(() => Dices);
        }

        #region Private methods

        private void RefreshRollBindings()
        {
            NotifyOfPropertyChange(() => CanRoll);
            NotifyOfPropertyChange(() => RollCountCaption);
        }

        private IEnumerable<DiceViewModel> GetRandomDices(int numberOfDices)
        {
            for (var i = 0; i < numberOfDices; i++)
                yield return CreateRandomDice();
        }

        private DiceViewModel CreateRandomDice()
        {
            return new DiceViewModel
            {
                IsOnHold = false,
                Value = GetRandomDiceValue(),
            };
        }

        private void ClearDice(DiceViewModel dice)
        {
            dice.IsOnHold = false;
            dice.Value = GetRandomDiceValue();
        }

        private int GetRandomDiceValue()
        {
            return _random.Next(1, 7);
        }

        #endregion
    }
}