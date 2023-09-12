using MTGHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public class DiceContentViewModel : BaseViewModel
    {
        private DiceRollModel diceRollModel;
        public DiceRollModel DiceRollModel
        {
            get => diceRollModel;
            set
            {
                if (diceRollModel == value) return;
                diceRollModel = value;
                OnPropertyChanged();
            }
        }
        public DiceContentViewModel() { }
        public DiceContentViewModel(DiceRollModel diceRollModel)
        {
            this.DiceRollModel = diceRollModel;
        }
    }
}
