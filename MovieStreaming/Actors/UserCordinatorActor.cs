using Akka.Actor;
using MovieStreaming.Core;
using MovieStreaming.Messages;
using System;
using System.Collections.Generic;

namespace MovieStreaming.Actors
{
    public class UserCordinatorActor: ReceiveActor
    {
        private readonly Dictionary<int, IActorRef> _users;

        public UserCordinatorActor()
        {
            _users = new Dictionary<int, IActorRef>();

            Receive<PlayMovieMessage>(message => {
                CreateChildIfNoExists(message.UserId);
                IActorRef childActorRef = _users[message.UserId];
                childActorRef.Tell(message);
            });

            Receive<StopMovieMessage>(message => {
                CreateChildIfNoExists(message.UserId);
                IActorRef childActorRef = _users[message.UserId];
                childActorRef.Tell(message);
            });
        }

        private void CreateChildIfNoExists(int userId)
        {
            if (!_users.ContainsKey(userId))
            {
                _users.Add(userId, Context.ActorOf(Props.Create<UserActor>(), string.Format("User{0}", userId)));
                ColorConsole.WriteLineCyan(string.Format("UserCordinator created new child UserActor for {0} (Total Users: {1})", userId, _users.Count));
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