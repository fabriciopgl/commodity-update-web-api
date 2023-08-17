namespace Commodities.WebApi.Helpers
{
    public class AppError
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Error { get; set; }


        /// <summary>
        /// POCO object to return standard payload error 
        /// </summary>
        public AppError(string path, string title, string error)
        {
            Path = path;
            Title = title;
            Error = error;
        }
    }
}