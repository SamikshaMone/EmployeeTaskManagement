namespace EmployeeTaskManagementSystem.Models
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public static ApiResponse<T> Success(T data, string message = "") =>
            new ApiResponse<T> { IsSuccess = true, Message = message, Data = data };

        public static ApiResponse<T> Fail(string message) =>
            new ApiResponse<T> { IsSuccess = false, Message = message };
    }
}
