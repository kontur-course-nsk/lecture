namespace CleanCode.Cases.Names
{
    class Example6
    {
        class PermissionChecker
        {
            public bool CanRead(string role)
            {
                if (role == "Admin")
                    return true;

                if (role == "User")
                    return true;

                if (role == "Moderator")
                    return true;

                return false;
            }

            public bool CanWrite(string role)
            {
                if (role == "Admin")
                    return true;

                if (role == "User")
                    return false;

                if (role == "Modetaror")
                    return true;

                return false;
            }
        }
    }
}
