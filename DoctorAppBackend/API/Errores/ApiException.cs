namespace API.Errores
{
    public class ApiException : ApiErrorResponse
    {
        public ApiException(int statusCode, string mensaje=null, string detalle = null) :base(statusCode,mensaje)
        {
            Detalle = detalle;
        }
       
        public string Detalle { get; set; }
    }
}
