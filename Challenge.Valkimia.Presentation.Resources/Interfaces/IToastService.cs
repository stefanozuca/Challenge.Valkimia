using Microsoft.AspNetCore.Components;

namespace Challenge.Valkimia.Presentation.Resources
{
    public interface IToastService
    {
        void ShowSuccess(string message);
        void ShowError(string message);
        void ShowError(RenderFragment message);
        void ShowWarning(string message);
    }
}
