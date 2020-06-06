using Akka.Actor;
using MovieStreaming.Core;
using MovieStreaming.Messages;
using System;

namespace MovieStreaming.Actors
{
    public class UserActor : ReceiveActor
    {
        public UserActor()
        {
            Stopped();   
        }

        private void Playing()
        {
            Receive<StopMovieMessage>(message => StopPlayingMovie());
            Receive<PlayMovieMessage>(message => ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping existing one"));
            ColorConsole.WriteLineCyan("User has now become Playing");
        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));
            Receive<StopMovieMessage>(message => ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping existing one"));
            ColorConsole.WriteLineCyan("User has now become Stopped");
        }

       

        private void StartPlayingMovie(string title)
        {
            ColorConsole.WriteLineYellow(string.Format("User currently watching '{0}'", title));
            Become(Playing);
        }


        private void StopPlayingMovie()
        {
            ColorConsole.WriteLineGreen("User had stopped watching the movie");
            Become(Stopped);
        }


        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen( "UserActor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("UserActor PostStop");
        }


        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("UserActor PreRestart because " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("UserActor PostRestart because " + reason);
            base.PostRestart(reason);
        }
    }
}
