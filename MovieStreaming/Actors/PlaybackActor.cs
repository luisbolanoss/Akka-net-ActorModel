using Akka.Actor;
using MovieStreaming.Core;
using System;

namespace MovieStreaming.Actors
{
    class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            Context.ActorOf(Props.Create<UserCordinatorActor>(), "UserCoordinator");
            Context.ActorOf(Props.Create<PlaybackStatisticsActor>(), "PlaybackStatistics");
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
