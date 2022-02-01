namespace CleanArchitecture.Application.CustomExceptions
{
    public class ApplicationHandleException : Exception
    {
        private const string ErrorMessage = "Entity could not be loaded";

        public ApplicationHandleException() : base(ErrorMessage) {  }

        public static void When(bool hasError)
        {
            if (hasError)
                throw new ApplicationHandleException();
        }
    }
}
