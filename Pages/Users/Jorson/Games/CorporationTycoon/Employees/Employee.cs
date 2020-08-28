﻿using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Buildings;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees
{
    public abstract class Employee
    {
        #region Public

        #region Constants
        public const float Height = UnitHeight * CorporationTycoonApp.UNIT_SCALE;
        public const float Width = UnitWidth * CorporationTycoonApp.UNIT_SCALE;
        public const float UnitHeight = 0.8f;
        public const float UnitWidth = 0.8f;
        #endregion

        #region Members
        public int Desk { get; set; } = -1;
        public Vector2? DeskPosition
        {
            get
            {
                if (!IsEmployed)
                {
                    return null;
                }
                return 
                    OfficeSpace.Position
                    // Offset X and Y to first desk
                    + (
                        Vector2.One
                        * CorporationTycoonApp.UNIT_SCALE / 2f
                    )
                    // Offset X to employee desk
                    + (
                        new Vector2(CorporationTycoonApp.UNIT_SCALE, 0f)
                        * Desk
                    )
                ;
            }
        }
        public Color FillColor { get; set; }
        public bool IsEmployed => OfficeSpace != null && Desk >= 0;
        public Building OfficeSpace { get; set; }
        public Color StrokeColor { get; set; }
        public uint StrokeWeight { get; set; } = 0;

        public Vector2 Position
        {
            get => _rect.Position;
            set
            {
                _rect.Position = value;
            }
        }
        #endregion

        #region Member Methods
        public abstract void Draw(P5App application);

        public abstract void Update(P5App application, double dt);
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Employee(
            Vector2 position,
            Color fillColor,
            Color strokeColor,
            uint strokeWeight
        )
        {
            _rect = new Rectangle(
                position,
                new Vector2(Width, Height)
            );
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWeight = strokeWeight;
        }
        #endregion

        #region Members
        protected Rectangle _rect;
        #endregion

        #endregion
    }
}