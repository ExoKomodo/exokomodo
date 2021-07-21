using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask DrawModel(Model3D model) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                "p5Instance.modelDotnet",
                model.Id
            ) : new ValueTask(); 

        public ValueTask<Model3D> LoadModel(string path, bool normalize = false) =>
            _JS.InvokeAsync<Model3D>(
                "p5Instance.loadModelDotnet",
                path,
                normalize
            );
        #endregion

        #endregion
    }
}