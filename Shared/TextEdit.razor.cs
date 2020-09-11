﻿using Microsoft.AspNetCore.Components;

namespace ExoKomodo.Shared
{
    public partial class TextEdit
    {
        #region Public

        #region Members
        public string Text { get; protected set; }
        public MarkupString Markup => (MarkupString)Text;
        #endregion

        #endregion
    }
}
