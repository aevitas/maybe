using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maybe.Tests
{
    [TestClass]
    public class MaybeTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Maybe_NoValue_ValueThrows()
        {
            var maybe = Maybe<string>.NoValue;

            var v = maybe.Value;
        }

        [TestMethod]
        public void Maybe_WithValue_ReturnsValue()
        {
            var maybe = new Maybe<string>("Test");

            Assert.AreEqual("Test", maybe.Value);
        }

        [TestMethod]
        public void Maybe_Equals_CopiesAreEqual()
        {
            var maybe = new Maybe<string>("Test");
            var copy = maybe;

            Assert.IsTrue(maybe == copy);
        }

        [TestMethod]
        public void Maybe_Equals_DifferentInstancesNotEqual()
        {
            var left = new Maybe<string>("Test");
            var right = Maybe<string>.NoValue;

            Assert.IsTrue(left != right);
        }

        [TestMethod]
        public void Maybe_GetHashCode()
        {
            var maybe = new Maybe<string>("Test");

            Assert.AreNotEqual(0, maybe.GetHashCode());
        }

        [TestMethod]
        public void Maybe_EqualsObject()
        {
            var maybe = new Maybe<string>("Test");
            var copy = maybe;

            Assert.IsTrue(maybe.Equals((object)copy));
        }

        [TestMethod]
        public void Maybe_EqualsObject_NullNotEqual()
        {
            var maybe = new Maybe<string>("Test");

            Assert.IsFalse(maybe.Equals(null));
        }

        [TestMethod]
        public void Maybe_EqualsObject_DifferentTypeMaybeNotEqual()
        {
            var left = Maybe<string>.NoValue;
            var right = Maybe<int>.NoValue;

            Assert.IsFalse(left.Equals(right));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Maybe_Of_ThrowsIfNull()
        {
            string s = null;

            Maybe.Of(s);
        }

        [TestMethod]
        public void Maybe_Of_ContainsString()
        {
            var s = "Test";

            var maybe = Maybe.Of(s);

            Assert.IsTrue(maybe.HasValue);
            Assert.AreEqual("Test", maybe.Value);
        }

        [TestMethod]
        public void Maybe_OfNullable_NoValueIfNull()
        {
            string s = null;

            var maybe = Maybe.OfNullableReference(s);

            Assert.IsFalse(maybe.HasValue);
        }

        [TestMethod]
        public void Maybe_OfNullable_ContainsString()
        {
            var s = "Test";

            var maybe = Maybe.OfNullableReference(s);

            Assert.IsTrue(maybe.HasValue);
            Assert.AreEqual("Test", maybe.Value);
        }

        [TestMethod]
        public void Maybe_ValueType()
        {
            int i = 10;

            var maybe = new Maybe<int>(i);

            Assert.IsTrue(maybe.HasValue);
            Assert.AreEqual(10, maybe.Value);
        }

        [TestMethod]
        public void Maybe_ValueType_NoValue()
        {
            int i = default(int);

            var maybe = new Maybe<int>(i);

            Assert.IsTrue(maybe.HasValue);
            Assert.AreEqual(0, maybe.Value);
        }

        [TestMethod]
        public void Maybe_OfNullableValueType_WithValue()
        {
            int i = 0;

            var maybe = Maybe.OfValueType(i);

            Assert.IsTrue(maybe.HasValue);
            Assert.AreEqual(0, maybe.Value);
        }

        [TestMethod]
        public void Maybe_OfNullableValueType_NoValue()
        {
            int? i = null;

            var maybe = Maybe.OfValueType(i);

            Assert.IsFalse(maybe.HasValue);
        }
    }
}
