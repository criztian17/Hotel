namespace Hotel.Service.Helpers
{
    internal class Constants
    {
        public static class CommonMessages
        {
            public const string RequiredFields = "Missing required fields.";
            public const string NotExist = "The {0} with Id {1} does not exist.";
            public const string NothingToUpdate = "There is not data to update.";
        }

        public static class GuestMessages
        {
            public const string GuestDoesNotExist = "The guest with {0} {1} does not exist.";
            public const string GuestExist = "The guest with email {1} already exists.";

        }

        public static class RoomMessages
        { 
            public const string RoomExist = "The room with {0} {1} already exists.";
            public const string RoomDoesNotExist = "The room with room number {0} does not exist.";


        }

    }
}
