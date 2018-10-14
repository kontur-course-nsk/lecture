namespace CleanCode.Cases.Names
{
    class Example6_Result
    {
        class PermissionChecker
        {
            private const string AdminRole = "Admin";
            private const string UserRole = "User";
            private const string ModeratorRole = "Moderator";

            public bool CanRead(string role)
            {
                if (role == AdminRole)
                    return true;

                if (role == UserRole)
                    return true;

                if (role == ModeratorRole)
                    return true;

                return false;
            }

            public bool CanWrite(string role)
            {
                if (role == AdminRole)
                    return true;

                if (role == UserRole)
                    return false;

                if (role == ModeratorRole)
                    return true;

                return false;
            }
        }
    }
}
