using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void Save(string savePath)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "save",
                savePath
            );
        }

        public void Save(Image image, string savePath)
        {
            _jsRuntime.InvokeVoid(
                "p5Instance.saveImageDotnet",
                image.Id,
                savePath
            );
        }

        public void SaveJson(object obj, string savePath, bool prettyPrint = true)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "saveJSON",
                obj,
                savePath,
                !prettyPrint
            );
        }
        #endregion

        #endregion
    }
}