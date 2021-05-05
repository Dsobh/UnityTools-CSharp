using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Kreddik.UnityUtils.MathsOp;

namespace Tests
{
    public class TriangleTests
    {
        Vector2 origin;
        Vector2 destination;
        RightTriangle triangle;

        /// <summary>
        /// Esta funcion se ejecuta al principio y no se vuelve a ejecutar: usada para inicializar
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            origin = Vector2.zero;
            destination = Vector2.zero;
            triangle = new RightTriangle(origin, destination);
        }

        /// <summary>
        /// Esta función se ejecuta cada vez que acaba una de las pruebas unitarias: usada para resetear, destruir etc
        /// </summary>
       [TearDown] 
        public void TearDown()
        {
            origin = Vector2.zero;
            destination = Vector2.zero;
            triangle = null;
        }

        [UnityTest]
        public IEnumerator TriangleCreatedProperly()
        {
            origin = new Vector2(10,5);
            destination = new Vector2(20,30);
            triangle = new RightTriangle(origin, destination);
            Assert.IsNotNull(triangle, "The triangle was no created correctly");
            Assert.AreEqual(new Vector2(20,5), triangle.getPointB(), "PointB is not calculated properly");

            Assert.AreEqual(10, triangle.getSideA(), "SideA is not calculated properly");
            Assert.AreEqual(25, triangle.getSideB(), "SideB is not calculated properly");
            Assert.AreEqual(5*Mathf.Sqrt(29), triangle.getHypotenuse(), "Hypotenuse is not calculated properly");
            
            Assert.AreEqual(68, Mathf.Round(triangle.getAngleA()), "AngleA is not calculated properly");
            Assert.AreEqual(90, Mathf.Round(triangle.getAngleB()), "AngleB is not calculated properly");
            Assert.AreEqual(22, Mathf.Round(triangle.getAngleC()), "AngleC is not calculated properly");
            yield return 0;
        }

        [UnityTest]
        public IEnumerator  PythagorasTest()
        {
            origin = new Vector2(10,5);
            destination = new Vector2(20,30);
            Assert.AreEqual(Mathf.Sqrt(725), triangle.Pythagoras(origin, destination), "Hypotenuse1 is not calculated properly");
            origin = new Vector2(40,80);
            destination = new Vector2(15,30);
            Assert.AreEqual(Mathf.Sqrt(3125), triangle.Pythagoras(origin, destination), "Hypotenuse2 is not calculated properly");
            origin = new Vector2(1,40);
            destination = new Vector2(80,9);
            Assert.AreEqual(Mathf.Sqrt(7202), triangle.Pythagoras(origin, destination), "Hypotenuse3 is not calculated properly");
            yield return 0;
        }

        [UnityTest]
        public IEnumerator  CalculateAngleTest()
        {
            Assert.AreEqual(60, Mathf.Round(triangle.CalculateAngle(5,10)), "Angle1 is not calculated properly");
            Assert.AreEqual(0, Mathf.Round(triangle.CalculateAngle(10,10)), "Angle2 is not calculated properly");
            Assert.AreEqual(53, Mathf.Round(triangle.CalculateAngle(60,100)), "Angle3 is not calculated properly");
            Assert.AreEqual(120, Mathf.Round(triangle.CalculateAngle(-5,10)), "Angle4 is not calculated properly");
            yield return 0;
        }
    }
}
