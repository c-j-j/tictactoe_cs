namespace TicTacToe
{
    public static class TestGameFactory
    {
        public static Game NewGame(){
            return new Game(new Board(), new StubPlayer(), new StubPlayer());
        }
    }
}
