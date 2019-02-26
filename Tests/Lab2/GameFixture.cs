﻿using Controller;
using Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests
{
    [TestFixture]
    public class GameFixture
    {
        [Test]
        public void Spy_OnCreationOfNewGameSetSizeCalled()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(x => x.GetItem(0, 0)).Return(0);

            // Act
            var game = new Game(4, 1, spyBoard);

            // Assert
            spyBoard.AssertWasCalled(x =>
                x.SetSize(Arg<int>.Is.Equal(4)),
                options => options.Repeat.Once());
        }

        [Test]
        public void Spy_OnCreationOfNewGameSetWinPositionCalled()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(x => x.GetItem(0, 0)).Return(0);

            // Act
            var game = new Game(4, 1, spyBoard);

            // Assert
            spyBoard.AssertWasCalled(x => x.SetWinPosition(), options => options.Repeat.Once());
        }

        [Test]
        public void Spy_OnStartNewGameMethodsCalledTwice()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(x => x.GetItem(0, 0)).Return(0);

            // Act
            var game = new Game(4, 1, spyBoard);
            game.StartNewGame(4, 1);

            // Assert
            spyBoard.AssertWasCalled(x =>
                x.SetSize(Arg<int>.Is.Equal(4)),
                options => options.Repeat.Twice());
            spyBoard.AssertWasCalled(x =>
                x.SetWinPosition(), options => options.Repeat.Twice());
        }

        [Test]
        public void Stub_OnUndoBoardIsNotChangedWhenHistoryReturnsNull()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(x => x.GetItem(0, 0)).Return(0);
            var stubHistory = MockRepository.GenerateStub<IStack<BoardDifference>>();
            stubHistory.Stub(x => x.Pop()).Return(null);

            // Act
            var game = new Game(4, 1, spyBoard, stubHistory);
            game.Undo();

            // Assert
            spyBoard.AssertWasCalled(x => x.SetSize(1), options => options.Repeat.Once().IgnoreArguments());
            spyBoard.AssertWasCalled(x => x.SetWinPosition(), options => options.Repeat.Once());
        }

        [Test]
        public void Stub_OnUndoBoardIsChangedWhenHistoryReturnsValidValue()
        {
            // Arrange
            int x = 1;
            int y = 1;
            int _x = 0;
            int _y = 0;
            int result = 42;

            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(b => b.GetItem(x, y)).Return(result);
            var stubHistory = MockRepository.GenerateStub<IStack<BoardDifference>>();
            stubHistory.Stub(h => h.Pop()).Return(new BoardDifference
            {
                PositionOfSpace = (_x, _y),
                PreviousPositionOfSpace = (x, y)
            });

            // Act
            var game = new Game(4, 1, spyBoard, stubHistory);
            game.Undo();

            // Assert
            spyBoard.AssertWasCalled(b => b.SetItem(_x, _y, result), options => options.Repeat.Once());
        }

        [Test]
        public void Stub_OnExecuteCommandHistoryClearIsCalledWhenExecuteReturnsFalse()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(b => b.GetItem(0, 0)).Return(0);
            var spyHistory = MockRepository.GenerateStub<IStack<BoardDifference>>();
            var stubCommand = MockRepository.GenerateStub<ICommand>();
            stubCommand.Expect(x => x.Execute()).Return(false);

            // Act
            var game = new Game(4, 1, spyBoard, spyHistory);
            game.ExecuteCommand(stubCommand);

            // Assert
            spyHistory.AssertWasCalled(x => x.Clear(), options => options.Repeat.Once());
        }

        [Test]
        public void Fake_OnExecuteCommandHistoryPushIsCalledWhenExecuteReturnsTrue()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(b => b.GetItem(0, 0)).Return(0);
            var fakeHistory = MockRepository.GenerateStub<FakeHistory<BoardDifference>>();
            var stubCommand = MockRepository.GenerateStub<ICommand>();
            stubCommand.Expect(x => x.Execute()).Return(true);

            // Act
            var game = new Game(4, 1, spyBoard, fakeHistory);
            game.ExecuteCommand(stubCommand);

            // Assert
            fakeHistory.AssertWasCalled(x => x.Push(null), options => options.Repeat.Once().IgnoreArguments());
        }

        [Test]
        public void Fake_OnExecuteCommandHistoryPushIsCalledTwiceWhenExecuteReturnsTrue()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(b => b.GetItem(0, 0)).Return(0);
            var fakeHistory = MockRepository.GenerateStub<FakeHistory<BoardDifference>>();
            var stubCommand = MockRepository.GenerateStub<ICommand>();
            stubCommand.Expect(x => x.Execute()).Return(true);

            // Act
            var game = new Game(4, 1, spyBoard, fakeHistory);
            game.ExecuteCommand(stubCommand);
            game.ExecuteCommand(stubCommand);

            // Assert
            fakeHistory.AssertWasCalled(x => x.Push(null), options => options.Repeat.Twice().IgnoreArguments());
        }

        [Test]
        public void Fake_OnExecuteCommandHistoryPushAndPopAreCalledWhenExecuteReturnsTrue()
        {
            // Arrange
            var spyBoard = MockRepository.GenerateStub<IBoard>();
            spyBoard.Stub(b => b.GetItem(0, 0)).Return(0);
            var fakeHistory = MockRepository.GenerateStub<FakeHistory<BoardDifference>>();
            var stubCommand = MockRepository.GenerateStub<ICommand>();
            stubCommand.Expect(x => x.Execute()).Return(true);

            // Act
            var game = new Game(4, 1, spyBoard, fakeHistory);
            game.ExecuteCommand(stubCommand);
            game.ExecuteCommand(stubCommand);
            game.Undo();

            // Assert
            fakeHistory.AssertWasCalled(x => x.Push(null), options => options.Repeat.Twice().IgnoreArguments());
            fakeHistory.AssertWasCalled(x => x.Pop(), options => options.Repeat.Once());
        }
    }
}