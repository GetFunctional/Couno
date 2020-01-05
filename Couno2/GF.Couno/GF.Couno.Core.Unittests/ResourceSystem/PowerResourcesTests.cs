using System.Collections.Generic;
using GF.Couno.Core.ResourceSystem;
using NUnit.Framework;

namespace GF.Couno.Core.Unittests.ResourceSystem
{
    [TestFixture]
    internal class PowerResourcesTests
    {
        private readonly List<PowerResource> DistinctPowerResources = new List<PowerResource>
        {
            new PowerResource(4, PowerColor.Black),
            new PowerResource(2, PowerColor.Green),
            new PowerResource(1, PowerColor.Red),
            new PowerResource(0, PowerColor.Yellow)
        };

        [Test]
        public void PowerResource_CreationWithDistinctValues2_Works()
        {
            // Arrange 
            var distinctPowerResources = new List<PowerResource>
            {
                new PowerResource(4, PowerColor.Black),
                new PowerResource(2, PowerColor.Green),
                new PowerResource(1, PowerColor.Red),
                new PowerResource(0, PowerColor.Yellow)
            };

            // Act
            var powerResource = new PowerResources(distinctPowerResources);

            // Assert
            Assert.That(powerResource.AvailableAmountOf(PowerColor.Green), Is.EqualTo(2));
            Assert.That(powerResource.AvailableAmountOf(PowerColor.Black), Is.EqualTo(4));
            Assert.That(powerResource.AvailableAmountOf(PowerColor.Red), Is.EqualTo(1));
            Assert.That(powerResource.AvailableAmountOf(PowerColor.Yellow), Is.EqualTo(0));
            Assert.That(powerResource.HasResource(PowerColor.Yellow), Is.EqualTo(false));
            Assert.That(powerResource.HasResource(PowerColor.Red), Is.EqualTo(true));
        }

        [Test]
        public void PowerResource_CreationWithNonDistinctValues1_ShouldMerge()
        {
            // Arrange 
            var distinctPowerResources = new List<PowerResource>
            {
                new PowerResource(4, PowerColor.Black),
                new PowerResource(2, PowerColor.Black),
                new PowerResource(1, PowerColor.Red),
                new PowerResource(0, PowerColor.Red)
            };

            // Act
            var powerResource = new PowerResources(distinctPowerResources);

            // Assert
            Assert.That(powerResource.AvailableAmountOf(PowerColor.Black), Is.EqualTo(6));
            Assert.That(powerResource.AvailableAmountOf(PowerColor.Red), Is.EqualTo(1));
            Assert.That(powerResource.HasResource(PowerColor.Yellow), Is.EqualTo(false));
            Assert.That(powerResource.HasResource(PowerColor.Black), Is.EqualTo(true));
        }

        [Test]
        public void PowerResources_AddingResource_AddsResource()
        {
            // Arrange
            var powerResource = new PowerResources(this.DistinctPowerResources);

            // Act
            powerResource.AddResource(new PowerResource(4, PowerColor.Blue));

            // Assert
            Assert.That(powerResource.HasResource(PowerColor.Blue), Is.True);
            Assert.That(powerResource.AvailableAmountOf(PowerColor.Blue), Is.EqualTo(4));
        }

        [Test]
        public void PowerResources_RemovingResource_RemovesResource()
        {
            // Arrange
            var powerResource = new PowerResources(this.DistinctPowerResources);

            // Act
            powerResource.AddResource(new PowerResource(4, PowerColor.Blue));
            powerResource.RemoveResource(new PowerResource(3, PowerColor.Blue));

            // Assert
            Assert.That(powerResource.HasResource(PowerColor.Blue), Is.True);
            Assert.That(powerResource.AvailableAmountOf(PowerColor.Blue), Is.EqualTo(1));
        }


        [Test]
        public void PowerResources_CreationWithDistinctValues_Works()
        {
            // Arrange + Act
            var powerResource = new PowerResources(this.DistinctPowerResources);
        }
    }
}