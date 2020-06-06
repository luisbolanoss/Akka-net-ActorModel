using Akka.Actor;

namespace MovieStreaming.Actors
{
    public class ChatActor : ReceiveActor
    {
        private readonly string _userId;
        private readonly string _chatRoomId;

        public ChatActor(string userId, string chatRoomId)
        {
            _userId = userId;
            _chatRoomId = chatRoomId;

            // start with the Authenticating behavior
            // Authenticating();
        }

        //protected override void PreStart()
        //{
        //    // start the authentication process for this user
        //    Context.ActorSelection("/user/authenticator/")
        //        .Tell(new AuthenticatePlease(_userId));
        //}

        //private void Authenticating()
        //{
        //    Receive<AuthenticationSuccess>(auth => {
        //        Become(Authenticated); //switch behavior to Authenticated
        //    });
        //    Receive<AuthenticationFailure>(auth => {
        //        Become(Unauthenticated); //switch behavior to Unauthenticated
        //    });
        //    Receive<IncomingMessage>(inc => inc.ChatRoomId == _chatRoomId,
        //        inc => {
        //        // can't accept message yet - not auth'd
        //    });
        //    Receive<OutgoingMessage>(inc => inc.ChatRoomId == _chatRoomId,
        //        inc => {
        //        // can't send message yet - not auth'd
        //    });
        //}

        //private void Unauthenticated()
        //{
        //    //switch to Authenticating
        //    Receive<RetryAuthentication>(retry => Become(Authenticating));
        //    Receive<IncomingMessage>(inc => inc.ChatRoomId == _chatRoomId,
        //        inc => {
        //        // have to reject message - auth failed
        //    });
        //    Receive<OutgoingMessage>(inc => inc.ChatRoomId == _chatRoomId,
        //        inc => {
        //        // have to reject message - auth failed
        //    });
        //}

        //private void Authenticated()
        //{
        //    Receive<IncomingMessage>(inc => inc.ChatRoomId == _chatRoomId,
        //        inc => {
        //        // print message for user
        //    });
        //    Receive<OutgoingMessage>(inc => inc.ChatRoomId == _chatRoomId,
        //        inc => {
        //        // send message to chatroom
        //    });
        //}
    }
}
