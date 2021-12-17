using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void DrawBox()
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "box"
            );
        }

        public void DrawBox(
            float width,
            float height,
            float depth,
            uint detailX = Box.DEFAULT_DETAIL,
            uint detailY = Box.DEFAULT_DETAIL
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "box",
                width,
                height,
                depth,
                detailX,
                detailY
            );
        }

        public void DrawBox(
            Vector3 dimensions,
            uint detailX = Box.DEFAULT_DETAIL,
            uint detailY = Box.DEFAULT_DETAIL
        ) => DrawBox(
            dimensions.X,
            dimensions.Y,
            dimensions.Z,
            detailX,
            detailY
        );

        public void DrawBox(Box box) => DrawBox(
            box.Width,
            box.Height,
            box.Depth,
            box.DetailX,
            box.DetailY
        );

        public void DrawCone(
            float radius,
            float height,
            uint detailX = Cone.DEFAULT_DETAIL_X,
            uint detailY = Cone.DEFAULT_DETAIL_Y,
            bool showCap = true
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            if (detailX > Cone.MAX_DETAIL)
            {
                detailX = Cone.MAX_DETAIL;
            }
            if (detailY > Cone.MAX_DETAIL)
            {
                detailY = Cone.MAX_DETAIL;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "cone",
                radius,
                height,
                detailX,
                detailY,
                showCap
            );
        }

        public void DrawCone(Cone cone) => DrawCone(
            cone.Radius,
            cone.Height,
            cone.DetailX,
            cone.DetailY,
            cone.ShowCap
        );

        public void DrawCylinder(
            float radius,
            float height,
            uint detailX = Cylinder.DEFAULT_DETAIL_X,
            uint detailY = Cylinder.DEFAULT_DETAIL_Y,
            bool showBottomCap = true,
            bool showTopCap = true
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            if (detailX > Cylinder.MAX_DETAIL)
            {
                detailX = Cylinder.MAX_DETAIL;
            }
            if (detailY > Cylinder.MAX_DETAIL)
            {
                detailY = Cylinder.MAX_DETAIL;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "cylinder",
                radius,
                height,
                detailX,
                detailY,
                showBottomCap,
                showTopCap
            );
        }

        public void DrawCylinder(Cylinder cylinder) => DrawCylinder(
            cylinder.Radius,
            cylinder.Height,
            cylinder.DetailX,
            cylinder.DetailY,
            cylinder.ShowBottomCap,
            cylinder.ShowTopCap
        );

        public void DrawEllipsoid(
            float radiusX,
            float radiusY,
            float radiusZ,
            uint detailX = Ellipsoid.DEFAULT_DETAIL_X,
            uint detailY = Ellipsoid.DEFAULT_DETAIL_Y
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            if (detailX > Ellipsoid.MAX_DETAIL)
            {
                detailX = Ellipsoid.MAX_DETAIL;
            }
            if (detailY > Ellipsoid.MAX_DETAIL)
            {
                detailY = Ellipsoid.MAX_DETAIL;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ellipsoid",
                radiusX,
                radiusY,
                radiusZ,
                detailX,
                detailY
            );
        }

        public void DrawEllipsoid(
            Vector3 dimensions,
            uint detailX = Ellipsoid.DEFAULT_DETAIL_X,
            uint detailY = Ellipsoid.DEFAULT_DETAIL_Y
        ) => DrawEllipsoid(
            dimensions.X,
            dimensions.Y,
            dimensions.Z,
            detailX,
            detailY
        );

        public void DrawEllipsoid(Ellipsoid ellipsoid) => DrawEllipsoid(
            ellipsoid.Dimensions,
            ellipsoid.DetailX,
            ellipsoid.DetailY
        );

        public void DrawPlane(
            float width,
            float height,
            uint detailX = Models.Plane.DEFAULT_DETAIL,
            uint detailY = Models.Plane.DEFAULT_DETAIL
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "plane",
                width,
                height,
                detailX,
                detailY
            );
        }

        public void DrawPlane(
            Vector2 dimensions,
            uint detailX = Models.Plane.DEFAULT_DETAIL,
            uint detailY = Models.Plane.DEFAULT_DETAIL
        ) => DrawPlane(
            dimensions.X,
            dimensions.Y,
            detailX,
            detailY
        );

        public void DrawPlane(
            Models.Plane plane
        ) => DrawPlane(
            plane.Width,
            plane.Height,
            plane.DetailX,
            plane.DetailY
        );

        public void DrawSphere(
            float radius,
            uint detailX = Sphere.MAX_DETAIL,
            uint detailY = Sphere.MAX_DETAIL
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            if (detailX > Sphere.MAX_DETAIL)
            {
                detailX = Sphere.MAX_DETAIL;
            }
            if (detailY > Sphere.MAX_DETAIL)
            {
                detailY = Sphere.MAX_DETAIL;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "sphere",
                radius,
                detailX,
                detailY
            );
        }

        public void DrawSphere(Sphere sphere) => DrawSphere(
            sphere.Radius,
            sphere.DetailX,
            sphere.DetailY
        );

        public void DrawTorus(
            float radius,
            float tubeRadius,
            uint detailX = Torus.DEFAULT_DETAIL_X,
            uint detailY = Torus.DEFAULT_DETAIL_Y
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            if (detailX > Torus.MAX_DETAIL_X)
            {
                detailX = Torus.MAX_DETAIL_X;
            }
            if (detailY > Torus.MAX_DETAIL_Y)
            {
                detailY = Torus.MAX_DETAIL_Y;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "torus",
                radius,
                tubeRadius,
                detailX,
                detailY
            );
        }

        public void DrawTorus(Torus torus) => DrawTorus(
            torus.Radius,
            torus.TubeRadius,
            torus.DetailX,
            torus.DetailY
        );
        #endregion

        #endregion
    }
}