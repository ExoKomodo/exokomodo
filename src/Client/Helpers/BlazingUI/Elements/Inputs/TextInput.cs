using Client.Enums;
using System;

namespace Client.Helpers.BlazingUI.Elements.Inputs
{
    public class TextInput<TId> : Input<TId, KeyCodes, string>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Constructors
        public TextInput()
        {
            Clear();
            IsCapitalized = false;
        }
        #endregion

        #region Members
        public bool IsCapitalized { get; set; }
        #endregion

        #region Member Methods
        public void Clear()
        {
            Value = "";
        }

        public override void HandleInput(KeyCodes value)
        {
            switch (value)
            {
                case KeyCodes.Spacebar:
                    Value += ' ';
                    break;
                case KeyCodes.Backspace:
                    if (Value.Length > 0)
                    {
                        Value = Value.Substring(0, Value.Length - 1);
                    }
                    break;
                case KeyCodes key when (
                    key >= KeyCodes.A && key <= KeyCodes.Z
                ):
                    if (IsCapitalized)
                    {
                        Value += value.ToString();
                    }
                    else
                    {
                        Value += value.ToString().ToLower();
                    }
                    break;
                case KeyCodes key when (
                    key >= KeyCodes.Digit0 && key <= KeyCodes.Digit9
                ):
                    Value += (value - KeyCodes.Digit0).ToString();
                    break;
                case KeyCodes key when (
                    key >= KeyCodes.NumPad0 && key <= KeyCodes.NumPad9
                ):
                    Value += (value - KeyCodes.NumPad0).ToString();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #endregion
    }
}
