namespace policyInsurance.Entities
{
    public class Error
    {
        /// <summary>
        /// Http status code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }
    }
}
