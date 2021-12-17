using System;
using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using Microsoft.JSInterop;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public float MasterVolume
        {
            get => _jsRuntime.Invoke<float>(
                _p5InvokeFunctionAndReturn,
                "getMasterVolume"
            );
        }
        #endregion

        #region Member Methods
        public void SetBPM(float bpm, float rampTime) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "setBPM",
            bpm,
            rampTime
        );

        public void SetMasterVolume(float volume) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "masterVolume",
            volume
        );
        
        public void SetMasterVolume(float volume, float rampTime) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "masterVolume",
            volume,
            rampTime
        );

        public void UserStartAudio() => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "userStartAudio"
        );
        #endregion

        #endregion
    }
}