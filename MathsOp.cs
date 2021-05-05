/***
    * A class to work with right rectangles. The implementation follows the next schema:
        c Cº
        |\
        | \
        |  \
      B |   \ C
        |    \
        |     \
       b|______\a
     Bº     A   Aº

    * Author: Kreddik (DSobh)
    * Last Update: 04/05/2021
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kreddik.UnityUtils.MathsOp
{
    public class RightTriangle
    {
        /// <summary>
        /// Store for the points properties.
        /// </summary>
        private Vector2 pointA, pointB, pointC; //Points of the triangle
        /// <summary>
        /// Store for the sides properties.
        /// </summary>
        private float sideA, sideB, hypotenuse; //Sides of the triangle
        /// <summary>
        /// Store for the angles properties.
        /// </summary>
        private float angleA, angleB, angleC; //Angles of the triangle

        public RightTriangle(Vector2 a, Vector2 c)
        {
            this.pointA = a;
            this.pointB = new Vector2(c.x, a.y);
            this.pointC = c;

            sideA = Pythagoras(pointA, pointB);
            sideB = Pythagoras(pointB, pointC);
            hypotenuse = Pythagoras(pointA, pointC);

            angleA = CalculateAngle(sideA, hypotenuse);
            angleB = CalculateAngle(sideA, sideB);
            angleC = CalculateAngle(hypotenuse, sideA);
        }

        /// <summary>
        /// Method that apply Pythagoras Theorem to obtain the distance between two points.
        /// Sqrt(origin^2 + destination^2)
        /// </summary>
        /// <param name="origin">Point of origin</param>
        /// <param name="destination">Point of destination</param>
        /// <returns>Distance (in float) between two points</returns>    
        public float Pythagoras(Vector2 origin, Vector2 destination)
        { 
            float a = Mathf.Abs(destination.x - origin.x);
            float b = Mathf.Abs(destination.y - origin.y);
            return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        }

        /// <summary>
        /// Method that calculate the angle of the triangle using Pythagoras Theorem
        /// arcos(a/b)
        /// </summary>
        /// <param name="side1">First side of the rectangle</param>
        /// <param name="side2">Second side of the rectangle</param>
        /// <returns>Calculated angle in Degrees</returns>
        public float CalculateAngle(float side1, float side2) //c/b
        {
            return Mathf.Rad2Deg * Mathf.Acos(side1 / side2);
        }

        //Getters --------------------------------------------------------------------
        public Vector2 getPointA() {
            return this.pointA;
        }

        public float getSideA() {
            return this.sideA;
        }

        public float getAngleA() {
            return this.angleA;
        }

        public Vector2 getPointB() {
            return this.pointB;
        }

        public float getSideB() {
            return this.sideB;
        }

        public float getAngleB() {
            return this.angleB;
        }

        public Vector2 getPointC() {
            return this.pointC;
        }

        public float getHypotenuse() {
            return this.hypotenuse;
        }

        public float getAngleC() {
            return this.angleC;
        }

        //End of Getters -------------------------------------------------------------

    }
}
