using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void DrawModel(Model3D model)
        {
            if (IsWebGL)
            {
                _jsRuntime.InvokeVoid(
                    "p5Instance.modelDotnet",
                    model.Id
                );
            }
        } 

        public Model3D LoadModel(string path, bool normalize = false) => _jsRuntime.Invoke<Model3D>(
            "p5Instance.loadModelDotnet",
            path,
            normalize
        );
        #endregion

        #endregion
    }
}