using Akka.Actor;
using MovieStreaming.Core;
using MovieStreaming.Messages;
using System;
using System.Collections.Generic;

namespace MovieStreaming.Actors
{
    class PlaybackStatisticsActor: ReceiveActor
    {
        private readonly Dictionary<string, IActorRef> _movies;

        public PlaybackStatisticsActor()
        {
            _movies = new Dictionary<string, IActorRef>();

            Receive<PlayMovieMessage>(message => {
                CreateChildIfNoExists(message.MovieTitle);
                IActorRef childActorRef = _movies[message.MovieTitle];

                childActorRef.Tell(message);
            });
        }

        private void CreateChildIfNoExists(string movieTitle)
        {
            if (!_movies.ContainsKey(movieTitle))
            {
                _movies.Add(movieTitle, Context.ActorOf(Props.Create<MoviePlayCounterActor>(), string.Format("movieTitle:{0}", movieTitle)));
                ColorConsole.WriteLineCyan(string.Format("PlaybackStatisticsActor created new child MoviePlayCounterActor for {0} (Total Users: {1})", movieTitle, _movies.Count));
            }
        }

        #region Hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen(string.Format("{0} PreStart", this.GetType().Name));
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen(string.Format("{0} PostStop", this.GetType().Name));
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen(string.Format("{0} PreRestart because {1}", this.GetType().Name, reason));
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen(string.Format("{0} PostRestart because {1}", this.GetType().Name, reason));
            base.PostRestart(reason);
        }
        #endregion
    }
}
