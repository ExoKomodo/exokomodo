using System;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public ValueTask<float> MasterVolume
        {
            get => _JS.InvokeAsync<float>(
                _p5InvokeFunctionAndReturn,
                "getMasterVolume"
            );
        }
        #endregion

        #region Member Methods
        public ValueTask SetBPM(float bpm, float rampTime) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "setBPM",
            bpm,
            rampTime
        );

        public ValueTask SetMasterVolume(float volume) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "masterVolume",
            volume
        );
        
        public ValueTask SetMasterVolume(float volume, float rampTime) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "masterVolume",
            volume,
            rampTime
        );

        public ValueTask UserStartAudio() => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "userStartAudio"
        );
        #endregion

        #endregion
    }
}