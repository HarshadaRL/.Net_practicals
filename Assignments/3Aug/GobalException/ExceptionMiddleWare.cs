namespace _03Aug2026_Ass.GlobalException
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(
                    $"An error occurred: {ex.Message}"
                );
            }
        }
    }
}