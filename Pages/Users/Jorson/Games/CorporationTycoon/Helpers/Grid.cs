using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Helpers
{
    public class Grid<T> : IEnumerable<T> where T : GridEntry
    {
        #region Public

        #region Constructors
        public Grid(uint width, uint height)
        {
            Height = (int)height;
            Width = (int)width;
            _grid = new T[Width][];
            for (int i = 0; i < Width; i++)
            {
                _grid[i] = new T[Height];
            }
        }
        #endregion

        #region Members
        public readonly int Height;
        public readonly int Width;
        #endregion

        #region Members Methods
        public bool Add(T obj)
        {
            var position = ConvertAbsoluteToGrid(obj.Position);
            for (int i = 0; i < (int)obj.UnitWidth; i++)
            {
                int gridX = i + (int)position.X;
                int gridY = (int)position.Y;
                if (
                    gridX >= Width
                    || gridY >= Height
                    || _grid[gridX][gridY] != null
                )
                {
                    return false;
                }
            }

            for (int i = 0; i < (int)obj.UnitWidth; i++)
            {
                _grid[
                    i + (int)position.X
                ][
                    (int)position.Y
                ] = obj;
            }
            return true;
        }

        public T Get(Vector2 position)
        {
            position = ConvertAbsoluteToGrid(position);
            if (
                position.X < 0
                || position.Y < 0
                || position.X >= Width
                || position.Y >= Height
            )
            {
                return null;
            }
            return _grid[(int)position.X][(int)position.Y];
        }

        public IEnumerator<T> GetEnumerator()
        {
            T obj = null;
            int startX = 0;
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    if (obj == null)
                    {
                        startX = x;
                        obj = _grid[x][y];
                        yield return obj;
                    }
                    else if (x == startX + (int)obj.UnitWidth - 1)
                    {
                        obj = null;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Remove(T obj)
        {
            return true;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private T[][] _grid;
        #endregion

        #region Members Methods
        private Vector2 ConvertAbsoluteToGrid(Vector2 position)
        {
            return new Vector2(
                MathF.Floor(position.X / CorporationTycoonApp.UNIT_SCALE),
                MathF.Floor(position.Y / CorporationTycoonApp.UNIT_SCALE)
            );
        }
        #endregion

        #endregion
    }
}
