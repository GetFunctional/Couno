using System;
using GF.Couno.Core.ResourceSystem;
using NUnit.Framework;

namespace GF.Couno.Core.Unittests.ResourceSystem
{
    [TestFixture]
    internal class PowerResourceTests
    {
        [Test]
        public void PowerResource_Creation_WithNegativeValue_Tests()
        {
            // Arrange + Act
            var powerResource = new PowerResource(-2, PowerColor.Black);

            // Assert
        }

        [Test]
        public void PowerResource_CreationWithPositiveValue_Tests()
        {
            // Arrange + Act
            var powerResource = new PowerResource(2, PowerColor.Red);

            // Assert
        }

        [Test]
        public void PowerResource_Merge_Tests()
        {
            // Arrange 
            var powerResource1 = new PowerResource(2, PowerColor.Red);
            var powerResource2 = new PowerResource(2, PowerColor.Red);

            // Act
            var mergedResource = powerResource1.MergeResources(powerResource2);

            // Assert
            Assert.That(powerResource1.Amount, Is.EqualTo(2));
            Assert.That(powerResource2.Amount, Is.EqualTo(2));
            Assert.That(mergedResource.Amount, Is.EqualTo(4));
        }

        [Test]
        public void PowerResource_Merge_Tests2()
        {
            // Arrange 
            var powerResource1 = new PowerResource(2, PowerColor.Red);
            var powerResource2 = new PowerResource(-2, PowerColor.Red);

            // Act
            var mergedResource = powerResource1.MergeResources(powerResource2);

            // Assert
            Assert.That(powerResource1.Amount, Is.EqualTo(2));
            Assert.That(powerResource2.Amount, Is.EqualTo(-2));
            Assert.That(mergedResource.Amount, Is.EqualTo(0));
        }


        [Test]
        public void PowerResource_MergeOfDifferentColorsFails_Tests()
        {
            // Arrange 
            var powerResource1 = new PowerResource(2, PowerColor.Red);
            var powerResource2 = new PowerResource(2, PowerColor.Green);

            // Act
            Assert.Catch<ArgumentException>(() => powerResource1.MergeResources(powerResource2));
        }
    }
}