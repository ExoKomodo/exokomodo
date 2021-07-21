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

        #region Member Methods
        public ValueTask<float> GetCurrentTime(Sound sound) =>
            _JS.InvokeAsync<float>(
                "p5Instance.getCurrentTimeDotnet",
                sound.Id
            );
        
        public ValueTask<float> GetDuration(Sound sound) =>
            _JS.InvokeAsync<float>(
                "p5Instance.getDurationDotnet",
                sound.Id
            );

        public ValueTask<float> GetPan(Sound sound) =>
            _JS.InvokeAsync<float>(
                "p5Instance.getPanSoundDotnet",
                sound.Id
            );

        public ValueTask<bool> IsLoaded(Sound sound) =>
            _JS.InvokeAsync<bool>(
                "p5Instance.isLoadedDotnet",
                sound.Id
            );

        public ValueTask<bool> IsPaused(Sound sound) =>
            _JS.InvokeAsync<bool>(
                "p5Instance.isPausedDotnet",
                sound.Id
            );
        
        public ValueTask<bool> IsPlaying(Sound sound) =>
            _JS.InvokeAsync<bool>(
                "p5Instance.isPlayingDotnet",
                sound.Id
            );

        public ValueTask<bool> IsSoundLooping(Sound sound) =>
            _JS.InvokeAsync<bool>(
                "p5Instance.isLoopingDotnet",
                sound.Id
            );

        public ValueTask<Sound> LoadSound(string path) =>
            _JS.InvokeAsync<Sound>(
                "p5Instance.loadSoundDotnet",
                path
            );

        public ValueTask Loop(
            Sound sound,
            float startTime = 0f,
            float rate = 1f,
            float amp = 1f,
            float? cueStart = null,
            float? duration = null
        ) => _JS.InvokeVoidAsync(
                "p5Instance.loopDotnet",
                sound.Id,
                startTime,
                rate,
                amp,
                cueStart,
                duration
            );

        public ValueTask Pan(
            Sound sound,
            float panValue,
            float delay = 0f
        ) => _JS.InvokeVoidAsync(
                "p5Instance.panSoundDotnet",
                sound.Id,
                panValue,
                delay
            );

        public ValueTask Pause(
            Sound sound,
            float delay = 0f
        ) => _JS.InvokeVoidAsync(
                "p5Instance.pauseDotnet",
                sound.Id,
                delay
            );

        public ValueTask Play(
            Sound sound,
            float startTime = 0f,
            float rate = 1f,
            float amp = 1f,
            float? cueStart = null,
            float? duration = null
        ) => _JS.InvokeVoidAsync(
                "p5Instance.playDotnet",
                sound.Id,
                startTime,
                rate,
                amp,
                cueStart,
                duration
            );

        public ValueTask SetPlayMode(Sound sound, PlayMode mode) =>
            _JS.InvokeVoidAsync(
                "p5Instance.playModeDotnet",
                sound.Id,
                PlayModeToString(mode)
            );

        public ValueTask SetIsSoundLooping(Sound sound, bool shouldLoop) =>
            _JS.InvokeVoidAsync(
                "p5Instance.setIsLoopingDotnet",
                sound.Id,
                shouldLoop
            );

        public ValueTask SetRate(
            Sound sound,
            float rate
        ) => _JS.InvokeVoidAsync(
                "p5Instance.setRateDotnet",
                sound.Id,
                rate
            );

        public ValueTask SetVolume(
            Sound sound,
            float volume,
            float rampTime = 0f,
            float delay = 0f
        ) => _JS.InvokeVoidAsync(
                "p5Instance.setVolumeDotnet",
                sound.Id,
                volume,
                rampTime,
                delay
            );

        public ValueTask Stop(
            Sound sound,
            float delay = 0f
        ) => _JS.InvokeVoidAsync(
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