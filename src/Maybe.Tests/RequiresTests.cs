using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maybe.Tests
{
    [TestClass]
    public class RequiresTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Requires_NotNull_ThrowsIfNull()
        {
            string s = null;

            Requires.NotNull(s, nameof(s));
        }

        [TestMethod]
        public void Requires_NotNull_PassIfNonNull()
        {
            string s = "Test";

            Requires.NotNull(s, nameof(s));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Requires_NotNullOrEmpty_ThrowsIfNull()
        {
            string s = null;

            Requires.NotEmpty(s, nameof(s));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Requires_NotNullOrEmpty_ThrowsIfEmpty()
        {
            string s = string.Empty;

            Requires.NotEmpty(s, nameof(s));
        }

        [TestMethod]
        public void Requires_NotNullOrEmpty_PassIfNonNull()
        {
            string s = "Test";

            Requires.NotEmpty(s, nameof(s));
        }
    }
}
