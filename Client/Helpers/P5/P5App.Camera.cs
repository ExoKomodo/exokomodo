using Microsoft.JSInterop;
using Client.Helpers.P5.Models;
using System.Numerics;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public Camera CreateCamera() => _jsRuntime.Invoke<Camera>(
            "p5Instance.createCameraDotnet"
        );

        public void Frustum(Camera camera) => _jsRuntime.InvokeVoid(
            "p5Instance.frustumDotnet",
            camera.Id
        );

        public void Frustum(
            Camera camera,
            float left,
            float right,
            float bottom,
            float top,
            float near,
            float far
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.frustumDotnet",
            camera.Id,
            left,
            right,
            bottom,
            top,
            near,
            far
        );

        public void LookAt(Camera camera, float x, float y, float z) => _jsRuntime.InvokeVoid(
            "p5Instance.lookAtDotnet",
            camera.Id,
            x,
            y,
            z
        );

        public void LookAt(Camera camera, Vector3 position) => LookAt(
            camera,
            position.X,
            position.Y,
            position.Z
        );

        public void Move(Camera camera, float x, float y, float z) => _jsRuntime.InvokeVoid(
            "p5Instance.moveDotnet",
            camera.Id,
            x,
            y,
            z
        );

        public void Move(Camera camera, Vector3 position) => Move(
            camera,
            position.X,
            position.Y,
            position.Z
        );

        public void Orthographic(Camera camera) => _jsRuntime.InvokeVoid(
            "p5Instance.orthoDotnet",
            camera.Id
        );

        public void Orthographic(
            Camera camera,
            float left,
            float right,
            float bottom,
            float top,
            float near,
            float far
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.orthoDotnet",
            camera.Id,
            left,
            right,
            bottom,
            top,
            near,
            far
        );

        public void Pan(Camera camera, float angle) => _jsRuntime.InvokeVoid(
            "p5Instance.panDotnet",
            camera.Id,
            angle
        );

        public void Perspective(
            Camera camera
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.perspectiveDotnet",
            camera.Id
        );

        public void Perspective(
            Camera camera,
            float fovY,
            float aspect,
            float near,
            float far
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.perspectiveDotnet",
            camera.Id,
            fovY,
            aspect,
            near,
            far
        );

        public void SetCamera(Camera camera) => _jsRuntime.InvokeVoid(
            "p5Instance.setCameraDotnet",
            camera.Id
        );

        public void SetCameraParameters(
            Camera camera,
            float x,
            float y,
            float z,
            float centerX,
            float centerY,
            float centerZ,
            float upX,
            float upY,
            float upZ
        ) => _jsRuntime.InvokeVoid(
            "p5Instance.setCameraParametersDotnet",
            camera.Id,
            x,
            y,
            z,
            centerX,
            centerY,
            centerZ,
            upX,
            upY,
            upZ
        );

        public void SetCameraParameters(
            Camera camera,
            Vector3 position,
            Vector3 sketchCenter,
            Vector3 up
        ) => SetCameraParameters(
            camera,
            position.X,
            position.Y,
            position.Z,
            sketchCenter.X,
            sketchCenter.Y,
            sketchCenter.Z,
            up.X,
            up.Y,
            up.Z
        );

        public void SetPosition(Camera camera, float x, float y, float z) => _jsRuntime.InvokeVoid(
            "p5Instance.setCameraPositionDotnet",
            camera.Id,
            x,
            y,
            z
        );

        public void SetPosition(Camera camera, Vector3 position) => SetPosition(
            camera,
            position.X,
            position.Y,
            position.Z
        );

        public void Tilt(Camera camera, float angle) => _jsRuntime.InvokeVoid(
            "p5Instance.tiltDotnet",
            camera.Id,
            angle
        );
        #endregion

        #endregion
    }
}