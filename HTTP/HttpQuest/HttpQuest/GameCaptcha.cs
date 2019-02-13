using System;
using System.Text;

namespace HttpQuest
{
    public class GameCaptcha
    {
        public GameCaptcha(string question, string answer, DateTime expireAt)
        {
            this.Question = question;
            this.Answer = answer;
            this.ExpireAt = expireAt;
        }

        public string Question { get; }

        public string Answer { get; }

        public DateTime ExpireAt { get; }

        public bool IsExpired()
        {
            return DateTime.Now > this.ExpireAt;
        }

        public static GameCaptcha Generate(int count, TimeSpan expireTime)
        {
            var random = new Random();
            var sb = new StringBuilder();
            var answer = 0;

            for (var i = 0; i < count; i++)
            {
                var number = random.Next(11, 49);
                answer += number;

                if (sb.Length != 0)
                {
                    sb.Append(" + ");
                }

                sb.Append(number);
            }

            sb.Append(" = ?");

            return new GameCaptcha(
                sb.ToString(),
                answer.ToString(),
                DateTime.Now.Add(expireTime));
        }
    }
}