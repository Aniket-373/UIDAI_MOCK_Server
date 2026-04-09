public interface IKycService
{
    string Process(string xml, string? scenario);
}