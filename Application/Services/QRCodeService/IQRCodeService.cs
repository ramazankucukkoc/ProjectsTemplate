namespace Application.Services.QRCodeService
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCode(string text);
    }
}
