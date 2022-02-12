using Depra.Extensions.UnityStructs;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Depra.Extensions.Tests
{
    public class ColorExtensionsTests
    {
        private Color _testedColor;

        [SetUp]
        public void Setup()
        {
            _testedColor = new Color(66, 66, 66);
        }

        [TearDown]
        public void Teardown()
        {
            _testedColor = default;
        }

        [Test, Performance]
        public void Converting_RGB_To_HSV_Default()
        {
            using (Measure.Frames().Scope())
            {
                Color.RGBToHSV(_testedColor, out var h, out var s, out var v);
            }
        }

        [Test, Performance]
        public void Converting_RGB_To_HSL()
        {
            Measure.Method(() => _testedColor.ToHsl()).Run();
        }

        [Test, Performance]
        public void Converting_RGB_To_HSV_Custom()
        {
            Measure.Method(() => _testedColor.ToHsv()).Run();
        }
    }
}