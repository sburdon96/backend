using FluentAssertions;
using NUnit.Framework;

namespace PostcodeApi.Test
{
    public class Tests
    {
        [Test]
        public void TrueShouldBeTrue()
        {
            true.Should().BeTrue();
        }
    }
}