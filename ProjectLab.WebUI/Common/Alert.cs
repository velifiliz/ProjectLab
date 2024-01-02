using NToastNotify;

namespace ProjectLab.WebUI.Common;

public interface IAlert
{
    void Error(string msg);
    void Info(string msg);
    void Success(string msg);
    void Warning(string msg);
}

public class Alert(IToastNotification toastNotification) : IAlert
{
    public void Error(string msg)
    {
        toastNotification.AddErrorToastMessage(msg, new ToastrOptions
        {
            Title = "Hata",
        });
    }

    public void Success(string msg)
    {
        toastNotification.AddSuccessToastMessage(msg, new ToastrOptions
        {
            Title = "Başarılı",
        });
    }

    public void Info(string msg)
    {
        toastNotification.AddInfoToastMessage(msg, new ToastrOptions
        {
            Title = "Bilgi",
        });
    }
    public void Warning(string msg)
    {
        toastNotification.AddWarningToastMessage(msg, new ToastrOptions
        {
            Title = "Uyarı",
        });
    }
}
