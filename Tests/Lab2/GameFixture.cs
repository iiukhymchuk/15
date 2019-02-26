using Controller;
using Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests
{
    [TestFixture]
    public class GameFixture
    {
        [Test]
        public void SpyOnCreationOfNewGameSetSizeCalled()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(x => x.GetItem(0, 0)).Return(0);

            // Act
            var game = new Game(4, 1, spyBoard);

            // Assert
            spyBoard.AssertWasCalled<IBoard>(x =>
                x.SetSize(Arg<int>.Is.Equal(4)),
                options => options.Repeat.Once());
        }

        [Test]
        public void SpyOnCreationOfNewGameSetWinPositionCalled()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(x => x.GetItem(0, 0)).Return(0);

            // Act
            var game = new Game(4, 1, spyBoard);

            // Assert
            spyBoard.AssertWasCalled<IBoard>(x =>
                x.SetWinPosition(), options => options.Repeat.Once());
        }

        [Test]
        public void SpyOnStartNewGameMethodsCalledTwice()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(x => x.GetItem(0, 0)).Return(0);

            // Act
            var game = new Game(4, 1, spyBoard);
            game.StartNewGame(4, 1);

            // Assert
            spyBoard.AssertWasCalled<IBoard>(x =>
                x.SetSize(Arg<int>.Is.Equal(4)),
                options => options.Repeat.Twice());
            spyBoard.AssertWasCalled<IBoard>(x =>
                x.SetWinPosition(), options => options.Repeat.Twice());
        }
    }
}