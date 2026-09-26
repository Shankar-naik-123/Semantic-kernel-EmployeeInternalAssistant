using Microsoft.SemanticKernel;

namespace EmployeeAI.AI.SemanticKernel
{
    public static class KernelFactory
    {
        public static Kernel Create()
        {
            var kernel = Kernel.CreateBuilder();
            kernel.AddOllamaChatCompletion(
                modelId: "qwen3:4b",
                endpoint: new Uri("http://localhost:11434")
                );
            return kernel.Build();
        }
    }
}
