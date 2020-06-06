using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStreaming.Messages
{
    class PlayMovieMessage
    {
        public string MovieTitle { get; private set; }

        public int UserId { get; private set; }

        public PlayMovieMessage(string movieTitle, int userId) {
            MovieTitle = movieTitle;
            UserId = userId;
        }
    }
}
