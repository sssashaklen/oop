﻿namespace lab1
{
    public class TrainingGame(GameAccount? player1, GameAccount? player2) : Game(player1, player2)
    {
        public override bool IsTrainingGame() => true;
        public override void ImitationGame(GameAccount player1, GameAccount player2, int rating)
        {
   
            int result = new Random().Next(0, 2); 
            int gameIndex = GetNextGameIndex(); 
            
            if (result == 0) 
            {

                player1.WinGame(player2.UserName, 0, gameIndex); 
                player2.LoseGame(player1.UserName, 0, gameIndex); 
            }
            else
            {
                player2.WinGame(player1.UserName, 0, gameIndex); 
                player1.LoseGame(player2.UserName, 0, gameIndex); 
            }
        }
    }
}