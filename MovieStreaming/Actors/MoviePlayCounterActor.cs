using Akka.Actor;
using MovieStreaming.Core;
using MovieStreaming.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStreaming.Actors
{
    class MoviePlayCounterActor: ReceiveActor
    {
        public int _watched;

        public MoviePlayCounterActor()
        {
            _watched = 0;
            Receive<PlayMovieMessage>(message => HandredCount(message));
        }

        private void HandredCount(PlayMovieMessage message) {
            _watched = _watched + 1;
            ColorConsole.WriteLineYellow(string.Format("The Movie {0} was watching {1} times", message.MovieTitle, _watched));
        }
    }
}
