using Akka.Actor;
using MovieStreaming.Core;
using MovieStreaming.Messages;
using System;

namespace MovieStreaming.Actors
{
    class PlaybackActor : ReceiveActor
    {
        private string _currentlyWatching;

        public PlaybackActor()
        {
            Console.WriteLine("Creating PlaybackActor");

            Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message));
            Receive<StopMovieMessage>(message => HandleStopMovieMessage());
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            if (_currentlyWatching != null)
            {
                ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping existing one");
            }
            else
            {
                startPlayingMovie(message.MovieTitle);
            }
        }


        private void HandleStopMovieMessage()
        {
            if (_currentlyWatching == null)
            {
                ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing");
            }
            else
            {
                stopPlayingMovie();
            }
        }

        private void startPlayingMovie(string title)
        {
            _currentlyWatching = title;
            ColorConsole.WriteLineGreen(string.Format("User currently watching '{0}'", _currentlyWatching));
        }


        private void stopPlayingMovie()
        {
            ColorConsole.WriteLineGreen(string.Format("User had stopped watching '{0}'", _currentlyWatching));
            _currentlyWatching = null;

        }

        protected override void PreStart()
        {
            // base.PreStart();
            ColorConsole.WriteLineGreen("PlaybackActor PreStart");
        }

        protected override void PostStop()
        {
            // base.PostStop();
            ColorConsole.WriteLineGreen("PlaybackActor PostStop");
        }


        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("PlaybackActor PreRestart because " + reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("PlaybackActor PostRestart because " + reason);
            base.PostRestart(reason);
        }
    }
}
