using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoreWebAPI1.ModelBinding
{
    public class CustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            bindingContext.ActionContext.HttpContext.Request.Query.TryGetValue("name", out var name);
            bindingContext.HttpContext.Request.Headers.TryGetValue("headerN", out var name1);
            string strname = name.ToString();
            string strname1 = name1.ToString();
            bindingContext.Result = ModelBindingResult.Success(strname);

            return Task.CompletedTask;
        }
    }
}
