using Controller;
using NUnit.Framework;

namespace Tests.Lab1
{
    [TestFixture]
    public class HistoryFixture
    {
        History<int?> history;

        [SetUp]
        public void SetUp()
        {
            history = new History<int?>(5);
        }

        [TearDown]
        public void TearDown()
        {
            history.Clear();
        }

        [Test]
        public void AddingAndThanRemovingElementsSurviveTheCapacityNumberOfElements()
        {
            // Act
            history.Push(1);
            history.Push(2);
            history.Push(3);
            history.Push(4);
            history.Push(5);
            history.Push(6);

            var pop1 = history.Pop();
            var pop2 = history.Pop();
            var pop3 = history.Pop();
            var pop4 = history.Pop();
            var pop5 = history.Pop();
            var pop6 = history.Pop();

            // Assert
            Assert.AreEqual(6, pop1, $"History class logic is broken. We expect 6 but actually get {pop1}.");
            Assert.AreEqual(5, pop2, $"History class logic is broken. We expect 5 but actually get {pop2}.");
            Assert.AreEqual(4, pop3, $"History class logic is broken. We expect 4 but actually get {pop3}.");
            Assert.AreEqual(3, pop4, $"History class logic is broken. We expect 3 but actually get {pop4}.");
            Assert.AreEqual(2, pop5, $"History class logic is broken. We expect 2 but actually get {pop5}.");
            Assert.AreEqual(null, pop6, $"History class logic is broken. We expect null but actually get {pop6}.");
        }

        [Test]
        public void AddingAndThanRemovingElementsInBoundariesOfCapacityWePopWhatWePushed()
        {
            // Act
            history.Push(1);
            history.Push(2);
            history.Push(3);
            history.Push(4);
            history.Push(5);

            history.Pop();
            history.Pop();
            history.Pop();
            history.Pop();
            history.Pop();

            history.Push(1);
            history.Push(2);
            history.Push(3);
            history.Push(4);
            history.Push(5);

            var pop1 = history.Pop();
            var pop2 = history.Pop();
            var pop3 = history.Pop();
            var pop4 = history.Pop();
            var pop5 = history.Pop();

            // Assert
            Assert.AreEqual(5, pop1, $"History class logic is broken. We expect 5 but actually get {pop1}.");
            Assert.AreEqual(4, pop2, $"History class logic is broken. We expect 4 but actually get {pop2}.");
            Assert.AreEqual(3, pop3, $"History class logic is broken. We expect 3 but actually get {pop3}.");
            Assert.AreEqual(2, pop4, $"History class logic is broken. We expect 2 but actually get {pop4}.");
            Assert.AreEqual(1, pop5, $"History class logic is broken. We expect 1 but actually get {pop5}.");
        }

        [Test]
        public void PopAllTheTimeWontThrow()
        {
            for (int i = 0; i < 100; i++)
            {
                // Act
                var pop = history.Pop();

                // Assert
                Assert.AreEqual(null, pop, $"History class logic is broken. We expect null but actually get {pop}.");
            }
        }

        [Test]
        public void PushAllTheTimeWontThrow()
        {
            for (int i = 0; i < 100; i++)
            {
                // Act
                history.Push(i);
            }
            var pop = history.Pop();

            // Assert
            Assert.AreEqual(99, pop, $"History class logic is broken. We expect 99 but actually get {pop}.");
        }
    }
}