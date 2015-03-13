using System;
using NUnit.Framework;

namespace TicTacToe.Tests
{
	public class HumanPlayer : Player
	{
		public Move GetMove ()
		{
			return new Move();
		}

	}

}

