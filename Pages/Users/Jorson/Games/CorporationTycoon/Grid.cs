using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon
{
    public class Grid : IEnumerable<Building>
    {
        #region Public

        #region Constructors
        public Grid(uint width, uint height)
        {
            Height = (int)height;
            Width = (int)width;
            _grid = new Building[Width][];
            for (int i = 0; i < Width; i++)
            {
                _grid[i] = new Building[Height];
            }
        }
        #endregion

        #region Members
        public readonly int Height;
        public readonly int Width;
        #endregion

        #region Members Methods
        public bool Add(Building building)
        {
            var position = ConvertAbsoluteToGrid(building.Position);
            for (int i = 0; i < building.UnitWidth; i++)
            {
                int gridX = i + (int)position.X;
                int gridY = (int)position.Y;
                if (
                    gridX >= Width
                    || _grid[gridX][gridY] != null
                )
                {
                    return false;
                }
            }

            for (int i = 0; i < building.UnitWidth; i++)
            {
                _grid[
                    i + (int)position.X
                ][
                    (int)position.Y
                ] = building;
            }
            return true;
        }

        public IEnumerator<Building> GetEnumerator()
        {
            Building building = null;
            int startX = 0;
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    if (building == null)
                    {
                        startX = x;
                        building = _grid[x][y];
                        yield return building;
                    }
                    else if (x == startX + building.UnitWidth - 1)
                    {
                        building = null;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Remove(Building building)
        {
            return true;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Building[][] _grid;
        #endregion

        #region Members Methods
        private Vector2 ConvertAbsoluteToGrid(Vector2 position)
        {
            return new Vector2(
                MathF.Floor(position.X / Building.UNIT_SCALE),
                MathF.Floor(position.Y / Building.UNIT_SCALE)
            );
        }
        #endregion

        #endregion
    }
}
