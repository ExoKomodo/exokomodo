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
        public ValueTask DrawBox() =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "box"
            ) : new ValueTask();

        public ValueTask DrawBox(
            float width,
            float height,
            float depth,
            uint detailX = Box.DEFAULT_DETAIL,
            uint detailY = Box.DEFAULT_DETAIL
        ) => IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "box",
                width,
                height,
                depth,
                detailX,
                detailY
            ) : new ValueTask();

        public ValueTask DrawBox(
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

        public ValueTask DrawBox(Box box) => DrawBox(
            box.Width,
            box.Height,
            box.Depth,
            box.DetailX,
            box.DetailY
        );

        public ValueTask DrawCone(
            float radius,
            float height,
            uint detailX = Cone.DEFAULT_DETAIL_X,
            uint detailY = Cone.DEFAULT_DETAIL_Y,
            bool showCap = true
        )
        {
            if (IsWebGl)
            {
                if (detailX > Cone.MAX_DETAIL)
                {
                    detailX = Cone.MAX_DETAIL;
                }
                if (detailY > Cone.MAX_DETAIL)
                {
                    detailY = Cone.MAX_DETAIL;
                }
                return _JS.InvokeVoidAsync(
                    _p5InvokeFunction,
                    "cone",
                    radius,
                    height,
                    detailX,
                    detailY,
                    showCap
                );
            }
            return new ValueTask();
        }

        public ValueTask DrawCone(Cone cone) => DrawCone(
            cone.Radius,
            cone.Height,
            cone.DetailX,
            cone.DetailY,
            cone.ShowCap
        );

        public ValueTask DrawCylinder(
            float radius,
            float height,
            uint detailX = Cylinder.DEFAULT_DETAIL_X,
            uint detailY = Cylinder.DEFAULT_DETAIL_Y,
            bool showBottomCap = true,
            bool showTopCap = true
        )
        {
            if (IsWebGl)
            {
                if (detailX > Cylinder.MAX_DETAIL)
                {
                    detailX = Cylinder.MAX_DETAIL;
                }
                if (detailY > Cylinder.MAX_DETAIL)
                {
                    detailY = Cylinder.MAX_DETAIL;
                }
                return _JS.InvokeVoidAsync(
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
            return new ValueTask();
        }

        public ValueTask DrawCylinder(Cylinder cylinder) => DrawCylinder(
            cylinder.Radius,
            cylinder.Height,
            cylinder.DetailX,
            cylinder.DetailY,
            cylinder.ShowBottomCap,
            cylinder.ShowTopCap
        );

        public ValueTask DrawEllipsoid(
            float radiusX,
            float radiusY,
            float radiusZ,
            uint detailX = Ellipsoid.DEFAULT_DETAIL_X,
            uint detailY = Ellipsoid.DEFAULT_DETAIL_Y
        )
        {
            if (IsWebGl)
            {
                if (detailX > Ellipsoid.MAX_DETAIL)
                {
                    detailX = Ellipsoid.MAX_DETAIL;
                }
                if (detailY > Ellipsoid.MAX_DETAIL)
                {
                    detailY = Ellipsoid.MAX_DETAIL;
                }
                return _JS.InvokeVoidAsync(
                    _p5InvokeFunction,
                    "ellipsoid",
                    radiusX,
                    radiusY,
                    radiusZ,
                    detailX,
                    detailY
                );
            }
            return new ValueTask();
        }

        public ValueTask DrawEllipsoid(
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

        public ValueTask DrawEllipsoid(Ellipsoid ellipsoid) => DrawEllipsoid(
            ellipsoid.Dimensions,
            ellipsoid.DetailX,
            ellipsoid.DetailY
        );

        public ValueTask DrawPlane(
            float width,
            float height,
            uint detailX = Models.Plane.DEFAULT_DETAIL,
            uint detailY = Models.Plane.DEFAULT_DETAIL
        ) => IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "plane",
                width,
                height,
                detailX,
                detailY
            ) : new ValueTask();

        public ValueTask DrawPlane(
            Vector2 dimensions,
            uint detailX = Models.Plane.DEFAULT_DETAIL,
            uint detailY = Models.Plane.DEFAULT_DETAIL
        ) => DrawPlane(
            dimensions.X,
            dimensions.Y,
            detailX,
            detailY
        );

        public ValueTask DrawPlane(
            Models.Plane plane
        ) => DrawPlane(
            plane.Width,
            plane.Height,
            plane.DetailX,
            plane.DetailY
        );

        public ValueTask DrawSphere(
            float radius,
            uint detailX = Sphere.MAX_DETAIL,
            uint detailY = Sphere.MAX_DETAIL
        )
        {
            if (IsWebGl)
            {
                if (detailX > Sphere.MAX_DETAIL)
                {
                    detailX = Sphere.MAX_DETAIL;
                }
                if (detailY > Sphere.MAX_DETAIL)
                {
                    detailY = Sphere.MAX_DETAIL;
                }
                return _JS.InvokeVoidAsync(
                    _p5InvokeFunction,
                    "sphere",
                    radius,
                    detailX,
                    detailY
                );
            }
            return new ValueTask();
        }

        public ValueTask DrawSphere(Sphere sphere) => DrawSphere(
            sphere.Radius,
            sphere.DetailX,
            sphere.DetailY
        );

        public ValueTask DrawTorus(
            float radius,
            float tubeRadius,
            uint detailX = Torus.DEFAULT_DETAIL_X,
            uint detailY = Torus.DEFAULT_DETAIL_Y
        )
        {
            if (IsWebGl)
            {
                if (detailX > Torus.MAX_DETAIL_X)
                {
                    detailX = Torus.MAX_DETAIL_X;
                }
                if (detailY > Torus.MAX_DETAIL_Y)
                {
                    detailY = Torus.MAX_DETAIL_Y;
                }
                return _JS.InvokeVoidAsync(
                    _p5InvokeFunction,
                    "torus",
                    radius,
                    tubeRadius,
                    detailX,
                    detailY
                );
            }
            return new ValueTask();
        }

        public ValueTask DrawTorus(Torus torus) => DrawTorus(
            torus.Radius,
            torus.TubeRadius,
            torus.DetailX,
            torus.DetailY
        );
        #endregion

        #endregion
    }
}