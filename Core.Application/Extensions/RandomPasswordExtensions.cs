namespace Core.Application.Extensions
{
    public static class RandomPasswordExtensions
    {
        public static string CreateRandomPassword(int length = 14)
        {
            var validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new();
            var chars = new char[length];
            for (var i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}
