using Controller;
using Model;
using NUnit.Framework;
using Rhino.Mocks;

#pragma warning disable CS0618 // Type or member is obsolete
namespace Tests.Lab3
{
    [TestFixture]
    public class GameFixture
    {
        [TestCase(4, 1)]
        [TestCase(3, 2)]
        [TestCase(5, 0)]
        public void Strict_OnlyHistoryPopMethodIsCalled(int size, int mode)
        {
            // Arrange
            var mocks = new MockRepository();
            var strictMockHistory = mocks.CreateMock<IStack<BoardDifference>>();
            strictMockHistory.Stub(x => x.Pop()).Return(null);

            mocks.ReplayAll();

            // Act
            var game = new Game(size, mode);
            game.Undo();

            // Assert
            mocks.VerifyAll();
        }

        [TestCase(4, 1)]
        [TestCase(3, 2)]
        [TestCase(5, 0)]
        public void Strict_OnlyHistoryClearMethodIsCalled(int size, int mode)
        {
            // Arrange
            var mocks = new MockRepository();
            var stubCommand = MockRepository.GenerateStub<ICommand>();
            stubCommand.Stub(x => x.Execute()).Return(false);
            var strictMockHistory = mocks.CreateMock<IStack<BoardDifference>>();
            strictMockHistory.Clear();

            mocks.ReplayAll();

            // Act
            var game = new Game(size, mode, history: strictMockHistory);
            game.ExecuteCommand(stubCommand);

            // Assert
            mocks.VerifyAll();
        }

        [TestCase(4, 1)]
        [TestCase(3, 0)]
        [TestCase(5, 2)]
        public void NotStrict_OnlyHistoryClearMethodIsCalled(int size, int mode)
        {
            // Arrange
            var mockCommand = MockRepository.GenerateMock<ICommand>();
            var mockHistory = MockRepository.GenerateMock<IStack<BoardDifference>>();
            mockHistory.Clear();

            // Act
            var game = new Game(size, mode, history: mockHistory);
            game.ExecuteCommand(mockCommand);

            // Assert
            mockHistory.AssertWasCalled(x => x.Clear());
        }

        [TestCase(4, 1)]
        [TestCase(3, 0)]
        [TestCase(5, 2)]
        public void NotStrict_OnlyHistoryPopMethodIsCalled(int size, int mode)
        {
            // Arrange
            var mockCommand = MockRepository.GenerateMock<ICommand>();
            var mockHistory = MockRepository.GenerateMock<IStack<BoardDifference>>();
            mockHistory.Clear();

            // Act
            var game = new Game(size, mode, history: mockHistory);
            game.Undo();

            // Assert
            mockHistory.AssertWasCalled(x => x.Pop());
        }

        [TestCase(4, 1)]
        [TestCase(3, 0)]
        [TestCase(5, 2)]
        public void Partial_OnlyHistoryClearMethodIsCalled(int size, int mode)
        {
            // Arrange
            var mockCommand = MockRepository.GenerateMock<ICommand>();
            var mockHistory = MockRepository.GeneratePartialMock<History<BoardDifference>>();
            mockHistory.Clear();

            // Act
            var game = new Game(size, mode, history: mockHistory);
            game.ExecuteCommand(mockCommand);

            // Assert
            mockHistory.AssertWasCalled(x => x.Clear());
        }

        [TestCase(4, 1)]
        [TestCase(3, 0)]
        [TestCase(5, 2)]
        public void Partial_OnlyHistoryPopMethodIsCalled(int size, int mode)
        {
            // Arrange
            var mockCommand = MockRepository.GenerateMock<ICommand>();
            var mockHistory = MockRepository.GeneratePartialMock<History<BoardDifference>>();
            mockHistory.Clear();

            // Act
            var game = new Game(size, mode, history: mockHistory);
            game.Undo();

            // Assert
            mockHistory.AssertWasCalled(x => x.Pop());
        }
    }
}
#pragma warning restore CS0618 // Type or member is obsolete