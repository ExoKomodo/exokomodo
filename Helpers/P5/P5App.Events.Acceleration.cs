using ExoKomodo.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public ValueTask<float> AccelerationX => _JS.InvokeAsync<float>(
            _p5GetValue,
            "accelerationX"
        );
        public ValueTask<float> AccelerationY => _JS.InvokeAsync<float>(
            _p5GetValue,
            "accelerationY"
        );
        public ValueTask<float> AccelerationZ => _JS.InvokeAsync<float>(
            _p5GetValue,
            "accelerationZ"
        );
        public async Task<Orientation> GetDeviceOrientation()
        {
            var orientation = await _JS.InvokeAsync<string>(
                _p5GetValue,
                "deviceOrientation"
            );
            return orientation switch
            {
                "landscape" => Orientation.Landscape,
                "portrait" => Orientation.Portrait,
                _ => Orientation.Undefined,
            };
        }
        public ValueTask<float> PreviousAccelerationX => _JS.InvokeAsync<float>(
            _p5GetValue,
            "pAccelerationX"
        );
        public ValueTask<float> PreviousAccelerationY => _JS.InvokeAsync<float>(
            _p5GetValue,
            "pAccelerationY"
        );
        public ValueTask<float> PreviousAccelerationZ => _JS.InvokeAsync<float>(
            _p5GetValue,
            "pAccelerationZ"
        );
        public ValueTask<float> PreviousRotationX => _JS.InvokeAsync<float>(
            _p5GetValue,
            "previousRotationX"
        );
        public ValueTask<float> PreviousRotationY => _JS.InvokeAsync<float>(
            _p5GetValue,
            "previousRotationY"
        );
        public ValueTask<float> PreviousRotationZ => _JS.InvokeAsync<float>(
            _p5GetValue,
            "previousRotationZ"
        );
        public ValueTask<float> RotationX => _JS.InvokeAsync<float>(
            _p5GetValue,
            "rotationX"
        );
        public ValueTask<float> RotationY => _JS.InvokeAsync<float>(
            _p5GetValue,
            "rotationY"
        );
        public ValueTask<float> RotationZ => _JS.InvokeAsync<float>(
            _p5GetValue,
            "rotationZ"
        );
        public ValueTask<string> TurnAxis => _JS.InvokeAsync<string>(
            _p5GetValue,
            "turnAxis"
        );
        #endregion

        #region Hooks
        [JSInvokable("deviceMoved")]
        public virtual void DeviceMoved() {}

        [JSInvokable("deviceShaken")]
        public virtual void DeviceShaken() {}
        
        [JSInvokable("deviceTurned")]
        public virtual void DeviceTurned() {}
        #endregion

        #region Member Methods
        public ValueTask SetMoveThreshold(float threshold = 0.5f)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "setMoveThreshold",
                threshold
            );
        }

        public ValueTask SetShakeThreshold(float threshold = 30f)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "setShakeThreshold",
                threshold
            );
        }
        #endregion

        #endregion
    }
}