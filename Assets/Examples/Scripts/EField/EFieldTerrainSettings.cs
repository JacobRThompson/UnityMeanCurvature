using System;
using UnityEngine;

namespace MarchingCubes.EField
{
    /// <summary>
    /// The procedural terrain generation settings
    /// </summary>
    [Serializable]
    public struct EFieldTerrainSettings
    {
        ///<summary> The permittivity of free space, ε₀ </summary>
        public float Epsilon { get => _epsilon; set => _epsilon = value; }
        [SerializeField] private float _epsilon;
        
        /// <summary> The potential value across the entire generated surface </summary>
        public float IsosurfacePotential { get => _isosurfacePotential; set => _isosurfacePotential = value; }
        [SerializeField] private float _isosurfacePotential;

        /// <summary> The maximum curvature deviation </summary>
        public float MaxCurvatureDeviation { get => _maxCurvatureDeviation; set => _maxCurvatureDeviation = value; }
        [SerializeField] private float _maxCurvatureDeviation;

        ///<summary> describes the dimensions of the area in which we preform marching cubes </summary> 
        public Vector3 Bounds {
            get { return new Vector3(_boundsX, _boundsY, _boundsZ);}
            set {
                _boundsX=value.x;
                _boundsY=value.y;
                _boundsZ=value.z;
            }
        }
        
        public float BoundsX { get => _boundsX; set => _boundsX = value; }
        public float BoundsY { get => _boundsY; set => _boundsY = value; }
        public float BoundsZ { get => _boundsZ; set => _boundsZ = value; }
        [SerializeField] private float _boundsX;
        [SerializeField] private float _boundsY;
        [SerializeField] private float _boundsZ;

        /// <summary> Constructor </summary>
        /// <param name="epsilon">The permittivity of free space, ε₀ </param>
        /// <param name="isosurfacePotential">The potential value across the entire generated surface</param>
        /// <param name="maxCurvatureDeviation">ADD DESCRIPTION</param>
        public EFieldTerrainSettings(float epsilon, float isosurfacePotential, float maxCurvatureDeviation,
            Vector3 bounds)
        {
            this._epsilon = epsilon;
            this._isosurfacePotential   = isosurfacePotential;
            this._maxCurvatureDeviation = maxCurvatureDeviation;
            this.Bounds = bounds;

        }
    }

}

