namespace SistemaAutoPartesAPI.Utils
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public object Data { get; set; }

        public ApiResponse(int status, string mensaje, object data = null)
        {
            Status = status;
            Mensaje = mensaje;
            Data = data;
        }

        public static ApiResponse Response(int status, string mensaje)
        {
            return new ApiResponse(status, mensaje);
        }
    }
}