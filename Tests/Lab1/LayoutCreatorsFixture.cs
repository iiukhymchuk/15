using NUnit.Framework;
using View;

namespace Tests
{
    [TestFixture]
    public class LayoutCreatorsFixture
    {
        LayoutCreators layoutCreators;

        [SetUp]
        public void SetUpFixture()
        {
            layoutCreators = new LayoutCreators((obj, args) => { return; });
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void LayoutCreatorCreatesLayoutWithProperSize(int index)
        {
            // Arange
            var expectedCount = index;

            // Act
            var actualCount = GetLayout(index).Size;

            // Assert
            Assert.AreEqual(expectedCount, actualCount,
                "Layout creator creates wrong size parameter.");
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void LayoutCreatorCreatesLayoutWithProperNumberOfButtons(int index)
        {
            // Arange
            var expectedButtonsNumber = index * index;

            // Act
            var actualButtomsNumber = GetLayout(index).Buttons.Count;

            // Assert
            Assert.AreEqual(expectedButtonsNumber, actualButtomsNumber,
                "Layout creator creates wrong number of buttons for layout.");
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void LayoutCreatorCreatesLayoutWithProperPanelDimensions(int index)
        {
            // Arange
            var expectedPanelDimensions = index * index;

            // Act
            var size = GetLayout(index).Panel;
            var actualPanelDimensions = size.RowCount * size.ColumnCount;

            // Assert
            Assert.AreEqual(expectedPanelDimensions, actualPanelDimensions,
                "Layout creator creates wrong panel dimensions.");
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(int.MaxValue)]
        [TestCase(6)]
        [TestCase(-1)]
        public void LayoutCreatorReturnsNullForWrongInput(int index)
        {
            // Arange
            var expected = (ILayout)null;

            // Act
            var actual = GetLayout(index);

            // Assert
            Assert.AreEqual(expected, actual, "Layout is not null when it should be null.");
        }

        private ILayout GetLayout(int index)
        {
            var layoutCreator = layoutCreators[index];
            return layoutCreator?.CreateLayout();
        }
    }
}