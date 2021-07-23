using Client.Helpers.P5.Enums;
using Microsoft.JSInterop;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public float AccelerationX => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "accelerationX"
        );
        public float AccelerationY => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "accelerationY"
        );
        public float AccelerationZ => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "accelerationZ"
        );
        public Orientation DeviceOrientation
        {
            get
            {
                var orientation = _jsRuntime.Invoke<string>(
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
        }
        public float PreviousAccelerationX => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "pAccelerationX"
        );
        public float PreviousAccelerationY => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "pAccelerationY"
        );
        public float PreviousAccelerationZ => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "pAccelerationZ"
        );
        public float PreviousRotationX => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "previousRotationX"
        );
        public float PreviousRotationY => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "previousRotationY"
        );
        public float PreviousRotationZ => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "previousRotationZ"
        );
        public float RotationX => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "rotationX"
        );
        public float RotationY => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "rotationY"
        );
        public float RotationZ => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "rotationZ"
        );
        public string TurnAxis => _jsRuntime.Invoke<string>(
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
        public void SetMoveThreshold(float threshold = 0.5f)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "setMoveThreshold",
                threshold
            );
        }

        public void SetShakeThreshold(float threshold = 30f)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "setShakeThreshold",
                threshold
            );
        }
        #endregion

        #endregion
    }
}