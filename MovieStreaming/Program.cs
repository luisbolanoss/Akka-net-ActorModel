using System;
using System.Threading;
using Akka.Actor;
using MovieStreaming.Actors;
using MovieStreaming.Core;
using MovieStreaming.Messages;

namespace MovieStreaming
{
    class Program
    {
        static ActorSystem MovieStreamingActorSystem;

        static void ShortPause()
        {
            Thread.Sleep(300);
        }

        static void Main(string[] args)
        {
            ColorConsole.WriteLineGray("Creating MovieStreamingActorSystem");
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            ColorConsole.WriteLineGray("Creating actor supervisor hierarchy");
            MovieStreamingActorSystem.ActorOf(Props.Create<PlaybackActor>(), "Playback");

            do
            {
                ShortPause();

                Console.WriteLine();
                ColorConsole.WriteLineDarkGray("Input a command and hit Enter");

                string command = Console.ReadLine();
                string[] split = command.Split(",");
                string action = split[0];

                ActorSelection userCoordinatorActor = MovieStreamingActorSystem.ActorSelection("/user/Playback/UserCoordinator");
                ActorSelection playbackStatisticsActor = MovieStreamingActorSystem.ActorSelection("/user/Playback/PlaybackStatistics");

                if (action.Equals("play"))
                {
                    int userId = int.Parse(split[1]);
                    string movieTitle = split[2];
                    var message = new PlayMovieMessage(movieTitle, userId);

                    userCoordinatorActor.Tell(message);
                    playbackStatisticsActor.Tell(message);
                }

                if (command.StartsWith("stop"))
                {
                    int userId = int.Parse(split[1]);
                    var message = new StopMovieMessage(userId);

                    userCoordinatorActor.Tell(message);
                }

                if (command.StartsWith("exit"))
                {
                    MovieStreamingActorSystem.Terminate();
                    ColorConsole.WriteLineGray("Actor system shutdown");
                    Console.ReadKey();
                    Environment.Exit(1);
                }

            } while (true);


        }
    }
}
