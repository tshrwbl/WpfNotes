using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WpfNotes
{
    //To specify what need to be returned, Use this attribute
    //[MarkupExtensionReturnType(typeof(int))]
    class RollTheDiceExtention : MarkupExtension
    {
        private List<int> diceResult = new List<int>();
        private bool showDiceTotal = true;
        private int _numberOfDice = 1;
        private static Random rand = new Random();

        public bool ShowDiceTotal { get => showDiceTotal; set => showDiceTotal = value; }

        public RollTheDiceExtention(int numberOnDice)
        {
            _numberOfDice = numberOnDice;
        }

        //public RollTheDiceExtention(int numberOnDice, bool showDiceTotal) : this(numberOnDice)
        //{
        //    this.showDiceTotal = showDiceTotal;
        //}


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            int total = 0;
            for (int i = 0; i < _numberOfDice; i++)
            {
                var result = rand.Next(1, 7);
                diceResult.Add(result);
                total += result;
            }

            if (showDiceTotal)
                return total.ToString();
            else
                return string.Join(", ", diceResult);
        }
    }
}
