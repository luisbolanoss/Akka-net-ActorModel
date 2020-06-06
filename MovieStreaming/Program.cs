using System;
using Akka.Actor;
using MovieStreaming.Actors;
using MovieStreaming.Messages;

namespace MovieStreaming
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;
        static void initPlaybackActor()
        {
            Props playbackActorProps = Props.Create<PlaybackActor>();
            IActorRef playbackActorRef = MovieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");

            // playbackActorRef.Tell(PoisonPill.Instance);

            Console.ReadKey();
            Console.WriteLine("Sending Codenan the Destroyer");
            playbackActorRef.Tell(new PlayMovieMessage("Codenan the Destroyer", 1));

            Console.ReadKey();
            Console.WriteLine("Boolean Lies");
            playbackActorRef.Tell(new PlayMovieMessage("Boolean Lies", 77));


            Console.ReadKey();
            Console.WriteLine("Sending  a StopMovieMessage");
            playbackActorRef.Tell(new StopMovieMessage());

            Console.ReadKey();
            Console.WriteLine("Sending another StopMovieMessage");
            playbackActorRef.Tell(new StopMovieMessage());
        }

        static void initUserActor()
        {
            Props userActorProps = Props.Create<UserActor>();
            IActorRef userActorRef = MovieStreamingActorSystem.ActorOf(userActorProps, "UserActor");

            Console.ReadKey();
            Console.WriteLine("Sending Codenan the Destroyer");
            userActorRef.Tell(new PlayMovieMessage("Codenan the Destroyer", 1));

            Console.ReadKey();
            Console.WriteLine("Boolean Lies");
            userActorRef.Tell(new PlayMovieMessage("Boolean Lies", 77));


            Console.ReadKey();
            Console.WriteLine("Sending  a StopMovieMessage");
            userActorRef.Tell(new StopMovieMessage());

            Console.ReadKey();
            Console.WriteLine("Sending another StopMovieMessage");
            userActorRef.Tell(new StopMovieMessage());
        }

        static void Main(string[] args)
        {
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            // initPlaybackActor();
            initUserActor();

            Console.ReadKey();
            MovieStreamingActorSystem.Terminate();
            Console.WriteLine("Actor System shutdown");
            Console.ReadKey();
        }
    }
}
