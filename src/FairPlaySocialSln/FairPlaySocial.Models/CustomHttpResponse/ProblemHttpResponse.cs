namespace FairPlaySocial.Models.CustomHttpResponse
{
    /// <summary>
    /// Represents an Http Problem Response
    /// </summary>
    public class ProblemHttpResponse
    {
        /// <summary>
        /// Type of Problem
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// Problem's Title
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Status Code
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// Problem's Detail
        /// </summary>
        public string? Detail { get; set; }
        /// <summary>
        /// Trace Id
        /// </summary>
        public string? TraceId { get; set; }
        /// <summary>
        /// Errors
        /// </summary>
        public Dictionary<string, string[]>? Errors { get; set; }
    }

}
