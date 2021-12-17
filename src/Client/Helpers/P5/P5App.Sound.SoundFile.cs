using System;
using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using Microsoft.JSInterop;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public float GetCurrentTime(
            Sound sound
        ) => _jsRuntime.Invoke<float>(
            "p5Instance.getCurrentTimeDotnet",
            sound.Id
        );
        
        public float GetDuration(
            Sound sound
        ) => _jsRuntime.Invoke<float>(
            "p5Instance.getDurationDotnet",
            sound.Id
        );

        public float GetPan(Sound sound) => _jsRuntime.Invoke<float>(
            "p5Instance.getPanSoundDotnet",
            sound.Id
        );

        public bool IsLoaded(Sound sound) => _jsRuntime.Invoke<bool>(
            "p5Instance.isLoadedDotnet",
            sound.Id
        );

        public bool IsPaused(Sound sound) => _jsRuntime.Invoke<bool>(
            "p5Instance.isPausedDotnet",
            sound.Id
        );
        
        public bool IsPlaying(Sound sound) => _jsRuntime.Invoke<bool>(
            "p5Instance.isPlayingDotnet",
            sound.Id
        );

        public bool IsSoundLooping(Sound sound) => _jsRuntime.Invoke<bool>(
            "p5Instance.isLoopingDotnet",
            sound.Id
        );

        public Sound LoadSound(string path) => _jsRuntime.Invoke<Sound>(
            "p5Instance.loadSoundDotnet",
            path
        );

        public void Loop(
            Sound sound,
            float startTime = 0f,
            float rate = 1f,
            float amp = 1f,
            float? cueStart = null,
            float? duration = null
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.loopDotnet",
            sound.Id,
            startTime,
            rate,
            amp,
            cueStart,
            duration
        );

        public void Pan(
            Sound sound,
            float panValue,
            float delay = 0f
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.panSoundDotnet",
            sound.Id,
            panValue,
            delay
        );

        public void Pause(
            Sound sound,
            float delay = 0f
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.pauseDotnet",
            sound.Id,
            delay
        );

        public void Play(
            Sound sound,
            float startTime = 0f,
            float rate = 1f,
            float amp = 1f,
            float? cueStart = null,
            float? duration = null
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.playDotnet",
            sound.Id,
            startTime,
            rate,
            amp,
            cueStart,
            duration
        );

        public void SetPlayMode(Sound sound, PlayMode mode) => _jsRuntime.InvokeVoid(
            "p5Instance.playModeDotnet",
            sound.Id,
            PlayModeToString(mode)
        );

        public void SetIsSoundLooping(Sound sound, bool shouldLoop) => _jsRuntime.InvokeVoid(
            "p5Instance.setIsLoopingDotnet",
            sound.Id,
            shouldLoop
        );

        public void SetRate(
            Sound sound,
            float rate
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.setRateDotnet",
            sound.Id,
            rate
        );

        public void SetVolume(
            Sound sound,
            float volume,
            float rampTime = 0f,
            float delay = 0f
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.setVolumeDotnet",
            sound.Id,
            volume,
            rampTime,
            delay
        );

        public void Stop(
            Sound sound,
            float delay = 0f
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.stopDotnet",
            sound.Id,
            delay
        );
        #endregion

        #region Static Methods
        public static string PlayModeToString(PlayMode mode) => mode switch
        {
            PlayMode.Restart => "restart",
            PlayMode.Sustain => "sustain",
            PlayMode.UntilDone => "untilDone",
            _ => throw new Exception("Invalid PlayMode"),
        };
        #endregion

        #endregion
    }
}