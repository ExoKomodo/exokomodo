using ExoKomodo.Enums;
using System;

namespace ExoKomodo.Helpers.BlazingUI.Elements.Inputs
{
    public class NumberInput<TId> : Input<TId, KeyCodes, int>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Constructors
        public NumberInput()
        {
            Clear();
        }
        #endregion

        #region Member Methods
        public void Clear()
        {
            Value = 0;
        }

        public override void HandleInput(KeyCodes value)
        {
            int digit;
            switch (value)
            {
                case KeyCodes.Backspace:
                    if (Value > 0)
                    {
                        Value /= 10;
                    }
                    break;
                case KeyCodes key when (
                    key >= KeyCodes.Digit0 && key <= KeyCodes.Digit9
                ):
                    digit = (value - KeyCodes.Digit0);
                    if (Value == 0 && digit == 0)
                    {
                        break;
                    }
                    Value = Value * 10 + digit;
                    break;
                case KeyCodes key when (
                    key >= KeyCodes.NumPad0 && key <= KeyCodes.NumPad9
                ):
                    digit = (value - KeyCodes.NumPad0);
                    if (Value == 0 && digit == 0)
                    {
                        break;
                    }
                    Value = Value * 10 + digit;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #endregion
    }
}
