using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask<Camera> CreateCamera() => _JS.InvokeAsync<Camera>(
            "p5Instance.createCameraDotnet"
        );

        public ValueTask Frustum(Camera camera) => _JS.InvokeVoidAsync(
            "p5Instance.frustumDotnet",
            camera.Id
        );

        public ValueTask Frustum(
            Camera camera,
            float left,
            float right,
            float bottom,
            float top,
            float near,
            float far
        ) => _JS.InvokeVoidAsync(
            "p5Instance.frustumDotnet",
            camera.Id,
            left,
            right,
            bottom,
            top,
            near,
            far
        );

        public ValueTask LookAt(Camera camera, float x, float y, float z) => _JS.InvokeVoidAsync(
            "p5Instance.lookAtDotnet",
            camera.Id,
            x,
            y,
            z
        );

        public ValueTask LookAt(Camera camera, Vector3 position) => LookAt(
            camera,
            position.X,
            position.Y,
            position.Z
        );

        public ValueTask Move(Camera camera, float x, float y, float z) => _JS.InvokeVoidAsync(
            "p5Instance.moveDotnet",
            camera.Id,
            x,
            y,
            z
        );

        public ValueTask Move(Camera camera, Vector3 position) => Move(
            camera,
            position.X,
            position.Y,
            position.Z
        );

        public ValueTask Orthographic(Camera camera) => _JS.InvokeVoidAsync(
            "p5Instance.orthoDotnet",
            camera.Id
        );

        public ValueTask Orthographic(
            Camera camera,
            float left,
            float right,
            float bottom,
            float top,
            float near,
            float far
        ) => _JS.InvokeVoidAsync(
            "p5Instance.orthoDotnet",
            camera.Id,
            left,
            right,
            bottom,
            top,
            near,
            far
        );

        public ValueTask Pan(Camera camera, float angle) => _JS.InvokeVoidAsync(
            "p5Instance.panDotnet",
            camera.Id,
            angle
        );

        public ValueTask Perspective(
            Camera camera
        ) => _JS.InvokeVoidAsync(
            "p5Instance.perspectiveDotnet",
            camera.Id
        );

        public ValueTask Perspective(
            Camera camera,
            float fovY,
            float aspect,
            float near,
            float far
        ) => _JS.InvokeVoidAsync(
            "p5Instance.perspectiveDotnet",
            camera.Id,
            fovY,
            aspect,
            near,
            far
        );

        public ValueTask SetCamera(Camera camera) => _JS.InvokeVoidAsync(
            "p5Instance.setCameraDotnet",
            camera.Id
        );

        public ValueTask SetCameraParameters(
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
        ) => _JS.InvokeVoidAsync(
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

        public ValueTask SetCameraParameters(
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

        public ValueTask SetPosition(Camera camera, float x, float y, float z) => _JS.InvokeVoidAsync(
            "p5Instance.setCameraPositionDotnet",
            camera.Id,
            x,
            y,
            z
        );

        public ValueTask SetPosition(Camera camera, Vector3 position) => SetPosition(
            camera,
            position.X,
            position.Y,
            position.Z
        );

        public ValueTask Tilt(Camera camera, float angle) => _JS.InvokeVoidAsync(
            "p5Instance.tiltDotnet",
            camera.Id,
            angle
        );
        #endregion

        #endregion
    }
}